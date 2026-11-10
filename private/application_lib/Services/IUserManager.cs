using application_lib.Entities;
using application_lib.Entities.XML.CreditReport.Request;
using legal_persons_lib.Entities;
using legal_persons_lib.Services;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using System.Text.RegularExpressions;


namespace application_lib.Services
{
    public interface IUserManager
    {
        /// <summary>
        /// Получение данных пользователя по серийному номеру сертификата
        /// </summary>
        /// <param name="serialNumber">Серийный номер сертификата</param>
        /// <returns>Пользователь</returns>
        Task<DBUser?> GetUserAsync(string _serialNumber);

        /// <summary>
        /// Получение данных пользователя по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор пользователя</param>
        /// <returns></returns>
        Task<DBUser?> GetAsync(int _id);

        /// <summary>
        /// Получение спика пользователей организации
        /// </summary>
        /// <param name="_orgId">Идентификатор организации</param>
        /// <returns></returns>
        Task<List<DBUser>> GetListAsync(int _orgId);

        /// <summary>
        /// Обновление данных пользователя
        /// </summary>
        /// <param name="user">Пользователь</param>
        /// <returns>Результат обновления данных пользователя</returns>
        Task<Answer> UpdateAsync(DBUser _user, List<DBUserAccess> _rights);

        /// <summary>
        /// Авторизация пользователя
        /// </summary>
        /// <param name="_creditionals">Данные для входа (Логин и пароль)</param>
        /// <returns>Результат</returns>
        Task<Answer> SignAsync(Creditionals _creditionals);
        
        /// <summary>
        /// Восстановление пароля
        /// </summary>
        /// <param name="_email">Email пользователя</param>
        /// <returns>Результат</returns>
        Task<Answer> RestorePasswordAsync(string _email);

        /// <summary>
        /// Создание нового пользователя
        /// </summary>
        /// <param name="user">Пользователь</param>
        /// <returns>Результат добавления пользователя</returns>
        Task<Answer> InsertAsync(DBUser _user, List<DBUserAccess> _rights);

        /// <summary>
        /// Получение прав доступа к сервисам по id
        /// </summary>
        /// <param name="id">Идентификатор пользоавтеля</param>
        /// <returns></returns>
        Task<List<DBUserAccess>> GetAccessesAsync(int id);

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
        private readonly ILogger<UserManager> _logger;
        private readonly IStringManager _strMngr;
        private readonly IRepository<DBUser> _users;
        private readonly IRepository<DBUserAccess> _accesses;
        private readonly IRepository<DBCertificate> _certificates;
        private readonly IRepository<DBRequestParameter> _parameters;
        private readonly IRepository<DBTemporaryCode> _codes;
        private readonly IRepository<DBLogon> _logons;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="users"></param>
        /// <param name="certificates"></param>
        /// <param name="logger"></param>
        public UserManager(IStringManager strMngr, IRepository<DBUser> users, IRepository<DBCertificate> certificates, ILogger<UserManager> logger, IRepository<DBUserAccess> accesses, IRepository<DBRequestParameter> parameters, IRepository<DBTemporaryCode> codes, IRepository<DBLogon> logons)
        {
            _logger = logger;
            _users = users;
            _certificates = certificates;
            _accesses = accesses;
            _parameters = parameters;
            _strMngr = strMngr;
            _codes = codes;
            _logons = logons;
        }

        /// <inheritdoc/>
        public async Task<DBUser?> GetUserAsync(string serialNumber)
        {
            if (string.IsNullOrEmpty(serialNumber))
            {
                _logger.LogWarning("Попытка входа без сертификата");
                return null;
            }

            DBCertificate? certificate = await _certificates.GetSingleAsync(cert => (cert.CertificateSerialNumber ?? string.Empty).ToLower().Equals(serialNumber.ToLower()));

            if (certificate is null)
            {
                _logger.LogWarning($"Сертификат {serialNumber} не найден");
                return null;
            }

            if (certificate.CertificateDateTo < DateTime.Now)
            {
                _logger.LogWarning($"Сертификат {serialNumber} просрочен!");
                return null;
            }


            return await _users.GetAsync(certificate.UserId, "Organization");
        }

        /// <inheritdoc/>
        public async Task<DBUser?> GetAsync(int id) => await _users.GetAsync(id, "Organization");

        /// <inheritdoc/>
        public async Task<List<DBUser>> GetListAsync(int _orgId) => (await _users.GetListAsync()).Where(_user => _user.OrganizationId.Equals(_orgId)).ToList();

        /// <inheritdoc/>
        public async Task<Answer> InsertAsync(DBUser user, List<DBUserAccess> _rights)
        {
            // Проверяем уникальность email
            if (await _users.GetSingleAsync(u => u.Email.Equals(user.Email)) is not null)
            {
                return new Answer(-1, "Пользователь с таким email уже существует");
            }

            //Обновляем данные пользователя
            user.IsAproved = false;
            //user.Password = _strMngr.StringSha256HashSault(user.Password, user.Sault);

            //Добавление записи в таблицу
            if (!await _users.InsertAsync(user))
                return new Answer(-1, "Ошибка при добавлении нового пользователя");

            //TODO Отправить ссылку на подтверждение аккаунта
            //await CreateCode(ActionTypes.aprove_account, _user.Id);

            return !await UpdateAccessesAsync(user.Id, _rights) ? new Answer(200, "Пользователь добавлен!") : new Answer(-1, "Не удалось обновить некоторые права доступа пользователя!");

        }

