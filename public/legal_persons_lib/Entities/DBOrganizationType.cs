using System.ComponentModel.DataAnnotations.Schema;


namespace legal_persons_lib.Entities
{
    public class DBOrganizationType: DBEntity
    {
        /// <summary>
        /// Роль
        /// </summary>
        [Column("organization_type")] public string OrgType { get; set; } = null!;

        /// <summary>
        /// Описание
        /// </summary>
        [Column("comment")] public string? Comment { get; set; }

    }
}
