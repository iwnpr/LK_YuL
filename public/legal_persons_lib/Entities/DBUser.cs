using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace legal_persons_lib.Entities
{
    /// <summary>
    /// Пользователь
    /// </summary>
    [DBEntityValidation]
    public class DBUser: DBEntity
    {
        /// <summary>
        /// Логин
        /// </summary>
        [Column("login")] public string Login { get; set; } = null!;
        
        /// <summary>
        /// Пароль
        /// </summary>
        [Column("password")] public string Password { get; set; } = null!;
        
        /// <summary>
        /// Электронная почта
        /// </summary>
        
        [Column("email")] public string Email { get; set; } = null!;
        
        /// <summary>
        /// Фамилия
        /// </summary>
        [Column("last_name")] public string LastName { get; set; } = null!;
        
        /// <summary>
        /// Имя
        /// </summary>
        [Column("first_name")] public string FirstName { get; set; } = null!;
        
        /// <summary>
        /// Отчество
        /// </summary>
        [Column("middle_name")] public string? MiddleName { get; set; }
        
        /// <summary>
        /// Телефон
        /// </summary>
        [Column("phone")] public string? Phone { get; set; }
        
        /// <summary>
        /// Id организации
        /// </summary>
        [Column("organization_id")] public int OrganizationId { get; set; }

        /// <summary>
        /// Активность
        /// </summary>
        [Column("is_active")] public bool IsActive { get; set; }
        
        /// <summary>
        /// Подтверждение
        /// </summary>
        [Column("is_approved")] public bool IsAproved { get; set; }

        /// <summary>
        /// Идентификатор из td_NaturalPersons
        /// </summary>
        [Column("natural_person_id")] public long NaturalPersonId { get; set; }

        /// <summary>
        /// Организация пользователя
        /// </summary>
        public DBOrganization Organization { get; set; } = null!;

        /// <summary>
        /// Организация пользователя
        /// </summary>
        [Column("sault")] public string Sault { get; set; } = null!;

    }
}
