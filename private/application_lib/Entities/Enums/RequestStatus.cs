namespace application_lib.Entities.Enums
{
    /// <summary>
    /// Статусы запросов
    /// </summary>
    public enum RequestStatus: byte
    {
        /// <summary>
        /// Выполняется
        /// </summary>
        in_process,
        /// <summary>
        /// Информация не найдена
        /// </summary>
        attention,
        /// <summary>
        /// Ошибка при запросе
        /// </summary>
        error,
        /// <summary>
        /// Информация найдена
        /// </summary>
        done
    }
}
