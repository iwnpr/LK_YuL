using System.ComponentModel.DataAnnotations.Schema;

namespace qbch_lib.Entities
{
    public class DBUserType: DBEntity
    {
        [Column("description")] public string Description { get; set; } = string.Empty;
    }
}
