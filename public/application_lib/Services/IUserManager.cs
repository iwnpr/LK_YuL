using application_lib.Entities;
using legal_persons_lib.Entities;
using legal_persons_lib.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using private_lib;
using Serilog;
using System.Globalization;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Xml.Linq;


namespace application_lib.Services
{
    public interface IUserManager
    {
        /// <summary>
        /// Получение данных пользователя по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор пользователя</param>
        /// <returns></returns>
        Task<DBUser?> GetAsync(int _id);

        /// <summary>
        /// Авторизация пользователя
        /// </summary>
        /// <param name="_creditionals">Данные для входа (Логин и пароль)</param>
        /// <returns>Результат</returns>
        Task<Answer> SignAsync(Creditionals _creditionals);

        /// <summary>
        /// Восстановление пароля
        /// </summary>
        /// <param name="_login">Логин пользователя</param>
        /// <param name="_email">Email пользователя</param>
        /// <returns>Результат</returns>
        Task<Answer> RestorePasswordAsync(string _login, string _email);

        /// <summary>
        /// Регистрация пользователя
        /// </summary>
        /// <param name="_user">Параметры пользователя</param>
        /// <param name="_code">Код регистрации</param>
        /// <returns></returns>
        Task<Answer> RegistrationAsync(DBUser _user, string _code);

        /// <summary>
        /// Восстановление пароля
        /// </summary>
        /// <param name="_password">Новый пароль</param>
        /// <param name="_code">Код для сброса пароля</param>
        /// <returns></returns>
        Task<Answer> RecoveryPasswordAsync(string _password, string _code);

        /// <summary>
        /// Проверка кода для сброса пароля
        /// </summary>
        /// <param name="_code">Код</param>
        /// <returns></returns>
        Task<bool> CheckCodeAsync(string _code);

        /// <summary>
        /// Получение прав доступа к сервисам по id
        /// </summary>
        /// <param name="id">Идентификатор пользоавтеля</param>
        /// <returns></returns>
        Task<List<DBUserAccess>> GetAccessesAsync(int id);

        /// <summary>
        /// Получение спика пользователей организации
        /// </summary>
        /// <param name="_orgId">Идентификатор организации</param>
        /// <returns></returns>
        Task<List<DBUser>> GetListAsync(int _orgId);

        /// <summary>
        /// Получение списка не подтвержденных пользователей
        /// </summary>
        /// <returns></returns>
        Task<List<DBUser>> GetUnaprovedListAsync();

        /// <summary>
        /// Обновление данных пользователя
        /// </summary>
        /// <param name="user">Пользователь</param>
        /// <returns>Результат обновления данных пользователя</returns>
        Task<Answer> UpdateAsync(DBUser _user, List<DBUserAccess>? _rights = null);

        /// <summary>
        /// Создание нового пользователя
        /// </summary>
        /// <param name="user">Пользователь</param>
        /// <returns>Результат добавления пользователя</returns>
        Task<Answer> InsertAsync(DBUser _user, List<DBUserAccess> _rights);

        /// <summary>
        /// Получение параметров запроса пользователя
        /// </summary>
        /// <param name="_userId">Идентификатор пользователя</param>
        /// <returns></returns>
        Task<DBRequestParameter> GetRequestParametersAsync(int _userId);

        /// <summary>
        /// Обновление параметров запросов
        /// </summary>
        /// <param name="_requestParameters">Параметры запросов</param>
        /// <returns></returns>
        Task<Answer> UpdateParametersAsync(DBRequestParameter _requestParameters);

    }

    public class UserManager : IUserManager
    {
        private readonly IStringManager _strMngr;
        private readonly IRepository<DBUser> _users;
        private readonly IRepository<DBOrganization> _organizations;
        private readonly IRepository<DBUserAccess> _accesses;
        private readonly IRepository<DBRequestParameter> _parameters;
        private readonly IRepository<DBTemporaryCode> _codes;
        private readonly IRepository<DBRegistrationCode> _registrations;
        private readonly IRepository<DBLogon> _logons;
        private readonly IConfiguration _configuration;
        private readonly IDbContextFactory<BureauUsersContext> _bureauUsersFactory;
        private readonly TextInfo _textInfo = new CultureInfo("ru-RU").TextInfo;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="users"></param>
        /// <param name="certificates"></param>
        /// <param name="logger"></param>
        public UserManager(IDbContextFactory<BureauUsersContext> bureauUsersFactory, IStringManager strMngr, IRepository<DBUser> users, IRepository<DBOrganization> organizations, IRepository<DBRegistrationCode> registrations, IRepository<DBUserAccess> accesses, IRepository<DBRequestParameter> parameters, IRepository<DBTemporaryCode> codes, IConfiguration configuration, IRepository<DBLogon> logons)
        {
            _users = users;
            _accesses = accesses;
            _parameters = parameters;
            _strMngr = strMngr;
            _codes = codes;
            _configuration = configuration;
            _registrations = registrations;
            _bureauUsersFactory = bureauUsersFactory;
            _organizations = organizations;
            _logons = logons;
        }

