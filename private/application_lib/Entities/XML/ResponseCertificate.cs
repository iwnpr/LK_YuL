using System.Xml.Serialization;

namespace application_lib.Entities.XML
{
    [XmlType(TypeName = "certificate")]
    public class ResponseCertificate
    {
        /// <summary>
        /// Номер запроса сертификата
        /// </summary>
        [XmlAttribute("request-id")] public int Id { get; set; }

        /// <summary>
        /// Владелец сертификата
        /// </summary>
        [XmlAttribute("name")] public string Name { get; set; } = null!;

        /// <summary>
        /// Время выдачи
        /// </summary>
        [XmlAttribute("issued")] public string Issued { get; set; } = null!;

        /// <summary>
        /// Действителен до
        /// </summary>
        [XmlAttribute("expired")] public string Expired { get; set; } = null!;

        /// <summary>
        /// Серийный номер сертификата
        /// </summary>
        [XmlAttribute("serial-number")] public string SerialNumber { get; set; } = null!;

        /// <summary>
        /// Идентификатор администратора
        /// </summary>
        [XmlAttribute("enrollment-user-id")] public int EnrollmentUserId { get; set; }

        /// <summary>
        /// Текст сертификата
        /// </summary>
        [XmlText] public string Data { get; set; } = null!;

    }
}
