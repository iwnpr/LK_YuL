namespace application_lib.Entities
{
    /// <summary>
    /// Ответ от сервисов
    /// </summary>
    public class Answer
    {
        /// <summary>
        /// Код ответа
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// Текст ответа
        /// </summary>
        public string Message { get; set; } = string.Empty;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="code">Код ответа</param>
        /// <param name="message">Текст ответа</param>
        public Answer(int code, string message) => (Code, Message) = (code, message);
         
    }
}
