using application_lib.Services;
using legal_persons_lib;
using legal_persons_lib.Entities;
using legal_persons_lib.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using private_lib;
using qbch_lib;
using Serilog;
using user_interface_web.Services;

Log.Logger = new LoggerConfiguration()
    .WriteTo.File(
        "Logs/startup_.log",
        rollingInterval: RollingInterval.Day,
        fileSizeLimitBytes: 10485760,
        rollOnFileSizeLimit: true,
        retainedFileCountLimit: 30,
        outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level}] {Message}{NewLine}{Exception}")
    .CreateBootstrapLogger();

try
{
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    builder.Services.AddRazorPages();
    builder.Services.AddServerSideBlazor();


    var configuration = builder.Configuration;
    var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

    // Добавление конфигурации в проект
    /*configuration
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
        .AddJsonFile($"appsettings.{env}.json", true, true);
    */


    builder.Services.AddScoped<AuthenticationStateProvider, AuthProvider>();
    builder.Services.AddScoped<AuthProvider>();
    builder.Services.AddScoped<AuthenticationStateProvider>(provider => provider.GetRequiredService<AuthProvider>());

    // Бады данных
    builder.Services.AddDbContextFactory<LegalPersonsContext>(o => o.UseNpgsql(builder.Configuration.GetConnectionString("LegalPersons")!));
    builder.Services.AddDbContextFactory<BureauQBCHContext>(o => o.UseNpgsql(builder.Configuration.GetConnectionString("BureauQBCH")!));
    //builder.Services.AddDbContext<BureauWebUIContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("BureauWebUI")!));
    builder.Services.AddDbContextFactory<BureauUsersContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("BureauUsers")!));
    builder.Services.AddDbContextFactory<BureauWebUIContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("BureauWebUI")!));

    builder.Services.AddSerilog((services, loggerConfiguration) => loggerConfiguration
        .ReadFrom.Configuration(builder.Configuration)
        .ReadFrom.Services(services));

    // Подключение репозиториев
    builder.Services.AddScoped<IRepository<DBUser>, Repository<DBUser>>();
    builder.Services.AddScoped<IRepository<DBCertificate>, Repository<DBCertificate>>();
    builder.Services.AddScoped<IRepository<DBLogon>, Repository<DBLogon>>();
    builder.Services.AddScoped<IRepository<DBOrganization>, Repository<DBOrganization>>();
    builder.Services.AddScoped<IRepository<DBTemporaryCode>, Repository<DBTemporaryCode>>();
    builder.Services.AddScoped<IRepository<DBRegistrationCode>, Repository<DBRegistrationCode>>();
    builder.Services.AddScoped<IRepository<DBUserAccess>, Repository<DBUserAccess>>();
    builder.Services.AddScoped<IRepository<DBOrganizationAccess>, Repository<DBOrganizationAccess>>();
    builder.Services.AddScoped<IRepository<DBOrganizationType>, Repository<DBOrganizationType>>();
    builder.Services.AddScoped<IRepository<DBService>, Repository<DBService>>();

    builder.Services.AddScoped<IRepository<DBTemporaryCode>, Repository<DBTemporaryCode>>();
    builder.Services.AddScoped<IRepository<DBRegistrationCode>, Repository<DBRegistrationCode>>();
    builder.Services.AddScoped<IRepository<DBRequestParameter>, Repository<DBRequestParameter>>();

    // Подключение сервисов
    builder.Services.AddScoped<IUserManager, UserManager>();
    builder.Services.AddScoped<IOrganizationManager, OrganizationManager>();
    builder.Services.AddScoped<ICertificateManager, CertificateManager>();
    builder.Services.AddScoped<IStringManager, StringManager>();
    builder.Services.AddScoped<IClassValidator, ClassValidator>();
    builder.Services.AddScoped<IServiceManager, ServiceManager>();
    builder.Services.AddScoped<IAbonentManager, AbonentManager>();


    builder.Services.AddScoped<ISender, Sender>();


    AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);


    builder.WebHost.UseWebRoot("wwwroot");
    builder.WebHost.UseStaticWebAssets();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Error");
    }

    app.UseStaticFiles();

    app.UseRouting();

    app.MapBlazorHub();
    app.MapFallbackToPage("/_Host");

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Приложение завершено из-за необработанной ошибки");
    Environment.ExitCode = 1;
}
finally
{
    Log.CloseAndFlush();
}
