using System.ComponentModel.DataAnnotations.Schema;

namespace legal_persons_lib.Entities
{
    public class DBOrganization: DBEntity
    {
        /// <summary>
        /// Идентификатор организации
        /// </summary>
        [Column("legal_person_id")] public long LegalPersonId { get; set; }

        /// <summary>
        /// Время вставки
        /// </summary>
        [Column("inserted")] public DateTime Inserted { get; set; }

        /// <summary>
        /// ИНН
        /// </summary>
        [Column("itn")] public string Itn { get; set; } = null!;
        
        /// <summary>
        /// ОГРН
        /// </summary>
        [Column("psrn")] public string Psrn { get; set; } = null!;
        
        /// <summary>
        /// Полное наименование 
        /// </summary>
        [Column("full_name")] public string FullName { get; set; } = null!;
        
        /// <summary>
        /// Краткое наименование
        /// </summary>
        [Column("short_name")] public string ShortName { get; set; } = null!;
        
        /// <summary>
        /// Форма собственности
        /// </summary>
        [Column("ownership_form")] public string? OwnershipForm { get; set; }
        
        /// <summary>
        /// Блокировка
        /// </summary>
        [Column("is_active")] public bool IsActive { get; set; } = true;
        
        /// <summary>
        /// Дата закрытия
        /// </summary>
        [Column("date_close")] public DateTime? DateClose { get; set; }
        
        /// <summary>
        /// Тип организации
        /// </summary>
        [Column("tr_organization_type_id")] public int OrganizationTypeId { get; set; }
        
        /// <summary>
        /// Тип организации
        /// </summary>
        [Column("organization_type")] public string OrganizationType { get; set; } = null!;

        /// <summary>
        /// ОКПО организации
        /// </summary>
        [Column("okpo")] public string? OKPO { get; set; }
    }
}
