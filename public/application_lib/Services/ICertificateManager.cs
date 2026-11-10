using application_lib.Entities;
using legal_persons_lib.Entities;
using legal_persons_lib.Enums;
using legal_persons_lib.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using private_lib;
using Serilog;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml.Linq;

namespace application_lib.Services
{
    public interface ICertificateManager
    {
        /// <summary>
        /// Получение параметров сертификата
        /// </summary>
        /// <param name="_id">Идентификатор сертификата</param>
        /// <returns>Параметры сертификата</returns>
        Task<DBCertificate?> GetAsync(int _id, int _user);

        /// <summary>
        /// Получение списка сертификатов пользователя
        /// </summary>
        /// <param name="_userId">Идентификатор пользователя</param>
        /// <returns>Список сертификатов</returns>
        Task<List<DBCertificate>> GetListAsync(int _userId);

        /// <summary>
        /// Добавление нового запроса на сертификат
        /// </summary>
        /// <param name="_request">Параметры запроса сертификта</param>
        /// <returns>Результат выполнения</returns>
        Task<Answer> InsertAsync(RequestCertificate _request);

        /// <summary>
        /// Отмена запроса на сертификат от пользователя
        /// </summary>
        /// <param name="_id">Идентификатор запроса</param>
        /// <returns>Результат выполнения</returns>        
        Task<Answer> CancelCertificateRequestAsync(int _id, int _userId = -1);

        /// <summary>
        /// Получение списка сертификатов пользователей
        /// </summary>
        /// <returns>Список сертификатов</returns>
        Task<List<DBCertificate>> GetNotIssuedRequestsListAsync();

        /// <summary>
        /// Одобрение запроса на сертификат
        /// </summary>
        /// <param name="_id">Идентификатор запроса</param>
        /// <param name="_userId">Идентификатор пользователя</param>
        /// <returns></returns>
        Task<Answer> IssueCertificateRequestAsync(int _id, int _userId = -1);

    }

    public class CertificateManager : ICertificateManager
    {
        private readonly IRepository<DBCertificate> _certificates;
        private readonly IRepository<DBUser> _users;
        private readonly IConfiguration _configuration;
        private readonly ISender _sender;
        private readonly IDbContextFactory<BureauUsersContext> _bureauUsersFactory;
        private readonly IDbContextFactory<BureauWebUIContext> _bureauWebUIFactory;
        private readonly IStringManager _stringManager;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="certificates"></param>
        /// <param name="configuration"></param>
        /// <param name="sender"></param>
        public CertificateManager(IDbContextFactory<BureauWebUIContext> bureauWebUIFactory, IDbContextFactory<BureauUsersContext> bureauUsersFactory, IRepository<DBCertificate> certificates, IConfiguration configuration, ISender sender, IStringManager stringManager, IRepository<DBUser> users)
        {
            _certificates = certificates;
            _configuration = configuration;
            _sender = sender;
            _bureauUsersFactory = bureauUsersFactory;
            _bureauWebUIFactory = bureauWebUIFactory;
            _stringManager = stringManager;
            _users = users;
        }

        /// <inheritdoc/>>
        public async Task<Answer> CancelCertificateRequestAsync(int _id, int _userId = -1)
        {
            DBCertificate? _certificate = await _certificates.GetAsync(_id);

            if (_certificate is null)
                return new Answer(-1, "Запрос на сертификат не найден!");

            _certificate.Status = DBCertificateStatus.cancelled_by_user;
            _certificate.Сertificate = $"<rejection-data mode=\"reject\" request-id=\"{_certificate.Id}\" enrollment-user-id=\"{_certificate.UserId}\" />";
            _certificate.IsActive = false;

            //Обновляем данные в таблице
            if (!await _certificates.UpdateAsync(_certificate))
                return new Answer(-1, "Не удалось отменить запрос на сертификат");

            return new Answer(200, "Запрос на сертификат отменен");
        }

        /// <inheritdoc/>>
        public async Task<DBCertificate?> GetAsync(int _id, int _userId) => await _certificates.GetSingleAsync(cert => cert.Id.Equals(_id) && cert.UserId.Equals(_userId));

        /// <inheritdoc/>>
        public async Task<List<DBCertificate>> GetListAsync(int _userId) => await _certificates.GetListAsync(cert => cert.UserId.Equals(_userId));

        /// <inheritdoc/>>
        public async Task<Answer> InsertAsync(RequestCertificate _request)
        {
            //Создание сущности для записи в таблицу
            DBCertificate _cert = new()
            {
                UserId = _request.UserId,
                Inserted = DateTime.UtcNow,
                //RequestId = _requestOfCertificate.KeyId,
                OrganizationId = _request.OrganizationId,
                OrgShortName = _request.Organization,
                Owner = _request.Name,
                RequestData = _request.Serialize(),
                Status = DBCertificateStatus.requested,
                LegalPersonId = _request.LegalPersonId,
                IsActive = true,
            };

            _request.UserId = (int)_request.NaturalPersonId;
            _request.OrganizationId = (int)_request.LegalPersonId;

            RequestOfCertificate _requestOfCertificate = new RequestOfCertificate()
            {
                Data = _request.Serialize(),
                NaturalPersonId = _request.NaturalPersonId,
                Inserted = DateTime.Now
            };

            try
            {
                await using var bureauWebUI = await _bureauWebUIFactory.CreateDbContextAsync();

                await bureauWebUI.TeRequestsOfCertificates.AddAsync(_requestOfCertificate);

                if (await bureauWebUI.SaveChangesAsync() <= 0)
                {
                    return new Answer(-1, "Не удалось добавить запрос на сертификат!");
                }
            }
            catch (Exception _ex)
            {
                Log.Error($"Ошибка при сохранении данных запроса на сертификат в BureauWebUI: {_ex.Message}");
                return new Answer(-1, "Не удалось добавить запрос на сертификат!");
            }


            _cert.RequestId = _requestOfCertificate.KeyId;

            if (!await _certificates.InsertAsync(_cert))
                return new Answer(-1, "Не удалось добавить запрос на сертификат!");

            /*EmailMessage _message = new()
            {
                Body = $"В личном кабинете ООО \"БКИ КредитИнфо\" добавлен новый запрос на сертификат",
                Subject = "Запрос сертификата",
                BodySubject = "Сертификат пользователя",
                Sender = "noreply@bki-ci.ru",
                Correspondents = _configuration.GetSection("Support").Get<List<EmailCorrespondent>>(),
                TemplateName = "MailSimpleTpl"
            };

            await _sender.SendEmailAsync(_message);*/


            return new Answer(200, "Запрос на сертификат отправлен в Бюро");
        }

