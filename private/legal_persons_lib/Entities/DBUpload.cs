using System.ComponentModel.DataAnnotations.Schema;

namespace legal_persons_lib.Entities
{
    public class DBUpload
    {
        /// <summary>
        /// Идентификатор записи (PrimaryKey)
        /// </summary>
        [Column("id")] public long Id { get; set; }
        [Column("upload_id")] public string UploadId { get; set; } = string.Empty;
        [Column("inserted")] public DateTime Inserted { get; set; }
        [Column("users_id")] public long? UserId { get; set; } = -1;
        [Column("organizations_id")] public long? OrganizationId { get; set; } = -1;
        [Column("upload_xml")] public string UploadXML { get; set; } = string.Empty;
        [Column("updated")] public DateTime? Updated { get; set; }
        [Column("status")] public int? Status { get; set; }
        [Column("in_process")] public bool? InProcess { get; set; }
        [Column("reg_result_xml")] public string? RegResultXml { get; set; }
        [Column("upload_result_xml")] public string? UploadResultXml { get; set; }
        [Column("priority")] public Int16? Priority { get; set; }
    }
}
