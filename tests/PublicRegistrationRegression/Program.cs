using System.Reflection;
using application_lib.Entities;
using application_lib.Services;
using legal_persons_lib.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging.Abstractions;
using user_interface_public_web.Entities;
using user_interface_public_web.Pages.NotAthorized;

// Exercise the actual Razor event handler without a database, browser or outgoing email.
var type = Type.GetType("user_interface_public_web.Pages.NotAthorized.Registration, user_interface_public_web", true)!;
const BindingFlags flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
foreach (var scenario in new[] { "success", "missing-support", "missing-organization", "mail-error", "mail-exception", "registration-exception", "rejected", "validation", "password-mismatch" })
{
    var component = Activator.CreateInstance(type)!;
    void Inject(string name, object value) => type.GetProperty(name, flags)!.SetValue(component, value);
    void Field(string name, object value) => type.GetField(name, flags)!.SetValue(component, value);
    T Read<T>(string name) => (T)type.GetField(name, flags)!.GetValue(component)!;
    int registrations = 0, mails = 0;
    Inject("_logger", NullLogger<Registration>.Instance);
    Inject("_validator", Stub<IClassValidator>((_, _) => new Answer(scenario == "validation" ? 300 : 200, "validation")));
    Inject("_userMngr", Stub<IUserManager>((_, _) =>
    {
        registrations++;
        return scenario == "registration-exception" ? Task.FromException<Answer>(new Exception("database unavailable"))
            : Task.FromResult(new Answer(scenario == "rejected" ? 300 : 200, "registration result"));
    }));
    Inject("_orgMngr", Stub<IOrganizationManager>((_, _) => Task.FromResult<DBOrganization?>(
        scenario == "missing-organization" ? null : new() { ShortName = "Test organization" })));
    Inject("_sender", Stub<ISender>((_, args) =>
    {
        mails++;
        var message = (EmailMessage)args![0]!;
        if (message.Body != "В личном кабинете ООО \"БКИ КредитИнфо\" зарегистрирован новый пользователь testuser (Test organization) и ожидает подтверждение учетной записи")
            throw new Exception("Existing notification text was changed");
        return scenario == "mail-exception" ? Task.FromException<Answer>(new Exception("mail unavailable"))
            : Task.FromResult(new Answer(scenario == "mail-error" ? -1 : 200, "mail result"));
    }));
    var settings = new Dictionary<string, string?>();
    if (scenario != "missing-support")
    {
        settings["Support:0:UserName"] = "Test support";
        settings["Support:0:Email"] = "support@example.invalid";
    }
    Inject("_configuration", new ConfigurationBuilder().AddInMemoryCollection(settings).Build());
    Field("_user", new DBUser { Login = "testuser", Password = "test-password", OrganizationId = 1 });
    Field("_confirmation", scenario == "password-mismatch" ? "other" : "test-password");
    async Task Submit() => await (Task)type.GetMethod("RegistrationUserAsync", flags)!.Invoke(component, null)!;
    Field("_disabled", true);
    await Submit();
    if (registrations != 0) throw new Exception(scenario + ": submitted while busy");
    Field("_disabled", false);
    await Submit();
    if (Read<bool>("_disabled")) throw new Exception(scenario + ": busy state was not cleared");
    bool expectedSuccess = scenario is not ("registration-exception" or "rejected" or "validation" or "password-mismatch");
    var comment = Read<Comment>("_comment");
    if (!comment.Show || comment.Status != (expectedSuccess ? "ok" : "error")) throw new Exception(scenario + ": wrong user feedback");
    if (scenario == "missing-support" && mails != 0) throw new Exception("Missing support must not send email");
    if (scenario == "missing-organization" && mails != 0) throw new Exception("Missing organization must not send an incomplete notification");
    var expectedMessage = scenario switch
    {
        "validation" => "validation",
        "password-mismatch" => "Пароли не совпадают",
        "registration-exception" => "При регистрации пользователя произошла ошибка",
        _ => "registration result"
    };
    if (comment.Title != "Регистрация пользователя" || comment.Message != expectedMessage)
        throw new Exception(scenario + ": existing registration message was changed");
    Console.WriteLine("PASS " + scenario);
}

static T Stub<T>(Func<MethodInfo, object?[]?, object?> handler) where T : class
{
    var stub = DispatchProxy.Create<T, ServiceProxy>();
    ((ServiceProxy)(object)stub).Handler = handler;
    return stub;
}

public class ServiceProxy : DispatchProxy
{
    public Func<MethodInfo, object?[]?, object?> Handler { get; set; } = null!;
    protected override object? Invoke(MethodInfo? targetMethod, object?[]? args) => Handler(targetMethod!, args);
}