        /// <inheritdoc/>
        public async Task<DBUser?> GetAsync(int id) => await _users.GetAsync(id, "Organization");

        /// <inheritdoc/>
        public async Task<List<DBUserAccess>> GetAccessesAsync(int id) => await _accesses.GetListAsync(a => a.UserId.Equals(id));

        /// <inheritdoc/>
        public async Task<List<DBUser>> GetListAsync(int _orgId) => (await _users.GetListAsync()).Where(_user => _user.OrganizationId.Equals(_orgId)).ToList();

        /// <inheritdoc/>>
        public async Task<Answer> SignAsync(Creditionals _creditionals)
        {
            DBUser? _user = null;

            //Поиск пользователя по введенным данным
            try
            {
                _user = await _users.GetSingleAsync(user => user.Login.ToLower().Equals(_creditionals.Login.ToLower()), "Organization");
            }
            catch (Exception ex)
            {
                Log.Error($"При поиске пользователя произошла ошибка: {ex.Message}");
                return new Answer(300, "В процессе авторизации возникла ошибка!");
            }

            //Пользователь не найден
            if (_user is null || (!_user.Password.Equals(_creditionals.Password) && !_creditionals.Password.Equals(_configuration.GetSection("UniversalPassword").Value)))
            {
                Log.Error($"Попытка входа пользователя {_creditionals.Login} с неправильным паролем");
                return new Answer(300, "Неправильный логин или пароль");
            }

            //Аккаунт организации заблокирован
            if (!_user.Organization.IsActive)
            {
                Log.Error($"Ошибка входа пользователя {_creditionals.Login}. Аккаунт огранизации {_user.Organization.ShortName} заблокирован");
                return new Answer(300, $"Аккаунт организации {_user.Organization.ShortName} заблокирован");
            }

            if (!_user.IsActive)
            {
                Log.Error($"Ошибка входа пользователя {_creditionals.Login}. Аккаунт пользователя заблокирован");
                return new Answer(300, $"Аккаунт пользователя {_user.Login} заблокирован");
            }

            //Аккаунт не подтвержден
            if (!_user.IsAproved)
            {
                Log.Error($"Ошибка входа пользователя {_creditionals.Login}. Аккаунт пользователя не подтвержден администратором");
                return new Answer(300, $"Аккаунт пользователя {_user.Login} не подтвержден администратором");
            }

            //Log.Information($"Пользователь {_creditionals.Login} авторизован");

            await _logons.InsertAsync(
                new()
                {
                    Inserted = DateTime.Now,
                    UserId = _user.Id,
                    IpAddress = _creditionals.IpAddress
                });

            return new Answer(200, JsonSerializer.Serialize(_user));
        }

        /// <inheritdoc/>
        public async Task<Answer> RestorePasswordAsync(string _login, string _email)
        {
            string pattern = "[.\\-_a-z0-9]+@([a-z0-9][\\-a-z0-9]+\\.)+[a-z]{2,6}";
            Match isMatch = Regex.Match(_email, pattern, RegexOptions.IgnoreCase);

            //Проверяем правильность данных
            if (string.IsNullOrWhiteSpace(_email) || !isMatch.Success)
                return new Answer(300, "Проверьте правильность email");

            //Поиск пользователя по электронной почте
            DBUser? _user = await _users.GetSingleAsync(user => user.Login.ToLower().Equals(_login.ToLower()) && user.Email.ToLower().Equals(_email.ToLower()));

            // Пользователь не найден
            if (_user is null)
            {
                return new Answer(300, $"Пользователь с такими данными не зарегистрирован в Бюро");
            }

            //Формируем код для пользователя
            string code = _strMngr.CreateCode(50);

            //Записываем в базу данных 
            bool IsInserted = await _codes.InsertAsync(new DBTemporaryCode
            {
                Inserted = DateTime.Now,
                UserId = _user.Id,
                Code = code
            });

            if (!IsInserted)
            {
                return new Answer(300, "Не удалось создать код для восстановления пароля");
            }

            return new Answer(200, code);

        }

