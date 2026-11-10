using System.ComponentModel.DataAnnotations.Schema;

namespace legal_persons_lib.Entities
{
    /// <summary>
    /// Код регистрации
    /// </summary>
    public class DBRegistrationCode: DBEntity
    {
        /// <summary>
        /// Дата и время создания
        /// </summary>
        [Column("inserted")] public DateTime Inserted { get; set; }

        /// <summary>
        /// Id организации
        /// </summary>
        [Column("organizations_id")] public int OrganizationId { get; set; }

        /// <summary>
        /// Код регистрации
        /// </summary>
        [Column("code")] public string Code { get; set; } = null!;

    }
}
