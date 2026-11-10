using application_lib.Entities.XML.CreditReport.Request;
using application_lib.Entities.XML.QBCH;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace application_lib.Entities
{
    internal class EntityValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {

            if (value is RequestNaturalPersonSubject _subject)
            {
                if (!DateTime.TryParse(_subject.BirthDate, out var _birth))
                {
                    ErrorMessage = "Введена некорректная дата рождения";
                    return false;
                }

                if (_birth < DateTime.Parse("01.01.1900") || _birth > DateTime.Now)
                {
                    ErrorMessage = "Введена некорректная дата рождения";
                    return false;
                }

                if (string.IsNullOrEmpty(_subject.Title?.LastName))
                {
                    ErrorMessage = "Фамилия не может быть пустой";
                    return false;
                }

                if (string.IsNullOrEmpty(_subject.Title?.FirstName))
                {
                    ErrorMessage = "Имя не может быть пустым";
                    return false;
                }

                foreach (RequestAddress _item in _subject.Addresses)
                {
                    /*if (_item.Region.ID.Equals("0"))
                    {
                        ErrorMessage = "В адресе необходимо выбрать регион";
                        return false;
                    }*/

                    if (!string.IsNullOrEmpty(_item.District.Ext) && (string.IsNullOrEmpty(_item.District.Caption)))
                    {
                        ErrorMessage = "В адресе не заполнено Название района";
                        return false;
                    }

                    if (!string.IsNullOrEmpty(_item.City.Ext) && (string.IsNullOrEmpty(_item.City.Caption)))
                    {
                        ErrorMessage = "В адресе не заполнено Название города";
                        return false;
                    }

                    if (!string.IsNullOrEmpty(_item.Village.Ext) && (string.IsNullOrEmpty(_item.Village.Caption)))
                    {
                        ErrorMessage = "В адресе не заполнено населенного пункта";
                        return false;
                    }
                }

                foreach (RequestPhone _item in _subject.Phones)
                {
                    if (string.IsNullOrEmpty(_item.Number))
                    {
                        ErrorMessage = "Номер не может быть пустым";
                        return false;
                    }

                    if (!Regex.Match(_item.Number, @"\b\d{10}\b", RegexOptions.IgnoreCase).Success)
                    {
                        ErrorMessage = "Номер телефона не соответствует шаблону 9001234567";
                        return false;
                    }
                }
            }

            if (value is RequestIdentificationDocument _document)
            {
                List<string> _types = new() { "21" };

                if (string.IsNullOrEmpty(_document.DocNum))
                {
                    ErrorMessage = "Номер документа не может быть пустым";
                    return false;
                }

                if (_types.Contains(_document.DocTypeID) && string.IsNullOrEmpty(_document.DocSer))
                {
                    ErrorMessage = "Для данного типа документа серия не может быть пустой";
                    return false;
                }

                if (!DateTime.TryParse(_document.DocDate, out var _date))
                {
                    ErrorMessage = "Введена некорректная дата выдачи документа";
                    return false;
                }

                if (_date < DateTime.Parse("01.01.1900") || _date > DateTime.Now)
                {
                    ErrorMessage = "Введена некорректная дата выдачи документа";
                    return false;
                }

            }

            if (value is RequestLegalPersonSubject _legal)
            {
                if (string.IsNullOrEmpty(_legal.Title?.Name?.FullName))
                {
                    ErrorMessage = "Наименование юридического лица не должно быть пустым";
                    return false;
                }

                if (string.IsNullOrEmpty(_legal.Title?.IndividualTaxpayerNumber))
                {
                    ErrorMessage = "ИНН юридического лица не должен быть пустым";
                    return false;
                }

                if (_legal.Title?.IndividualTaxpayerNumber.Length < 10 || _legal.Title?.IndividualTaxpayerNumber.Length > 12)
                {
                    ErrorMessage = "ИНН юридического лица должен быть от 10 до 12 цифр";
                    return false;
                }

                if (string.IsNullOrEmpty(_legal.Title?.PrimaryStateRegistrationNumber))
                {
                    ErrorMessage = "ОГРН юридического лица не должен быть пустым";
                    return false;
                }

                if (_legal.Title?.PrimaryStateRegistrationNumber.Length < 13 || _legal.Title?.PrimaryStateRegistrationNumber.Length > 15)
                {
                    ErrorMessage = "ОГРН юридического лица должен быть от 13 до 15 цифр";
                    return false;
                }

                foreach (RequestAddress _item in _legal.Addresses)
                {
                    if (_item.Region.ID.Equals("0"))
                    {
                        ErrorMessage = "В адресе необходимо выбрать регион";
                        return false;
                    }

                    if (!string.IsNullOrEmpty(_item.District.Ext) && (string.IsNullOrEmpty(_item.District.Caption)))
                    {
                        ErrorMessage = "В адресе не заполнено Название района";
                        return false;
                    }

                    if (!string.IsNullOrEmpty(_item.City.Ext) && (string.IsNullOrEmpty(_item.City.Caption)))
                    {
                        ErrorMessage = "В адресе не заполнено Название города";
                        return false;
                    }

                    if (!string.IsNullOrEmpty(_item.Village.Ext) && (string.IsNullOrEmpty(_item.Village.Caption)))
                    {
                        ErrorMessage = "В адресе не заполнено населенного пункта";
                        return false;
                    }
                }
            }

            if (value is RequestConsent _consent)
            {
                if (_consent.LegalPersonSubject is not null && string.IsNullOrEmpty(_consent.LegalPersonSubject.Address))
                {
                    ErrorMessage = "В согласии субъекта введен некорректный адрес субъекта";
                    return false;
                }

                if (!DateTime.TryParse(_consent.IssueDate, out _))
                {
                    ErrorMessage = "Введена некорректная дата выдачи согласия";
                    return false;
                }

                if (!DateTime.TryParse(_consent.ExpiryDate, out _))
                {
                    ErrorMessage = "Введена некорректная дата окончания действия согласия";
                    return false;
                }

                if (_consent.Purpose.Equals("99") && string.IsNullOrEmpty(_consent.OtherPurposeAsText))
                {
                    ErrorMessage = "Не заполнено поле иная цель выдачи согласия";
                    return false;
                }

                _ = DateTime.TryParse(_consent.IssueDate, out var _issueDate);
                _ = DateTime.TryParse(_consent.ExpiryDate, out var _expiryDate);

                if (_issueDate > _expiryDate)
                {
                    ErrorMessage = "Дата окончания действия согласия не может быть меньше даты выдачи";
                    return false;
                }
            }

            if (value is Contract _contract)
            {
                if (string.IsNullOrEmpty(_contract.LegalPersonId))
                {
                    ErrorMessage = "Необходимо заполнить идентификатор организации";
                    return false;
                }

                if (string.IsNullOrEmpty(_contract.Uid))
                {
                    ErrorMessage = "Необходимо заполнить UID договора";
                    return false;
                }

                if (!Regex.Match(_contract.Uid!, "[\\da-fA-F]{8}-([\\da-fA-F]{4}-)(1[\\da-fA-F]{3}-)([8-9a-bA-B][\\da-fA-F]{3}-)[\\da-fA-F]{12}-[\\da-fA-F]", RegexOptions.IgnoreCase).Success)
                {
                    ErrorMessage = "Uid договора не соответствует формату";
                    return false;
                }

            }

            if (value is RequestAMP _qbch)
            {
                if (string.IsNullOrEmpty(_qbch.Request.Subject.Initials.LastName))
                {
                    ErrorMessage = "Фамилия субъекта не может быть пустой";
                    return false;
                }

                if (string.IsNullOrEmpty(_qbch.Request.Subject.Initials.FirstName))
                {
                    ErrorMessage = "Имя субъекта не может быть пустым";
                    return false;
                }

                if (!DateTime.TryParse(_qbch.Request.Subject.BirthDate, out var _birth))
                {
                    ErrorMessage = "Введена некорректная дата рождения";
                    return false;
                }

                if (_birth < DateTime.Parse("01.01.1900") || _birth > DateTime.Now)
                {
                    ErrorMessage = "Введена некорректная дата рождения";
                    return false;
                }

                List<string> _types = new() { "21" };

                if (string.IsNullOrEmpty(_qbch.Request.Subject.IdentityDocument.Number))
                {
                    ErrorMessage = "Номер документа не может быть пустым";
                    return false;
                }

                if (_types.Contains(_qbch.Request.Subject.IdentityDocument.Code) && string.IsNullOrEmpty(_qbch.Request.Subject.IdentityDocument.Seria))
                {
                    ErrorMessage = "Для данного типа документа серия не может быть пустой";
                    return false;
                }

                if (!DateTime.TryParse(_qbch.Request.Subject.IdentityDocument.DocDate, out var _date))
                {
                    ErrorMessage = "Введена некорректная дата выдачи документа";
                    return false;
                }

                if (_date < DateTime.Parse("01.01.1900") || _date > DateTime.Now)
                {
                    ErrorMessage = "Введена некорректная дата выдачи документа";
                    return false;
                }

                if (_qbch.Thumbprint.Equals("-"))
                {
                    ErrorMessage = "Выбран некорректный сертификат";
                    return false;
                }


                if (_qbch.Request.Consent.ConsentExpiration.Equals("3"))
                {
                    if (!DateTime.TryParse(_qbch.Request.Consent.Obligation.Date, out _date) || _date < DateTime.Parse("01.01.1900") || _date > DateTime.Now)
                    {
                        ErrorMessage = "Введена некорректная дата договора";
                        return false;
                    }
                }

                if (new List<string>() { "1", "2", "3", "4", "5", "10", "11", "12", "13", "14", "15" }.Contains(_qbch.Request.Purpose.Code))
                {
                    if (!double.TryParse(_qbch.Request.Amount.Text, out var _))
                        {
                        ErrorMessage = "Введена некорректная сумма";
                        return false;
                    }
                }

                if (!_qbch.Request.Consent.Purpose.Code.Equals(_qbch.Request.Purpose.Code))
                {
                    ErrorMessage = "Цель запроса не соответствует цели согласия";
                    return false;
                }
            }

            return true;
        }

    }
}
