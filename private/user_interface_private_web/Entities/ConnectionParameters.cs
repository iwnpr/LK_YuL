using System.Security.Cryptography.X509Certificates;

namespace user_interface_private_web.Entities
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
        /// Отпечаток сертификата
        /// </summary>
        public string Thumbprint { get; set; } = null!;

        /// <summary>
        /// Браузер
        /// </summary>
        public string UserAgent { get; set; } = null!;
        
        public X509Certificate2? Certificate { get; set; }
       
    }
}
