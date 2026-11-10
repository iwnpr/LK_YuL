using legal_persons_lib.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace legal_persons_lib.Entities
{
    /// <summary>
    /// Сведения о сертификате пользователя
    /// </summary>
    public class DBCertificate: DBEntity
    {
        /// <summary>
        /// Дата создания
        /// </summary>
        [Column("inserted")] public DateTime Inserted { get; set; }

        /// <summary>
        /// Идентификатор организации
        /// </summary>
        [Column("organizations_id")] public int OrganizationId { get; set; }

        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        [Column("users_id")] public int UserId { get; set; }

        /// <summary>
        /// Сертификат
        /// </summary>
        [JsonIgnore] [Column("certificate")] public string? Сertificate { get; set; }

        /// <summary>
        /// Серийный номер сертификата
        /// </summary>
        [JsonIgnore] [Column("certificate_serial_number")] public string? CertificateSerialNumber { get; set; }

        /// <summary>
        /// Дата создания сертификата
        /// </summary>
        [JsonIgnore] [Column("certificate_date_from")] public DateTime? CertificateDateFrom { get; set; }

        /// <summary>
        /// Годен до
        /// </summary>
        [JsonIgnore] [Column("certificate_date_to")] public DateTime? CertificateDateTo { get; set; }

        /// <summary>
        /// Активность сертификата
        /// </summary>
        [Column("is_active")] public Boolean? IsActive { get; set; }

        /// <summary>
        /// Активность сертификата
        /// </summary>
        [Column("status")] public DBCertificateStatus Status { get; set; }

        /// <summary>
        /// Запрос на серификат
        /// </summary>
        [JsonIgnore] [Column(TypeName = "xml")] public string RequestData { get; set; } = null!;

        /// <summary>
        /// Владелец сертификата
        /// </summary>
        [Column("cert_owner")] public string Owner { get; set; } = null!;

        /// <summary>
        /// Организация
        /// </summary>
        [Column("org_short_name")] public string OrgShortName { get; set; } = null!;

    }

    
}
