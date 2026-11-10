
namespace user_interface_private_web.Entities.Enums
{
    /// <summary>
    /// Статусы запросов
    /// </summary>
    public enum RequestType: byte
    {
        /// <summary>
        /// Госорганы
        /// </summary>
        government,
        /// <summary>
        /// Проверка КИ
        /// </summary>
        check,
        /// <summary>
        /// Загрузка
        /// </summary>
        upload,
        /// <summary>
        /// ЦККИ
        /// </summary>
        ccch,
        /// <summary>
        /// ЦККИ
        /// </summary>
        bureau,
        /// <summary>
        /// КБКИ
        /// </summary>
        qbch
    }
}
