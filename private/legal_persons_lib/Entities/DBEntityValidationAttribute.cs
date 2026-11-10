using legal_persons_lib.Entities.Requests;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;


namespace legal_persons_lib.Entities
{
    internal class DBEntityValidationAttribute: ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is DBUser user)
            {
                if (!Regex.Match(user.Login, "^[A-Za-z][A-Za-z0-9_]{3,20}$", RegexOptions.IgnoreCase).Success)
                {
                    ErrorMessage = "Логин не соответствует требованиям: 1) Состоит из латинских букв, цифр; 2) Начинается с латинской буквы; 3) Не менее трех символов"  ;
                    return false;
                }

                if (/*!Regex.Match(user.Password, "(?=.*[0-9])(?=.*[!@#$%^&*])(?=.*[a-z])(?=.*[A-Z])[0-9!@#$%^&*a-zA-Z]{8,}", RegexOptions.IgnoreCase).Success*/user.Password.Length < 6)
                {
                    ErrorMessage = "Пароль не соответствует требованиям надежности: 1) Длина более 8 символов";
                    return false;
                }
                
                if (!Regex.Match(user.Email, "[.\\-_a-z0-9]+@([a-z0-9][\\-a-z0-9]+\\.)+[a-z]{2,6}", RegexOptions.IgnoreCase).Success)
                {
                    ErrorMessage = "Адрес электронной почты некорректный";
                    return false;
                }

                if (!string.IsNullOrEmpty(user.Phone) && !Regex.Match(user.Phone, "[.\\-_a-z0-9]+@([a-z0-9][\\-a-z0-9]+\\.)+[a-z]{2,6}", RegexOptions.IgnoreCase).Success)
                {
                    ErrorMessage = "Номер телефона должен соответствовать шаблону +7(900)111-11-11";
                    return false;
                }

                if (string.IsNullOrEmpty(user.LastName))
                {
                    ErrorMessage = "Фамилия не должна быть пустой";
                    return false;
                }

                if (string.IsNullOrEmpty(user.LastName))
                {
                    ErrorMessage = "Имя не должно быть пустым";
                    return false;
                }

                return true;
            }

            if (value is DBOrganization organization)
            {
                if (string.IsNullOrEmpty(organization.Itn))
                {
                    ErrorMessage = "Не заполнен ИНН организации";
                    return false;
                }

                if (string.IsNullOrEmpty(organization.Psrn))
                {
                    ErrorMessage = "Не заполнен ОГРН организации";
                    return false;
                }
                if (string.IsNullOrEmpty(organization.FullName))
                {
                    ErrorMessage = "Не заполнено полное наименование организации";
                    return false;
                }
                if (string.IsNullOrEmpty(organization.ShortName))
                {
                    ErrorMessage = "Не заполнено краткое наименование организации";
                    return false;
                }

                return true;
            }

            if (value is DBRequestForGovernmentByUser request)
            {
                if (string.IsNullOrEmpty(request.GovernmentName))
                {
                    ErrorMessage = "Наименование учреждения не может быть пустым";
                    return false;
                }

                if (string.IsNullOrEmpty(request.IncomingRequestId))
                {
                    ErrorMessage = "Номер входящего документа не может быть пустым";
                    return false;
                }

                if (string.IsNullOrEmpty(request.OutgoingResponseId))
                {
                    ErrorMessage = "Номер исходящего документа не может быть пустым";
                    return false;
                }

                if (!DateOnly.TryParse(request.RequestDate.ToString(), out _))
                {
                    ErrorMessage = "Введена некорректная дата регистрации";
                    return false;
                }
                
                if (!DateOnly.TryParse(request.ResponseDate.ToString(), out _))
                {
                    ErrorMessage = "Введена некорректная дата запроса";
                    return false;
                }
            }

            return true;
        }

    }
}