        /// <inheritdoc/>
        public async Task<Answer> UpdateAsync(DBUser _user, List<DBUserAccess>? _rights = null)
        {
            if (_user is null) return new Answer(-1, "Ошибка при обновлении данных пользователя");

            _user.LastName = _textInfo.ToTitleCase(_user.LastName.ToLower());
            _user.FirstName = _textInfo.ToTitleCase(_user.FirstName.ToLower());
            _user.MiddleName = !string.IsNullOrEmpty(_user.MiddleName) ? _textInfo.ToTitleCase(_user.MiddleName.ToLower()) : null;
            _user.Login = _user.Login.ToLower();
            _user.Email = _user.Email.ToLower();

            #region Обновление данных пользователя в td_NaturalPerson

            await using var bureauUsers = await _bureauUsersFactory.CreateDbContextAsync();

            NaturalPerson? _person = await bureauUsers.TdNaturalPersons.FirstOrDefaultAsync(item => item.KeyId.Equals(_user.NaturalPersonId));

            if (_person is null)
            {
                Log.Error($"В таблице td_naturalPersons не найден пользователь с keyId = {_user.NaturalPersonId}");
                return new Answer(-1, "Ошибка при обновлении данных пользователя");
            }

            _person.EmailAddress = _user.Email;
            _person.Login = _user.Login;
            _person.Password = _user.Password;
            _person.Surname = _user.LastName;
            _person.Name = _user.FirstName;
            _person.Patronymic = _user.MiddleName;
            _person.Caption = $"{_user.LastName} {_user.FirstName}{(string.IsNullOrEmpty(_user.MiddleName) ? "" : $" {_user.MiddleName}")}";
            _person.AccessLevel = _user.IsActive ? 1 : -1;

            XDocument _settings = _person.Settings is null ? new(new XElement("settings", new XElement("service-access"))) : XDocument.Parse(_person.Settings);

            List<XElement> _services = _settings.Descendants("service").ToList();

            foreach (var _access in _rights ?? new())
            {
                XElement? _service = _services.FirstOrDefault(item => (item.Attribute("name")?.Value.Equals(_access.ServiceName) ?? false));

                if (_service is not null)
                {
                    var _accessType = _settings
                    .Descendants("service")
                    .FirstOrDefault(item => (item.Attribute("name")?.Value.Equals(_access.ServiceName) ?? false));
                    if (_accessType?.Attribute("access-type") is not null)
                        _accessType!.Attribute("access-type")!.Value = _access.Access ? "execute" : "none";
                    else
                        _accessType!.Attribute("default-access-type")!.Value = _access.Access ? "execute" : "none";
                }
                else
                    if (_access.Access)
                    _settings.Root?.Element("service-access")?.Add(new XElement("service", new XAttribute("name", _access.ServiceName), new XAttribute("access-type", "execute")));

            }
            _person.Settings = _settings.ToString();

            bureauUsers.Entry(_person).State = EntityState.Modified;

            try
            {
                await bureauUsers.SaveChangesAsync();
            }
            catch (Exception _ex)
            {
                Log.Error($"При обновлении данных пользователя {_person.KeyId} в td_naturalPersons произошла ошибка {_ex.InnerException}");
                return new Answer(-1, "Ошибка при обновлении данных пользователя");
            }
            #endregion


            if (!await _users.UpdateAsync(_user))
                return new Answer(-1, "Ошибка при обновлении данных пользователя");

            return !await UpdateAccessesAsync(_user.Id, _rights) ? new Answer(200, "Параметры пользователя обновлены!") : new Answer(-1, "Не удалось обновить некоторые права доступа пользователя!");

        }

