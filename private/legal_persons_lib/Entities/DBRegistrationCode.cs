using System.ComponentModel.DataAnnotations.Schema;


namespace legal_persons_lib.Entities
{
    /// <summary>
    /// Пользователь
    /// </summary>
    public class DBRegistrationCode: DBEntity
    {
        /// <summary>
        /// Дата и время
        /// </summary>
        [Column("inserted")] public DateTime Inserted { get; set; }

        /// <summary>
        /// Id организации
        /// </summary>
        [Column("organizations_id")] public int OrganizationId { get; set; }

        /// <summary>
        /// IP-адрес
        /// </summary>
        [Column("code")] public string Code { get; set; } = null!;

    }
}
