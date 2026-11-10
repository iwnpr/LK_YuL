using legal_persons_lib.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;


namespace legal_persons_lib.Entities.Requests
{
    [DBEntityValidation]
    public class DBRequestForGovernmentByUser : DBRequest
    {
         /// <summary>
        /// Дата и время обновления
        /// </summary>
        [Column("updated")] public DateTime? Updated { get; set; }

        /// <summary>
        /// Идентификатор типа
        /// </summary>
        [Column("government_id")] public DBGovernment GovernmentId { get; set; } = DBGovernment.court;

        /// <summary>
        /// Наименование
        /// </summary>
        [Column("government_name")] public string GovernmentName { get; set; } = string.Empty;

        /// <summary>
        /// Номер исходящего
        /// </summary>
        [Column("outgoing_response_id")] public string OutgoingResponseId { get; set; } = string.Empty;

        /// <summary>
        /// Номер входящего
        /// </summary>
        [Column("incoming_request_id")] public string IncomingRequestId { get; set; } = string.Empty;

        /// <summary>
        /// Дата запроса
        /// </summary>
        [Column("request_date")] public DateOnly? RequestDate { get; set; }

        /// <summary>
        /// Дата ответа
        /// </summary>
        [Column("response_date")] public DateOnly? ResponseDate { get; set; }
    }
}