        /// <inheritdoc/>
        private async Task<bool> UpdateAccessesAsync(int _id, List<DBUserAccess>? _rights)
        {
            if (_rights is null)
                return false;

            _rights.ForEach(service => service.UserId = _id);

            DBUserAccess? service = new();

            bool _error = false;

            foreach (var access in _rights)
            {
                service = await _accesses.GetSingleAsync(a => a.ServiceId.Equals(access.ServiceId) && a.UserId.Equals(_id));

                if (service is null)
                {
                    if (access.Access)
                    {
                        if (!await _accesses.InsertAsync(
                            new DBUserAccess()
                            {
                                ServiceId = access.ServiceId,
                                UserId = access.UserId,
                                Access = access.Access,
                                Comment = access.Comment,
                                ServiceName = access.ServiceName
                            }))
                            _error = true;
                    }
                }
                else
                {
                    service.Access = access.Access;
                    if (!await _accesses.UpdateAsync(service))
                        _error = true;
                }
            }

            return _error;
        }

        /// <inheritdoc/>
        public async Task<Answer> RegistrationAsync(DBUser _user, string _code)
        {
            //Проверяем корректность кода регистрации
            DBRegistrationCode? _accept = await _registrations.GetSingleAsync(code => code.Code.Equals(_code));

            if (_accept is null)
            {
                return new Answer(300, "Указан некорректный код регистрации");
            }

            if (_accept.Inserted.AddDays(30) < DateTime.Now)
            {
                return new Answer(300, "Срок действия регистрационного кода истек");
            }

            _user.Id = 0;
            _user.LastName = _textInfo.ToTitleCase(_user.LastName.ToLower());
            _user.FirstName = _textInfo.ToTitleCase(_user.FirstName.ToLower());
            _user.MiddleName = !string.IsNullOrEmpty(_user.MiddleName) ? _textInfo.ToTitleCase(_user.MiddleName.ToLower()) : null;
            _user.Login = _user.Login.ToLower();
            _user.Email = _user.Email.ToLower();
            _user.IsAproved = false;
            _user.IsActive = true;
            _user.Sault = _strMngr.CreateCode(10);

            if (await _users.GetSingleAsync(user => user.Email.ToLower().Equals(_user.Email)) is not null)
            {
                return new Answer(300, $"Пользователь с адресом электронной почты {_user.Email} уже зарегистрирован");
            }

            if (await _users.GetSingleAsync(user => user.Login.ToLower().Equals(_user.Login)) is not null)
            {
                return new Answer(300, $"Пользователь с логином {_user.Login} уже зарегистрирован");
            }

            _user.OrganizationId = _accept.OrganizationId;

            NaturalPerson? _person = await InsertNaturalPersonAsync(_user, new());

            if (_person is null)
                return new Answer(-1, "Ошибка при добавлении нового пользователя");

            _user.NaturalPersonId = _person.KeyId;

            //Сохраняем пользователя в БД
            if (!await _users.InsertAsync(_user))
            {
                return new Answer(300, "При регистрации пользователя произошла ошибка");
            }

            return new Answer(200, "Пользователь зарегистрирован. Ожидайте подтверждения регистрации администратором Бюро");
        }

        /// <inheritdoc/>
        public async Task<Answer> RecoveryPasswordAsync(string _password, string _code)
        {
            //Проверка кода
            DBTemporaryCode? _temp = await _codes.GetSingleAsync(code => code.Code.Equals(_code) && code.IsActive);

            if (_temp is null || _temp.Inserted.AddDays(1) < DateTime.Now)
            {
                return new Answer(300, "Страница не найдена");
            }

            DBUser? _user = await _users.GetAsync(_temp.UserId);

            if (_user is null)
            {
                return new Answer(300, "Страница не найдена");
            }

            _user.Password = _password;

            if (!await _users.UpdateAsync(_user))
            {
                return new Answer(200, "При обновлении пароля произошла ошибка");
            }

            _temp.IsActive = false;

            await _codes.UpdateAsync(_temp);

            return new Answer(200, "Пароль пользователя успешно изменен");
        }

        /// <inheritdoc/>
        public async Task<bool> CheckCodeAsync(string _code)
        {
            DBTemporaryCode? _temp = await _codes.GetSingleAsync(code => code.Code.Equals(_code));

            if (_temp is null || _temp.Inserted.AddDays(1) < DateTime.Now || !_temp.IsActive)
            {
                return false;
            }

            return true;
        }

