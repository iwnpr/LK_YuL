using application_lib.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace application_lib.Services
{
    /// <summary>
    /// Сервис отправки сообщений (запросов)
    /// </summary>
    public interface ISender
    {


        /// <summary>
        /// Отправка http запроса
        /// </summary>
        /// <param name="url">Адрес</param>
        /// <param name="method">Метод (GET, POST, PUT, DELETE)</param>
        /// <param name="content">Содержимое тела запроса</param>
        /// <returns></returns>
        public Task<Answer> SendStringAsync(string url, string method, string content);

        /// <summary>
        /// Отправка http запроса
        /// </summary>
        /// <param name="url">Адрес</param>
        /// <param name="method">Метод (GET, POST, PUT, DELETE)</param>
        /// <param name="content">Содержимое тела запроса</param>
        /// <returns></returns>
        public Task<Answer> SendByteArrayAsync(string url, string method, byte[] content);

        /// <summary>
        /// Отправка http запроса
        /// </summary>
        /// <param name="url">Адрес</param>
        /// <param name="method">Метод (GET, POST, PUT, DELETE)</param>
        /// <param name="content">Содержимое тела запроса</param>
        /// <returns></returns>
        public Task<Answer> SendStreamAsync(string url, HttpContent content);

        /// <summary>
        /// Отправка email-сообщения
        /// </summary>
        /// <returns></returns>
        public Task<Answer> SendEmailAsync(EmailMessage message);

        public Task<Stream?> GetFileAsync(string url);
    }

    public class Sender : ISender
    {
        private readonly HttpClient _httpClient = new() { Timeout = TimeSpan.FromMilliseconds(100000) };

        private readonly ILogger<Sender> _logger;
        private readonly IConfiguration _configuration;
        private readonly string _url;

        public Sender(ILogger<Sender> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            _url = _configuration.GetSection("Links:Mail")!.Value;
        }

        ///<inheritdoc/>>
        public async Task<Answer> SendEmailAsync(EmailMessage message)
        {
            HttpContent cnt = new StringContent(JsonSerializer.Serialize(message));
            cnt.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            // Отправка запроса
            try
            {
                using HttpResponseMessage httpResponse = await _httpClient.PostAsync(_url, cnt);
                return new Answer((int)httpResponse.StatusCode, await httpResponse.Content.ReadAsStringAsync());

            }
            catch (Exception exception)
            {
                _logger.LogError($"При отправке сообщения произошла ошибка {exception.InnerException}");
                return new Answer(-1, exception.Message);
            }
        }

        ///<inheritdoc/>>
        public async Task<Answer> SendStringAsync(string url, string method, string content)
        {
            HttpContent cnt = new StringContent(content);
            cnt.Headers.ContentType = new MediaTypeHeaderValue("application/xml");

            // Отправка запроса
            try
            {
                using HttpResponseMessage httpResponse =
                   method switch
                   {
                       "GET" => await _httpClient.GetAsync(url),
                       "POST" => await _httpClient.PostAsync(url, cnt),
                       "PUT" => await _httpClient.PutAsync(url, cnt),
                       "DELETE" => await _httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Delete, url) { Content = cnt }),
                       _ => throw new NotImplementedException()
                   };

                return new Answer((int)httpResponse.StatusCode, await httpResponse.Content.ReadAsStringAsync());

            }
            catch (Exception exception)
            {
                return new Answer(-1, exception.Message);
            }

        }

        ///<inheritdoc/>>
        public async Task<Answer> SendByteArrayAsync(string url, string method, byte[] content)
        {
            ByteArrayContent cnt = new (content);
            cnt.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

            // Отправка запроса
            try
            {
                using HttpResponseMessage httpResponse =
                   method switch
                   {
                       "GET" => await _httpClient.GetAsync(url),
                       "POST" => await _httpClient.PostAsync(url, cnt),
                       "PUT" => await _httpClient.PutAsync(url, cnt),
                       "DELETE" => await _httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Delete, url) { Content = cnt }),
                       _ => throw new NotImplementedException()
                   };

                return new Answer((int)httpResponse.StatusCode, await httpResponse.Content.ReadAsStringAsync());

            }
            catch (Exception exception)
            {
                return new Answer(-1, exception.Message);
            }

        }

        public async Task<Stream?> GetFileAsync(string url)
        {
            try
            {
                using HttpResponseMessage httpResponse = await _httpClient.GetAsync(url);

                return  await httpResponse.Content.ReadAsStreamAsync();

            }
            catch (Exception exception)
            {
                _logger.LogError($"Ошибка получения файла: {exception}");

                return null;
            }
        }

        public async Task<Answer> SendStreamAsync(string url, HttpContent content)
        {
            // Отправка запроса
            try
            {
                using HttpResponseMessage httpResponse = await _httpClient.PostAsync(url, content);
                       
                return new Answer((int)httpResponse.StatusCode, await httpResponse.Content.ReadAsStringAsync());
            }
            catch (Exception exception)
            {
                return new Answer(-1, exception.Message);
            }
        }
    }

   
    /// <summary>
    /// Email соообщение
    /// </summary>
    public class EmailMessage
    {
        /// <summary>
        /// Тело письма
        /// </summary>
        [JsonPropertyName("body")]
        public string? Body { get; set; }

        /// <summary>
        /// Заголовок
        /// </summary>
        [JsonPropertyName("bodySubject")]
        public string? BodySubject { get; set; }

        /// <summary>
        /// Тело письма
        /// </summary>
        [JsonPropertyName("subject")]
        public string? Subject { get; set; }

        /// <summary>
        /// Имя шаблона который необходимо использовать
        /// </summary>
        /// <remarks>
        /// Шаблоны хранятся в ресурсах API
        /// </remarks>     
        [Required]
        [JsonPropertyName("templateName")]
        public string TemplateName { get; set; } = null!;

        /// <summary>
        /// Отправитель
        /// </summary>
        [JsonPropertyName("sender")]
        public string? Sender { get; set; }

        /// <summary>
        /// Email сообщения
        /// </summary>
        [JsonPropertyName("correspondents")]
        public List<EmailCorrespondent> Correspondents { get; set; } = new();

    }

    /// <summary>
    /// Получатель email
    /// </summary>
    public class EmailCorrespondent
    {
        /// <summary>
        /// Имя получателя
        /// </summary>
        [JsonPropertyName("correspondentName")]
        public string? CorrespondentName { get; set; }

        /// <summary>
        /// Email получателя
        /// </summary>
        [JsonPropertyName("email")]
        public string? Email { get; set; }

        /// <summary>
        /// Тип отправки:
        ///     To - кому.
        ///     cc - копия.
        ///     bcc - скрытая копия.
        /// </summary>
        [JsonPropertyName("sendingType")]
        public string SendingType { get; set; } = "to";
    }
}