        /// <inheritdoc/>>
        public async Task<Answer> IssueCertificateRequestAsync(int _id, int _userId = -1)
        {
            DBCertificate? _certificate = await _certificates.GetAsync(_id);

            if (_certificate is null)
                return new Answer(-1, "Запрос на сертификат не найден!");

            //Отправляем запрос на сертификат на сервис
            Answer _answer = await _sender.SendByteArrayAsync($"{_configuration.GetSection("Links:CA").Value}/submit-request.ashx", "POST", Encoding.UTF8.GetBytes(XDocument.Parse(_certificate.RequestData).Root!.Value));

            if (!_answer.Code.Equals(200))
                return _answer;

            byte[] _certData = Encoding.UTF8.GetBytes(_answer.Message);

            X509Certificate2 _cert;

            try
            {
                _cert = new X509Certificate2(_certData);
            }
            catch
            {
                return new Answer(300, "Не удалось выдать сертификат");
            }

            DBUser? _user = await _users.GetAsync(_certificate.UserId);

            XDocument _xml = new(
                new XElement("certificate",
                    new XAttribute("request-id", _certificate.RequestId),
                    new XAttribute("name", _certificate.Owner),
                    new XAttribute("issued", _cert.NotBefore),
                    new XAttribute("expire", _cert.NotAfter),
                    new XAttribute("serial-number", _cert.SerialNumber),
                    new XAttribute("enrollment-user-id", _user?.NaturalPersonId ?? _userId),
                Environment.NewLine + Encoding.UTF8.GetString(_certData)));


            try
            {
                await using var bureauWebUI = await _bureauWebUIFactory.CreateDbContextAsync();
                await using var bureauUsers = await _bureauUsersFactory.CreateDbContextAsync();

                RequestOfCertificate requestOfCertificate = (await bureauWebUI.TeRequestsOfCertificates.FirstOrDefaultAsync(item => item.KeyId.Equals(_certificate.RequestId)))!;

                await bureauUsers.TdCertificates.AddAsync(new()
                {
                    RequestId = _certificate.RequestId,
                    LegalPersonId = _certificate.LegalPersonId,
                    Data = _xml.ToString(),
                    Active = true,
                    DateFrom = _cert.NotBefore,
                    DateTo = _cert.NotAfter,
                    SerialNumber = _stringManager.SerialNumberConvert(_cert.SerialNumber),
                });

                if (await bureauUsers.SaveChangesAsync() <= 0)
                {
                    return new Answer(300, "Не удалось выдать сертификат");
                }

                requestOfCertificate.Status = 0;
                requestOfCertificate.Certificate = _xml.ToString();
                requestOfCertificate.Issued = _cert.NotBefore;
                requestOfCertificate.Expire = _cert.NotAfter;
               
                bureauWebUI.Entry(requestOfCertificate).State = EntityState.Modified;

                if (await bureauWebUI.SaveChangesAsync() <= 0)
                {
                    return new Answer(300, "Не удалось выдать сертификат");
                }

            }
            catch
            {
                Log.Error($"Ошибка при сохранении данных сертификата в BureauWebUI или BureauUsers");
                return new Answer(300, "Не удалось выдать сертификат");
            }

            _xml.Root!.Attribute("request-id")!.Value = _certificate.Id.ToString();

            //Формируем сущность для обновления данных в таблице
            _certificate.CertificateSerialNumber = _cert.SerialNumber.ToLower();
            _certificate.Status = DBCertificateStatus.issued;
            _certificate.CertificateDateFrom = _cert.NotBefore;
            _certificate.CertificateDateTo = _cert.NotAfter;
            _certificate.Сertificate = _xml.ToString();
            _certificate.IsActive = true;

            //Сохраняем сертификат в таблице и отправляем ответ
            if (!await _certificates.UpdateAsync(_certificate))
                return new Answer(300, "Не удалось выдать сертификат");


            if (_user is not null)
            {
                EmailMessage _message = new()
                {
                    Body = $"Ваш запрос на сертификат № {_certificate.Id} одобрен администратором  ООО \"БКИ КредитИнфо\"",
                    Subject = "Запрос сертификата",
                    BodySubject = "Сертификат пользователя",
                    Sender = "noreply@bki-ci.ru",
                    Correspondents = new() { new() { CorrespondentName = $"{_user.LastName} {_user.FirstName}", Email = _user.Email, SendingType = "to" } },
                    TemplateName = "MailSimpleTpl"
                };

                await _sender.SendEmailAsync(_message);
            }

            return new Answer(200, "Сертификат успешно выдан");

        }

        /// <inheritdoc/>>
        public async Task<List<DBCertificate>> GetNotIssuedRequestsListAsync() => await _certificates.GetListAsync(c => c.Status.Equals(DBCertificateStatus.requested)) ?? new();

    }
}
