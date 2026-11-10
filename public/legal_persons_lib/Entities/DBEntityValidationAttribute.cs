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
                if (!Regex.Match(user.Login, "^[A-Za-z][A-Za-z0-9_.-]{2,20}$", RegexOptions.IgnoreCase).Success)
                {
                    ErrorMessage = "Логин не соответствует требованиям: \n 1) Состоит из латинских букв, цифр; \n 2) Начинается с латинской буквы; \n 3) Не менее трех символов";
                    return false;
                }

                if (/*!Regex.IsMatch(user.Password, "(?=.*[0-9])(?=.*[!@#$%^&*])(?=.*[a-z])(?=.*[A-Z])[0-9!@#$%^&*a-zA-Z]{6,}", RegexOptions.IgnoreCase)*/user.Password.Length < 6)
                {
                    ErrorMessage = "Пароль не соответствует требованиям: \n 1) Длина не менее 6 символов";
                    return false;
                }
                
                if (!Regex.Match(user.Email, "[.\\-_a-z0-9]+@([a-z0-9][\\-a-z0-9]+\\.)+[a-z]{2,6}", RegexOptions.IgnoreCase).Success)
                {
                    ErrorMessage = "Адрес электронной почты некорректный";
                    return false;
                }


                if (!string.IsNullOrEmpty(user.Phone) && !Regex.IsMatch(user.Phone, "[0-9]{7,10}", RegexOptions.IgnoreCase))
                {
                    ErrorMessage = "Номер телефона должен соответствовать шаблону 9001111111";
                    return false;
                }

                if (string.IsNullOrEmpty(user.LastName))
                {
                    ErrorMessage = "Фамилия не должна быть пустой";
                    return false;
                }

                if (string.IsNullOrEmpty(user.FirstName))
                {
                    ErrorMessage = "Имя не должно быть пустым";
                    return false;
                }
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
            }

            return true;
        }

    }
}
