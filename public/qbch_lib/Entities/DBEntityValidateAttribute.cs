using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace qbch_lib.Entities
{
    internal class DBEntityValidateAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is DBAbonent _abonent)
            {
                if (string.IsNullOrEmpty(_abonent.Inn))
                {
                    ErrorMessage = "ИНН абонента не может быть пустым";
                    return false;
                }

                if (string.IsNullOrEmpty(_abonent.Ogrn))
                {
                    ErrorMessage = "ОГРН (ОГРНИП) абонента не может быть пустым";
                    return false;
                }

                if (string.IsNullOrEmpty(_abonent.FullName))
                {
                    ErrorMessage = "Полное наименование абонента является обязательным";
                    return false;
                }

                if (string.IsNullOrEmpty(_abonent.ShortName))
                {
                    ErrorMessage = "Краткое наименование абонента является обязательным";
                    return false;
                }
            }

            if (value is DBAbonentCertificate _certificate)
            {
                if (!Regex.Match(_certificate.Thumbprint, "^[a-zA-Z0-9]+$", RegexOptions.IgnoreCase).Success)
                {
                    ErrorMessage = "Введен некорректный отпечаток сертификата абонента";
                    return false;
                }

                if (!DateTime.TryParse(_certificate.ExpirationDate.ToString(), out DateTime expired))
                {
                    ErrorMessage = "Введена некорректная дата действительности сертификата";
                    return false;
                }

                if (expired < DateTime.Now/* && _certificate.KeyId.Equals(0)*/)
                {
                    ErrorMessage = "Дата действительности сертификата не может быть меньше текущей";
                    return false;
                }
            }

            return true;
        }

    }
}
