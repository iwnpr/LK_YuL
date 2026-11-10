using legal_persons_lib.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;


namespace legal_persons_lib.Entities.Requests
{
    public class DBRequestOfQBCH : DBSignedRequest
    {
        /// <summary>
        /// Идентификатор ответа
        /// </summary>
        [Column("response_id")] public string ResponseId { get; set; } = string.Empty;

        
        /// <summary>
        /// Идентификатор ответа
        /// </summary>
        [Column("ticket")] public string? Ticket { get; set; }

    }


}
