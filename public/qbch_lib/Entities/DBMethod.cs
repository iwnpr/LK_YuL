
using System.ComponentModel.DataAnnotations.Schema;

namespace qbch_lib.Entities
{
    public class DBMethod: DBEntity
    {
        [Column("service_name")] public string? ServiceName { get; set; }

        [Column("description")] public string? Description { get; set; }
    }
}
