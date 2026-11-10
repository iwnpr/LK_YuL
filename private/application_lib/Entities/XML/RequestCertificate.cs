using System.Xml.Serialization;

namespace application_lib.Entities.XML
{
    /// <summary>
    /// Запрос на сертификат
    /// </summary>
    [XmlType(TypeName = "certificate-request")]
    public class RequestCertificate
    {
        /// <summary>
        /// Владелец сертификата
        /// </summary>
        [XmlAttribute("name")] public string Name { get; set; } = null!;

        /// <summary>
        /// Адрес элетронной потчы
        /// </summary>
        [XmlAttribute("e-mail")] public string Email { get; set; } = null!;

        /// <summary>
        /// Короткое имя организации
        /// </summary>
        [XmlAttribute("organization")] public string Organization { get; set; } = null!;

        /// <summary>
        /// Код страны
        /// </summary>
        [XmlAttribute("country-code")] public string? Code { get; set; }

        /// <summary>
        /// Город владельца
        /// </summary>
        [XmlAttribute("city")] public string? City { get; set; }

        /// <summary>
        /// Алгоритм
        /// </summary>
        [XmlAttribute("algorithm")] public string Algorithm { get; set; } = "ГОСТ Р 34.10-2012";

        /// <summary>
        /// Идентификатор организации
        /// </summary>
        [XmlAttribute("organization-id")] public int OrganizationId { get; set; }

        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        [XmlAttribute("user-id")] public int UserId { get; set; }

        /// <summary>
        /// Текст запроса сертификата
        /// </summary>
        [XmlText] public string Data { get; set; } = null!;

    }
}
