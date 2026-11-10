using System.ComponentModel.DataAnnotations.Schema;

namespace qbch_lib.Entities
{
    public class DBPermission: DBEntity
    {
        [Column("abonent_id")] public int AbonentsKeyId { get; set; }

        [Column("inserted")] public DateTime Inserted { get; set; }

        [Column("service_id")] public int ServicesKeyId { get; set; }

        [Column("is_granted")] public bool IsGranted { get; set; }

    }
}
