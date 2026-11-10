namespace user_interface_public_web.Entities
{
    public class ConnectionParameters
    {
        /// <summary>
        /// IP-адрес
        /// </summary>
        public string IpAddress { get; set; } = null!;

        /// <summary>
        /// Серийный номер сертификата
        /// </summary>
        public string SerialNumber { get; set; } = null!;

        /// <summary>
        /// Браузер
        /// </summary>
        public string UserAgent { get; set; } = null!;
    }
}
