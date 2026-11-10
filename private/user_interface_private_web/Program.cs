using application_lib.Services;
using application_services_lib.Services;
using bureau_data_lib;
using bureau_web_ui_lib;
using CreditReport.RazorComponents;
using CreditReport.RazorComponents.Models;
using legal_persons_lib;
using legal_persons_lib.Entities;
using legal_persons_lib.Entities.Requests;
using legal_persons_lib.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using Serilog;
using user_interface_private_web.Entities;
using user_interface_private_web.Pages.Requests.RequestOfBureau;
using user_interface_private_web.Services;

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

    builder.Services.AddRazorPages();

    builder.Services.AddServerSideBlazor().AddHubOptions(options => { options.MaximumReceiveMessageSize = null; options.EnableDetailedErrors = true; }); 

    builder.Services.AddAuthorizationCore();
    builder.Services.AddScoped<AuthenticationStateProvider, AuthProvider>();
    builder.Services.AddScoped<AuthProvider>();
    builder.Services.AddScoped<Loader>();
    builder.Services.AddScoped<AuthenticationStateProvider>(provider => provider.GetRequiredService<AuthProvider>());

    builder.Services.AddScoped<IRepository<DBUser>, Repository<DBUser>>();
    builder.Services.AddScoped<IRepository<DBUserAccess>, Repository<DBUserAccess>>();
    builder.Services.AddScoped<IRepository<DBCertificate>, Repository<DBCertificate>>();
    builder.Services.AddScoped<IRepository<DBLogon>, Repository<DBLogon>>();
    builder.Services.AddScoped<IRepository<DBOrganization>, Repository<DBOrganization>>();
    builder.Services.AddScoped<IRepository<DBOrganizationType>, Repository<DBOrganizationType>>();
    builder.Services.AddTransient<IRepository<DBOrganizationAccess>, Repository<DBOrganizationAccess>>();
    builder.Services.AddScoped<IRepository<DBService>, Repository<DBService>>();
    builder.Services.AddScoped<IRepository<DBRequestParameter>, Repository<DBRequestParameter>>();
    builder.Services.AddScoped<IRepository<DBRequestCheckContractsByUser>, Repository<DBRequestCheckContractsByUser>>();
    builder.Services.AddScoped<IRepository<DBRequestForGovernmentByUser>, Repository<DBRequestForGovernmentByUser>>();
    builder.Services.AddScoped<IRepository<DBRequestOfBureau>, Repository<DBRequestOfBureau>>();
    builder.Services.AddScoped<IRepository<DBRequestOfQBCH>, Repository<DBRequestOfQBCH>>();
    builder.Services.AddScoped<IRepository<DBTemporaryCode>, Repository<DBTemporaryCode>>();
    builder.Services.AddScoped<IRepository<DBRegistrationCode>, Repository<DBRegistrationCode>>();
    //builder.Services.AddScoped<IRepository<DBUpload>, Repository<DBUpload>>();


    builder.Services.AddScoped<IUserManager, UserManager>();
    builder.Services.AddScoped<IOrganizationManager, OrganizationManager>();
    builder.Services.AddScoped<ICertificateManager, CertificateManager>();
    builder.Services.AddScoped<IServiceManager, ServiceManager>();
    builder.Services.AddScoped<IStringManager, StringManager>();
    builder.Services.AddScoped<IRequestManager, RequestManager>();
    builder.Services.AddTransient<IUploadManager, UploadManager>();
    builder.Services.AddScoped<IClassValidator, ClassValidator>();
    builder.Services.AddScoped<IBureauRequestModelFactory, BureauRequestModelFactory>();
    builder.Services.AddScoped<IBureauRequestValidator, BureauRequestValidator>();
    builder.Services.AddScoped<IBureauRequestXmlBuilder, BureauRequestXmlBuilder>();

    var creditReportSection = builder.Configuration.GetSection("CreditReport");
    builder.Services.Configure<LightOptions>(creditReportSection.GetSection("LightOptions"));
    builder.Services.Configure<CreditworthinessOptions>(creditReportSection.GetSection("CreditworthinessOptions"));

    builder.Services.AddSingleton<References>();
    builder.Services.AddCreditReportComponents();


    builder.Services.AddScoped<ISender, Sender>();
    builder.Services.AddScoped<IFetcher, Fetcher>();

    builder.Services.AddDbContextFactory<LegalPersonsContext>(o => o.UseNpgsql(builder.Configuration.GetConnectionString("LegalPersons")!));
    builder.Services.AddDbContextFactory<BureauDataContext>(o => o.UseNpgsql(builder.Configuration.GetConnectionString("BureauData")!));
    builder.Services.AddDbContextFactory<BureauWebUIContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("BureauWebUI")!));



    builder.Services.AddSerilog((services, loggerConfiguration) => loggerConfiguration
        .ReadFrom.Configuration(builder.Configuration)
        .ReadFrom.Services(services));


    builder.Services.AddScoped(sp => new HttpClient());

    /*builder.Services.AddServerSideBlazor()
        .AddHubOptions(options => options.MaximumReceiveMessageSize = 5000000L);*/

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
