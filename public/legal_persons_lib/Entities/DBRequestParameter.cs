using System.ComponentModel.DataAnnotations.Schema;


namespace legal_persons_lib.Entities
{
    public class DBRequestParameter: DBEntity
    {
        /// <summary>
        /// Дата и время
        /// </summary>
        [Column("inserted")] public DateTime Inserted { get; set; }

        /// <summary>
        /// Id пользователя
        /// </summary>
        [Column("users_id")] public long UserId { get; set; }

        /// <summary>
        /// Параметры сервиса
        /// </summary>
        [Column("request_parameters")] public string RequestParameters { get; set; } = null!;
    }
}
