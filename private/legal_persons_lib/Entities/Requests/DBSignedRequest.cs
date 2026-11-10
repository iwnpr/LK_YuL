
using System.ComponentModel.DataAnnotations.Schema;

namespace legal_persons_lib.Entities.Requests
{
    public class DBSignedRequest: DBRequest
    {
        /// <summary>
        /// Дата и время обновления
        /// </summary>
        [Column("updated")] public DateTime? Updated { get; set; }

        /// <summary>
        /// Статус обработки запроса
        /// </summary>
        [Column("status")] public int Status { get; set; }

        /// <summary>
        /// Подписанный запрос
        /// </summary>
        [Column("signed_request")] public string? SignedRequest { get; set; }

        /// <summary>
        /// Подписанный ответ
        /// </summary>
        [Column("signed_response")] public string? SignedResponse { get; set; }

    }
}
