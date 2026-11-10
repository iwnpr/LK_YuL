using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;


namespace legal_persons_lib.Entities.Requests
{
    public class DBRequestOfBureau : DBSignedRequest
    {
        /// <summary>
        /// Идентификатор ответа
        /// </summary>
        [Column("response_id")] public long ResponseId { get; set; }
    }


}
