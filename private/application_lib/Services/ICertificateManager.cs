using application_lib.Entities;
using application_lib.Entities.XML;
using legal_persons_lib.Entities;
using legal_persons_lib.Enums;
using legal_persons_lib.Services;
using Microsoft.Extensions.Configuration;
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
        Task<DBCertificate?> GetAsync(int _id, int _userId);

        /// <summary>
        /// Получение списка сертификатов пользователя
        /// </summary>
        /// <param name="_userId">Идентификатор пользователя</param>
        /// <returns>Список сертификатов</returns>
        Task<List<DBCertificate>> GetListAsync(int _userId);

        /// <summary>
        /// Получение списка сертификатов пользователей
        /// </summary>
        /// <returns>Список сертификатов</returns>
        Task<List<DBCertificate>> GetNotIssuedRequestsListAsync();

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
        private readonly IConfiguration _configuration;
        private readonly ISender _sender;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="certificates"></param>
        /// <param name="configuration"></param>
        /// <param name="sender"></param>
        public CertificateManager(IRepository<DBCertificate> certificates, IConfiguration configuration, ISender sender)
        {
            _certificates = certificates;
            _configuration = configuration;
            _sender = sender;
        }

        /// <inheritdoc/>>
        public async Task<Answer> CancelCertificateRequestAsync(int _id, int _userId = -1)
        {
            DBCertificate? _certificate = await _certificates.GetAsync(_id);

            if (_certificate is null)
                return new Answer(-1, "Запрос на сертификат не найден!");

            _certificate.Status = _userId.Equals(-1) ? DBCertificateStatus.cancelled_by_user : DBCertificateStatus.cancelled_by_admin;
            _certificate.Сertificate = $"<rejection-data mode=\"reject\" request-id=\"{_certificate.Id}\" enrollment-user-id=\"{(_userId.Equals(-1) ? _certificate.UserId : _userId)}\" />";
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
        public async Task<List<DBCertificate>> GetNotIssuedRequestsListAsync() => await _certificates.GetListAsync(c => c.Status.Equals(DBCertificateStatus.requested)) ?? new();

        /// <inheritdoc/>>
        public async Task<Answer> InsertAsync(RequestCertificate _request)
        {
            //Создание сущности для записи в таблицу
            DBCertificate _cert = new()
            {
                UserId = _request.UserId,
                Inserted = DateTime.Now,
                OrganizationId = _request.OrganizationId,
                OrgShortName = _request.Organization,
                Owner = _request.Name,
                RequestData = _request.Serialize(),
                Status = DBCertificateStatus.requested,
                IsActive = true,
            };

            if (!await _certificates.InsertAsync(_cert))
                return new Answer(-1, "Не удалось добавить запрос на сертификат!");

            return new Answer(200, "Запрос на сертификат отправлен в Бюро");

        }

        /// <inheritdoc/>>
        public async Task<Answer> IssueCertificateRequestAsync(int _id, int _userId = -1)
        {
            DBCertificate? _certificate = await _certificates.GetAsync(_id);

            if (_certificate is null)
                return new Answer(-1, "Запрос на сертификат не найден!");

            //Отправляем запрос на сертификат на сервис
            Answer _answer = await _sender.SendByteArrayAsync($"{_configuration.GetSection("Links:CA").Value}", "POST", Encoding.UTF8.GetBytes(XDocument.Parse(_certificate.RequestData).Root!.Value));

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

            //string _serialNumber = _stringMgr.SerialNumberConvert(_cert.SerialNumber);

            XDocument _xml = new(
                new XElement("certificate",
                    new XAttribute("request-id", _certificate.Id),
                    new XAttribute("name", _certificate.Owner),
                    new XAttribute("issued", _cert.NotBefore),
                    new XAttribute("expire", _cert.NotAfter),
                    new XAttribute("serial-number", _cert.SerialNumber),
                    new XAttribute("enrollment-user-id", _userId),
                Environment.NewLine + System.Text.Encoding.UTF8.GetString(_certData)));

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

            return new Answer(200, "Сертификат успешно выдан");

        }
    }
}
