using System.ComponentModel.DataAnnotations.Schema;

namespace qbch_lib.Entities
{
    /// <summary>
    /// Сертификат абонента
    /// </summary>
    [DBEntityValidate]
    public class DBAbonentCertificate: DBEntity
    {
        /// <summary>
        /// Идентификатор абонента
        /// </summary>
        [Column("abonent_id")] public int AbonentKeyId { get; set; }
        
        [Column("inserted")] public DateTime Inserted { get; set; }

        /// <summary>
        /// Отпечаток сертификата
        /// </summary>
        [Column("thumbprint")] public string Thumbprint { get; set; } = null!;

        /// <summary>
        /// Дата действительности сертификата
        /// </summary>
        [Column("expiration_date")] public DateTime ExpirationDate { get; set; } = DateTime.Now.AddYears(1);

        /// <summary>
        /// Доступность сертификата
        /// </summary>
        [Column("is_active")] public bool? IsActive { get; set; }
    }
}
