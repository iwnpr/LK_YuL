using System.ComponentModel.DataAnnotations.Schema;


namespace legal_persons_lib.Entities
{
    public class DBService: DBEntity
    {
        /// <summary>
        /// Имя сервиса
        /// </summary>
        [Column("service_name")] public string ServiceName { get; set; } = null!;

        /// <summary>
        /// Параметры сервиса
        /// </summary>
        [Column("request_parameters")] public string RequestParameters { get; set; } = null!;

        /// <summary>
        /// Описание сервиса
        /// </summary>
        [Column("comment")] public string? Comment { get; set; }
    }
}
