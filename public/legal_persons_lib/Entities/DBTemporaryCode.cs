using System.ComponentModel.DataAnnotations.Schema;

namespace legal_persons_lib.Entities
{
    /// <summary>
    /// Пользователь
    /// </summary>
    public class DBTemporaryCode: DBEntity
    {
        /// <summary>
        /// Дата и время
        /// </summary>
        [Column("inserted")] public DateTime Inserted { get; set; }

        /// <summary>
        /// Id пользователя
        /// </summary>
        [Column("users_id")] public int UserId { get; set; }

        /// <summary>
        /// Код ссылки для смены пароля
        /// </summary>
        [Column("code")] public string Code { get; set; } = null!;

        /// <summary>
        /// Код ссылки для смены пароля
        /// </summary>
        [Column("is_active")] public bool IsActive { get; set; } = true;

    }
}
