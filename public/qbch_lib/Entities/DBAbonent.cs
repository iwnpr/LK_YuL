
using System.ComponentModel.DataAnnotations.Schema;

namespace qbch_lib.Entities
{
    [DBEntityValidate]
    public class DBAbonent: DBEntity
    {
        [Column("user_type")] public int UserTypeId { get; set; }

        [Column("full_name")] public string FullName { get; set; } = null!;

        [Column("inserted")] public DateTime Inserted { get; set; }

        [Column("short_name")] public string ShortName { get; set; } = null!;

        [Column("inn")] public string Inn { get; set; } = null!;

        [Column("ogrn")] public string Ogrn { get; set; } = null!;
        
        [Column("email")] public string? Email { get; set; }
    }
}