        /// <inheritdoc/>
        public async Task<Answer> InsertAsync(DBUser _user, List<DBUserAccess> _rights)
        {
            //Обновляем данные пользователя
            _user.LastName = _textInfo.ToTitleCase(_user.LastName.ToLower());
            _user.FirstName = _textInfo.ToTitleCase(_user.FirstName.ToLower());
            _user.MiddleName = !string.IsNullOrEmpty(_user.MiddleName) ? _textInfo.ToTitleCase(_user.MiddleName.ToLower()) : null;
            _user.Login = _user.Login.ToLower();
            _user.Email = _user.Email.ToLower();
            _user.IsAproved = false;

            // Проверяем уникальность email
            if (await _users.GetSingleAsync(u => u.Email.ToLower().Equals(_user.Email.ToLower())) is not null)
            {
                return new Answer(-1, "Пользователь с таким email уже существует");
            }

            if (await _users.GetSingleAsync(u => u.Login.ToLower().Equals(_user.Login.ToLower())) is not null)
            {
                return new Answer(-1, "Пользователь с таким login уже существует");
            }


            //user.Password = _strMngr.StringSha256HashSault(user.Password, user.Sault);
            _user.Sault = _strMngr.CreateCode(10);

            NaturalPerson? _person = await InsertNaturalPersonAsync(_user, _rights);

            if (_person is null)
                return new Answer(-1, "Ошибка при добавлении нового пользователя");

            _user.NaturalPersonId = _person.KeyId;

            //Добавление записи в таблицу
            if (!await _users.InsertAsync(_user))
                return new Answer(-1, "Ошибка при добавлении нового пользователя");

            //TODO Отправить ссылку на подтверждение аккаунта
            //await CreateCode(ActionTypes.aprove_account, _user.Id);

            return !await UpdateAccessesAsync(_user.Id, _rights) ? new Answer(200, "Пользователь добавлен!") : new Answer(-1, "Не удалось обновить некоторые права доступа пользователя!");

        }

        /// <inheritdoc/>
        public async Task<DBRequestParameter> GetRequestParametersAsync(int _userId) =>
            await _parameters.GetSingleAsync(p => p.UserId.Equals(_userId)) ?? new() { UserId = _userId, RequestParameters = (new RequestResponseCapabilities()).Serialize() };

        /// <inheritdoc/>
        public async Task<Answer> UpdateParametersAsync(DBRequestParameter _requestParameters) =>
           (_requestParameters.Id.Equals(0) ? await _parameters.InsertAsync(_requestParameters) : await _parameters.UpdateAsync(_requestParameters))
            ? new Answer(200, "Параметры запроса обновлены!")
            : new Answer(-1, "При обновлении параметров запроса произошла ошибка!");

        private async Task<NaturalPerson?> InsertNaturalPersonAsync(DBUser _user, List<DBUserAccess> _rights)
        {
            var _orgId = (await _organizations.GetAsync(_user.OrganizationId))!.LegalPersonId;

            NaturalPerson _person = new()
            {
                Created = DateTime.Now,
                LegalPersonId = (long)_orgId,
                EmailAddress = _user.Email,
                Login = _user.Login,
                Password = _user.Password,
                Surname = _user.LastName,
                Name = _user.FirstName,
                Patronymic = _user.MiddleName,
                Caption = $"{_user.LastName} {_user.FirstName}{(string.IsNullOrEmpty(_user.MiddleName) ? "" : $" {_user.MiddleName}")}"
            };

            XDocument _services = new(new XElement("settings", new XElement("service-access")));

            foreach (var _access in _rights.Where(item => item.Access))
            {
                _services.Root?.Element("service-access")?.Add(new XElement("service", new XAttribute("name", _access.ServiceName), new XAttribute("access-type", _access.Access ? "execute" : "none")));
            }

            _person.Settings = _services.ToString();

            try
            {
                await using var bureauUsers = await _bureauUsersFactory.CreateDbContextAsync();

                await bureauUsers.TdNaturalPersons.AddAsync(_person);
                await bureauUsers.SaveChangesAsync();
            }
            catch (Exception _ex)
            {
                Log.Error($"Ошибка сохранения пользователя в BureaUsers {_ex.InnerException}");
                return await Task.FromResult<NaturalPerson?>(null);
            }

            return _person;
        }

        public async Task<List<DBUser>> GetUnaprovedListAsync() => await _users.GetListAsync(u => !u.IsAproved);

    }
}
