using System.ComponentModel.DataAnnotations.Schema;

namespace legal_persons_lib.Entities
{
    /// <summary>
    /// Логирование авторизации
    /// </summary>
    public class DBLogon: DBEntity
    {
        /// <summary>
        /// Дата и время
        /// </summary>
        [Column("inserted")] public DateTime Inserted { get; set; }

        /// <summary>
        /// Id пользователя
        /// </summary>
        [Column("users_id")] public long? UserId { get; set; }

        /// <summary>
        /// IP-адрес
        /// </summary>
        [Column("ip_address")] public string IpAddress { get; set; } = null!;
    
    }
}
