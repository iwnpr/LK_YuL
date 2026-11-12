extern alias publicmodels;

using System.Text;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Npgsql;
using PrivateLegal = legal_persons_lib.LegalPersonsContext;
using PublicLegal = publicmodels::legal_persons_lib.LegalPersonsContext;

var output = Path.GetFullPath(args.FirstOrDefault() ?? "infrastructure/database/sql");
Directory.CreateDirectory(output);
var generatedFiles = new Dictionary<string, string>();
// Model generation never opens a connection. Separate data sources isolate the two CLR enum types.
const string pg = "Host=localhost;Database=model_only;Username=model_only;Password=model_only";
const string ms = "Server=localhost;Database=model_only;User Id=model_only;Password=model_only;TrustServerCertificate=True";
var privateSource = new NpgsqlDataSourceBuilder(pg);
privateSource.MapEnum<legal_persons_lib.Enums.DBCertificateStatus>("personal_account.cert_status");
privateSource.MapEnum<legal_persons_lib.Enums.DBGovernment>("personal_account.governments");
privateSource.MapEnum<legal_persons_lib.Enums.DBExampleType>("personal_account.examples_type");
using var privateData = privateSource.Build();
var publicSource = new NpgsqlDataSourceBuilder(pg);
publicSource.MapEnum<publicmodels::legal_persons_lib.Enums.DBCertificateStatus>("personal_account.cert_status");
using var publicData = publicSource.Build();
using var privateLegal = new PrivateLegal(new DbContextOptionsBuilder<PrivateLegal>().UseNpgsql(privateData).Options);
using var publicLegal = new PublicLegal(new DbContextOptionsBuilder<PublicLegal>().UseNpgsql(publicData).Options);
using var qbch = new qbch_lib.BureauQBCHContext(new DbContextOptionsBuilder<qbch_lib.BureauQBCHContext>().UseNpgsql(pg).Options);
using var data = new bureau_data_lib.BureauDataContext(new DbContextOptionsBuilder<bureau_data_lib.BureauDataContext>().UseNpgsql(pg).Options);
using var users = new private_lib.BureauUsersContext(new DbContextOptionsBuilder<private_lib.BureauUsersContext>().UseSqlServer(ms).Options);
using var publicWeb = new private_lib.BureauWebUIContext(new DbContextOptionsBuilder<private_lib.BureauWebUIContext>().UseSqlServer(ms).Options);
using var privateWeb = new bureau_web_ui_lib.BureauWebUIContext(new DbContextOptionsBuilder<bureau_web_ui_lib.BureauWebUIContext>().UseSqlServer(ms).Options);

var legal = Merge(Operations(privateLegal), Operations(publicLegal));
// Required columns known only to public must permit inserts from the private context.
// These defaults match the public CLR defaults; no reference/business data is invented.
SetDefault(legal, "certificates", "request_id", 0L);
SetDefault(legal, "certificates", "legal_person_id", 0L);
SetDefault(legal, "td_users", "sault", "");
SetDefault(legal, "te_temporary_codes", "is_active", true);
Write("legal_persons", privateLegal, legal);
Write("bureau_qbch", qbch, Operations(qbch));
Write("bureau_data", data, Operations(data));
Write("bureau_users", users, Operations(users));
Write("bureau_web_ui", privateWeb, Merge(Operations(privateWeb), Operations(publicWeb)));
// Validate every model before replacing any checked-in SQL file.
foreach (var (name, sql) in generatedFiles)
    File.WriteAllText(Path.Combine(output, name + ".sql"), sql, new UTF8Encoding(false));

List<MigrationOperation> Operations(DbContext context) => context.GetService<IMigrationsModelDiffer>()
    .GetDifferences(null, context.GetService<IDesignTimeModel>().Model.GetRelationalModel()).ToList();

List<MigrationOperation> Merge(List<MigrationOperation> target, List<MigrationOperation> source)
{
    foreach (var operation in source)
    {
        switch (operation)
        {
            case EnsureSchemaOperation schema when target.OfType<EnsureSchemaOperation>().Any(x => x.Name == schema.Name):
                break;
            case AlterDatabaseOperation database when target.OfType<AlterDatabaseOperation>().FirstOrDefault() is { } existing:
                foreach (var annotation in database.GetAnnotations())
                {
                    var prior = existing.FindAnnotation(annotation.Name);
                    if (prior is null) existing.AddAnnotation(annotation.Name, annotation.Value);
                    else if (!Equals(prior.Value, annotation.Value)) throw new InvalidOperationException($"Conflicting database annotation: {annotation.Name}");
                }
                break;
            case CreateTableOperation table when target.OfType<CreateTableOperation>().FirstOrDefault(x => x.Schema == table.Schema && x.Name == table.Name) is { } existing:
                foreach (var column in table.Columns)
                {
                    var prior = existing.Columns.FirstOrDefault(x => x.Name == column.Name);
                    if (prior is null) existing.Columns.Add(column);
                    else RequireEqual(prior, column, $"{table.Schema}.{table.Name}.{column.Name}");
                }
                RequireEqual(existing.PrimaryKey, table.PrimaryKey, $"{table.Name} primary key");
                MergeNamed(existing.ForeignKeys, table.ForeignKeys, x => x.Name);
                MergeNamed(existing.UniqueConstraints, table.UniqueConstraints, x => x.Name);
                MergeNamed(existing.CheckConstraints, table.CheckConstraints, x => x.Name);
                break;
            case CreateIndexOperation index when target.OfType<CreateIndexOperation>().FirstOrDefault(x => x.Schema == index.Schema && x.Table == index.Table && x.Name == index.Name) is { } existing:
                RequireEqual(existing, index, index.Name);
                break;
            default:
                target.Add(operation);
                break;
        }
    }
    return target;
}

void MergeNamed<T>(List<T> target, List<T> source, Func<T, string> name) where T : MigrationOperation
{
    foreach (var item in source)
    {
        var prior = target.FirstOrDefault(x => name(x) == name(item));
        if (prior is null) target.Add(item);
        else RequireEqual(prior, item, name(item));
    }
}

void RequireEqual(MigrationOperation? left, MigrationOperation? right, string label)
{
    // Compare store definitions, including provider annotations, without serializing CLR Type objects.
    string Describe(MigrationOperation? value) => value is null ? "null" : JsonSerializer.Serialize(new
    {
        Properties = value.GetType().GetProperties().Where(p => p.GetIndexParameters().Length == 0 && p.Name != "ClrType")
            .OrderBy(p => p.Name).ToDictionary(p => p.Name, p => p.GetValue(value)),
        Annotations = value.GetAnnotations().OrderBy(a => a.Name).ToDictionary(a => a.Name, a => a.Value)
    });
    if (Describe(left) != Describe(right)) throw new InvalidOperationException($"Conflicting EF definitions: {label}. Align the models before generating SQL.");
}

void SetDefault(List<MigrationOperation> operations, string table, string column, object value) =>
    operations.OfType<CreateTableOperation>().Single(x => x.Name == table).Columns.Single(x => x.Name == column).DefaultValue = value;

void Write(string name, DbContext context, List<MigrationOperation> operations)
{
    var commands = context.GetService<IMigrationsSqlGenerator>().Generate(operations, context.GetService<IDesignTimeModel>().Model);
    var sql = "-- Generated from EF Core models. Run infrastructure/database/Generate-Schema.ps1 to refresh.\n" +
        string.Join("\n", commands.Select(x => x.CommandText));
    generatedFiles.Add(name, sql.Replace("\r\n", "\n"));
    Console.WriteLine($"{name}: {operations.OfType<CreateTableOperation>().Count()} tables");
}
