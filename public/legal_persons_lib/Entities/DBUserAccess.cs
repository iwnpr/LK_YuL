using System.ComponentModel.DataAnnotations.Schema;

namespace legal_persons_lib.Entities
{
    /// <summary>
    /// Прав доступа пользователя к сервисам 
    /// </summary>
    public class DBUserAccess: DBEntity
    {
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        [Column("users_id")] public int UserId { get; set; }

        /// <summary>
        /// Идентификатор сервиса
        /// </summary>
        [Column("services_id")] public int ServiceId { get; set; }

        /// <summary>
        /// Имя сервиса
        /// </summary>
        [Column("service_name")] public string ServiceName { get; set; } = null!;

        /// <summary>
        /// Описание сервиса
        /// </summary>
        [Column("comment")] public string? Comment { get; set; }

        /// <summary>
        /// Доступность сервиса для организации
        /// </summary>
        [Column("access")] public bool Access { get; set; }

    }
}
