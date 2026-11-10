namespace user_interface_private_web.Entities
{
    public class FetchAnswer
    {
        /// <summary>
        /// Код ответа
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// Текст ответа
        /// </summary>
        public byte[] Message { get; set; } = null!;

    }
}
