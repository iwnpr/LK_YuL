using application_lib.Entities.Enums;
using application_lib.Entities.XML.CreditReport.Request;
using System.Xml.Linq;

namespace application_lib.Entities.Records
{
    public record RequestRecord
    {
        /// <summary>
        /// Идентификатор запроса
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime Inserted { get; set; }

        /// <summary>
        /// Идентификатор организации
        /// </summary>
        public string Organization { get; set; }

        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public string User { get; set; }

        /// <summary>
        /// Субъект запроса
        /// </summary>
        public string Subject { get; set; } = string.Empty;

        /// <summary>
        /// Статус запроса
        /// </summary>
        public RequestStatus Status { get; set; }

        public RequestRecord(long id, DateTime inserted, string subject, RequestStatus status, string org, string user)
        {
            Id = id;
            Inserted = inserted;
            Organization = org;
            User = user; 
            Subject = GetRequest(subject);
            Status = status;
        }

        private static string GetRequest(string xml)
        {
            XDocument _request = XDocument.Parse(xml);

            XElement _body = _request.Root!.Element("BODY") ?? _request!.Root!.Element("Запрос")!;

            XElement _subject = 
                _body.Element("NaturalPersonSubject") is not null 
                    ? _body.Element("NaturalPersonSubject")!.Element("Title")! 
                    : _body.Element("LegalPersonSubject") is not null 
                        ? _body.Element("LegalPersonSubject")!.Element("Title")!.Element("Name")!
                        : _body.Element("Contract") is not null 
                            ? _body.Element("Contract")!
                            : _body.Element("Субъект")!.Element("ФИО")!;

            return 
                _body.Element("NaturalPersonSubject") is not null
                    ? $"{_subject.Attribute("LastName")!.Value} {_subject.Attribute("FirstName")!.Value}{(_subject.Attribute("MiddleName")?.Value is null ? string.Empty : $" {_subject.Attribute("MiddleName")!.Value!}")}"
                    : _body.Element("LegalPersonSubject") is not null
                        ? $"{_subject.Attribute("FullName")?.Value ?? _subject.Attribute("ShortName")?.Value ?? "-"}"
                        : _body.Element("Contract") is not null
                            ? $"{_subject.Element("Uid")?.Value ?? "-"}"
                            : $"{_subject.Element("Фамилия")?.Value} {_subject.Element("Имя")!.Value}{(_subject.Element("Отчество")?.Value is null ? string.Empty : $" {_subject.Element("Отчество")!.Value!}")}";
            }


    }
}
