
namespace application_lib.Entities
{
    /// <summary>
    /// Информация о КиптоПро
    /// </summary>
    public class CryptoPro
    {
        /// <summary>
        /// Срок действия
        /// </summary>
        public string? ValidTo { get; set; }

        /// <summary>
        /// Серийный номер
        /// </summary>
        public string? SerialNumber { get; set; }

        /// <summary>
        /// Дата установки
        /// </summary>
        public string? FirstInstall { get; set; }

        /// <summary>
        /// Тип лицензии
        /// </summary>
        public string? LicType { get; set; }

        /// <summary>
        /// Организация
        /// </summary>
        public string? CompanyName { get; set; }
    }
}
