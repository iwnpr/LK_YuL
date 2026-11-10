using System.ComponentModel.DataAnnotations.Schema;

namespace legal_persons_lib.Entities.Requests
{
    public class DBRequest: DBEntity
    {
        /// <summary>
        /// Дата создания
        /// </summary>
        [Column("inserted")] public DateTime Inserted { get; set; } = DateTime.Now;

        /// <summary>
        /// Идентификатор организации
        /// </summary>
        [Column("organizations_id")] public int OrganizationId { get; set; }

        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        [Column("users_id")] public int UserId { get; set; }

        /// <summary>
        /// Запрос
        /// </summary>
        [Column("request")] public string Request { get; set; } = string.Empty;

        /// <summary>
        /// Ответ
        /// </summary>
        [Column("response")] public string? Response { get; set; }
    }
}
