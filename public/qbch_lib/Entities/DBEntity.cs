
using System.ComponentModel.DataAnnotations.Schema;

namespace qbch_lib.Entities
{
    public class DBEntity
    {
        [Column("key_id")] public int KeyId { get; set; }
    }
}
