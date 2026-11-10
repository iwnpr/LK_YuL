using System.Security.Cryptography;
using System.Text;

namespace application_lib.Services
{
    public interface IStringManager
    {
        /// <summary>
        /// Создание кода
        /// </summary>
        /// <param name="_count">Количесвто символов</param>
        /// <returns>Новый код</returns>
        public string CreateCode(byte _count);

        /// <summary>
        /// Преобразование серийного номера в формат 1d-3a-8e...
        /// </summary>
        /// <param name="_serialNumber">Серийный номер</param>
        /// <returns>Преобразованный серийный номер</returns>
        public string SerialNumberConvert(string _serialNumber);

        /// <summary>
        /// Хеширование пароля
        /// </summary>
        /// <param name="password">Пароль</param>
        /// <param name="sault">Соль</param>
        /// <returns>Хешированный пароль</returns>
        public string StringSha256HashSault(string password, string sault);
        
        public string Base64Encode(string value);
        public string Base64Decode(string value);
    }


    public class StringManager : IStringManager
    {
        public string Base64Decode(string base64EncodedData)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var _encoding = Encoding.GetEncoding("windows-1251");

            var base64EncodedBytes = Convert.FromBase64String(base64EncodedData);
            return _encoding.GetString(base64EncodedBytes);
        }

        public string Base64Encode(string value)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var plainTextBytes = Encoding.UTF8.GetBytes(value);
            return Convert.ToBase64String(plainTextBytes);
        }

        /// <inheritdoc/>
        public string CreateCode(byte _count)
        {
            string code = string.Empty;

            Random rnd = new();

            byte i = 0;

            while (i < _count)
            {
                double key = rnd.NextDouble();
                code += Convert.ToChar((byte)(key > 0.667 ? (97 + Math.Round(rnd.NextDouble() * 25, 0)) : key > 0.333 ? (48 + Math.Round(rnd.NextDouble() * 9, 0)) : (65 + Math.Round(rnd.NextDouble() * 25, 0))));
                i++;
            }
            return code;
        }

        /// <inheritdoc/>
        public string SerialNumberConvert(string _serialNumber) =>
            string.Join("-", _serialNumber.Select((x, i) => i)
                  .Where(i => i % 2 == 0)
                  .Select(i => _serialNumber.Substring(i, _serialNumber.Length - i >= 2 ? 2 : _serialNumber.Length - i)));

        /// <inheritdoc/>
        public string StringSha256HashSault(string password, string sault)
        {
            using var alg = SHA256.Create();
            password = string.Join(null, alg.ComputeHash(Encoding.UTF8.GetBytes(password)).Select(x => x.ToString("x2")));
            sault = password = string.Join(null, alg.ComputeHash(Encoding.UTF8.GetBytes(password)).Select(x => x.ToString("x2")));
            password += sault;
            return string.Join(null, alg.ComputeHash(Encoding.UTF8.GetBytes(password)).Select(x => x.ToString("x2")));
        }
    }

}
