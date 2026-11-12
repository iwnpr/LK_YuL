using application_lib.Entities;
using application_lib.Services;
using legal_persons_lib;
using legal_persons_lib.Entities;
using legal_persons_lib.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging.Abstractions;
using private_lib;

string Connection(string name) => Environment.GetEnvironmentVariable("ConnectionStrings__" + name)
    ?? throw new InvalidOperationException("Run Use-LocalDatabases.ps1 in this session first.");
var factory = new PooledDbContextFactory<LegalPersonsContext>(new DbContextOptionsBuilder<LegalPersonsContext>()
    .UseNpgsql(Connection("LegalPersons")).Options);
var usersFactory = new PooledDbContextFactory<BureauUsersContext>(new DbContextOptionsBuilder<BureauUsersContext>()
    .UseSqlServer(Connection("BureauUsers")).Options);
Repository<T> Repo<T>() where T : DBEntity => new(factory, NullLogger<Repository<T>>.Instance);
var manager = new UserManager(usersFactory, null!, Repo<DBUser>(), Repo<DBOrganization>(),
    Repo<DBRegistrationCode>(), Repo<DBUserAccess>(), Repo<DBRequestParameter>(), Repo<DBTemporaryCode>(),
    new ConfigurationBuilder().Build(), Repo<DBLogon>());

var result = await manager.SignAsync(new Creditionals { Login = "LOCALADMIN", Password = "LocalAdmin_2026!", IpAddress = "127.0.0.254" });
if (result.Code != 200) throw new Exception("Seeded user login failed: " + result.Message);
var rejected = await manager.SignAsync(new Creditionals { Login = "localadmin", Password = "incorrect", IpAddress = "127.0.0.254" });
if (rejected.Code == 200) throw new Exception("Wrong password was accepted.");
await using var pg = await factory.CreateDbContextAsync();
var user = await pg.Users.Include(x => x.Organization).SingleAsync(x => x.Login == "localadmin");
if (user.Id != -900001 || user.OrganizationId != -900001 || !user.IsActive || !user.IsAproved || !user.Organization.IsActive)
    throw new Exception("Seed user or organization state mismatch.");
var organizationManager = new OrganizationManager(Repo<DBOrganization>(), Repo<DBOrganizationType>(), Repo<DBOrganizationAccess>());
var userRights = await manager.GetAccessesAsync(user.Id);
var orgRights = await organizationManager.GetAccessesAsync(user.OrganizationId);
foreach (var role in new[] { "organizations", "users", "certificates", "abonents", "documentation" })
{
    var grants = orgRights.Where(x => x.ServiceName == role && x.Access)
        .Where(x => userRights.Any(u => u.ServiceId == x.ServiceId && u.Access)).ToList();
    if (grants.Count != 1) throw new Exception("Missing or duplicate effective role: " + role);
}
await using var ms = await usersFactory.CreateDbContextAsync();
var person = await ms.TdNaturalPersons.SingleAsync(x => x.KeyId == user.NaturalPersonId);
if (person.LegalPersonId != user.Organization.LegalPersonId ||
    !await ms.TdLegalPersons.AnyAsync(x => x.KeyId == person.LegalPersonId && x.Active))
    throw new Exception("SQL Server user/organization links mismatch.");
if (await pg.Users.CountAsync(x => x.Login.ToLower() == "localadmin") != 1 ||
    await ms.TdNaturalPersons.CountAsync(x => x.Login.ToLower() == "localadmin") != 1)
    throw new Exception("Repeated seed created duplicate users.");
Console.WriteLine("Public seed smoke check passed: login, wrong password rejection, five effective roles, SQL Server links and no duplicate users.");