        /// <inheritdoc/>
        public async Task<Answer> UpdateAsync(DBUser user, List<DBUserAccess> _rights)
        {
            if (user is null) return new Answer(-1, "Ошибка при обновлении данных пользователя");

            if (!await _users.UpdateAsync(user))
                return new Answer(-1, "Ошибка при обновлении данных пользователя");


            return !await UpdateAccessesAsync(user.Id, _rights) ? new Answer(200, "Параметры пользователя обновлены!") : new Answer(-1, "Не удалось обновить некоторые права доступа пользователя!");
        }

        /// <inheritdoc/>
        private async Task<bool> UpdateAccessesAsync(int _id, List<DBUserAccess> _rights)
        {
            _rights.ForEach(service => service.UserId = _id);

            DBUserAccess? service = new ();

            bool _error = false;

            foreach (var access in _rights)
            {
                service = await _accesses.GetSingleAsync(a => a.ServiceId.Equals(access.ServiceId) && a.UserId.Equals(_id));

                if (service is null)
                {
                    if (access.Access)
                        if (!await _accesses.InsertAsync(access))
                            _error = true;
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
        public async Task<List<DBUserAccess>> GetAccessesAsync(int id) => await _accesses.GetListAsync(a => a.UserId.Equals(id));

        /// <inheritdoc/>
        public async Task<DBRequestParameter> GetRequestParametersAsync(int _userId)
        {
            return await _parameters.GetSingleAsync(p => p.UserId.Equals(_userId)) ?? new() { UserId = _userId, RequestParameters = (new RequestResponseCapabilities()).Serialize()};
        }

        /// <inheritdoc/>
        public async Task<Answer> UpdateParametersAsync(DBRequestParameter _requestParameters) =>
           (_requestParameters.Id.Equals(0) ? await _parameters.InsertAsync(_requestParameters) : await _parameters.UpdateAsync(_requestParameters))
            ? new Answer(200, "Параметры запросов обновлены!")
            : new Answer(-1, "При обновлении параметров запросов произошла ошибка!");

        /// <inheritdoc/>>
        public async Task<Answer> SignAsync(Creditionals _creditionals)
        {
            DBUser? _user = null;

            //Поиск пользователя по введенным данным
            try
            {
                _user = await _users.GetSingleAsync(user => user.Login.ToUpper().Equals(_creditionals.Login.ToUpper()), "Organization");
            }
            catch
            {
                /*await _logons.Insert(logon);
                await _logons.Apply();
                return BadRequest(ex.Message);*/
            }

            //Пользователь не найден
            if (_user is null || !_user.Password.Equals(_creditionals.Password))
            {
                /*await _logons.Insert(logon);
                await _logons.Apply();*/
                return new Answer(300, "Неправильный логин или пароль");
            }

            //logon.UserId = _user.Id;

            //Аккаунт заблокирован
            if (!_user.Organization.IsActive || !_user.IsActive)
            {
                /*await _logons.Insert(logon);
                await _logons.Apply();*/
                return new Answer(300, "Аккаунт заблокирован");
            }

            //Аккаунт не подтвержден
            if (!_user.IsAproved)
            {
                /*await _logons.Insert(logon);
                await _logons.Apply();*/
                return new Answer(300, "Аккаунт не подтвержден");
            }

            return new Answer(200, JsonSerializer.Serialize(_user));

        }

        /// <inheritdoc/>>
        public async Task<Answer> RestorePasswordAsync(string _email)
        {
            string pattern = "[.\\-_a-z0-9]+@([a-z0-9][\\-a-z0-9]+\\.)+[a-z]{2,6}";
            Match isMatch = Regex.Match(_email, pattern, RegexOptions.IgnoreCase);

            //Проверяем правильность данных
            if (string.IsNullOrWhiteSpace(_email) || !isMatch.Success)
                return new Answer(300, "Проверьте правильность email");

            //Поиск пользователя по электронной почте
            DBUser? _user = await _users.GetSingleAsync(user => user.Email.ToUpper().Equals(_email.ToUpper()));

            // Пользователь не найден
            if (_user is null)
                return new Answer(300, "Данный адрес электронной почты отсутствует!");

            //Формируем код для пользователя
            string code = _strMngr.CreateCode(50);

            //Записываем в базу данных 
            bool IsInserted = await _codes.InsertAsync(new DBTemporaryCode
            {
                Inserted = DateTime.Now,
                UserId = _user.Id,
                Code = code,
            });

            if (!IsInserted)
                return new Answer(300, "Не удалось создать код для восстановления пароля!");

            //TODO отправить письмо с кодом пользователю
            //_msgSender.SendEmailAsync();

            return new Answer(200, $"На электронную почту {_email} отправлена ссылка для восстановления пароля!");

        }

    }
}
