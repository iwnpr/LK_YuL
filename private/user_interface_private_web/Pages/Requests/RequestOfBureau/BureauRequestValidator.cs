using System.Text.RegularExpressions;
using application_lib.Entities;

namespace user_interface_private_web.Pages.Requests.RequestOfBureau;

public interface IBureauRequestValidator
{
    Answer ValidateSubject(BureauRequestModel model);
    Answer ValidateConsent(BureauRequestModel model);
}

internal sealed class BureauRequestValidator : IBureauRequestValidator
{
    private static readonly Answer Success = new(200, "Объект успешно прошел валидацию");

    public Answer ValidateSubject(BureauRequestModel model)
    {
        if (model.RequestPurpose.Type == "99" && string.IsNullOrEmpty(model.RequestPurpose.Value))
        {
            return Error("Не заполнено поле Иная цель запроса");
        }

        return model.NaturalPerson is not null
            ? ValidateNaturalPerson(model.NaturalPerson)
            : ValidateLegalPerson(model.LegalPerson);
    }

    public Answer ValidateConsent(BureauRequestModel model)
    {
        var consent = model.Consent;

        if (model.LegalPerson is not null && string.IsNullOrEmpty(consent.LegalPersonAddress))
        {
            return Error("В согласии субъекта введен некорректный адрес субъекта");
        }

        if (!DateTime.TryParse(consent.IssueDate, out var issueDate))
        {
            return Error("Введена некорректная дата выдачи согласия");
        }

        if (!DateTime.TryParse(consent.ExpiryDate, out var expiryDate))
        {
            return Error("Введена некорректная дата окончания действия согласия");
        }

        if (consent.PurposeType == "99" && string.IsNullOrEmpty(consent.OtherPurpose))
        {
            return Error("Не заполнено поле иная цель выдачи согласия");
        }

        if (issueDate > expiryDate)
        {
            return Error("Дата окончания действия согласия не может быть меньше даты выдачи");
        }

        return Success;
    }

    private static Answer ValidateNaturalPerson(NaturalPersonModel person)
    {
        if (!DateTime.TryParse(person.BirthDate, out var birthDate) ||
            birthDate < DateTime.Parse("01.01.1900") ||
            birthDate > DateTime.Now)
        {
            return Error("Введена некорректная дата рождения");
        }

        if (string.IsNullOrEmpty(person.LastName))
        {
            return Error("Фамилия не может быть пустой");
        }

        if (string.IsNullOrEmpty(person.FirstName))
        {
            return Error("Имя не может быть пустым");
        }

        var addressError = ValidateAddresses(person.Addresses, requireRegion: false);
        if (addressError is not null)
        {
            return addressError;
        }

        foreach (var phone in person.Phones)
        {
            if (string.IsNullOrEmpty(phone.Number))
            {
                return Error("Номер не может быть пустым");
            }

            if (!Regex.Match(phone.Number, @"\b\d{10}\b", RegexOptions.IgnoreCase).Success)
            {
                return Error("Номер телефона не соответствует шаблону 9001234567");
            }
        }

        return ValidateDocument(person.Document);
    }

    private static Answer ValidateDocument(IdentificationDocumentModel document)
    {
        if (string.IsNullOrEmpty(document.Number))
        {
            return Error("Номер документа не может быть пустым");
        }

        if (document.Type == "21" && string.IsNullOrEmpty(document.Series))
        {
            return Error("Для данного типа документа серия не может быть пустой");
        }

        if (!DateTime.TryParse(document.IssueDate, out var issueDate) ||
            issueDate < DateTime.Parse("01.01.1900") ||
            issueDate > DateTime.Now)
        {
            return Error("Введена некорректная дата выдачи документа");
        }

        return Success;
    }

    private static Answer ValidateLegalPerson(LegalPersonModel? person)
    {
        if (string.IsNullOrEmpty(person?.FullName))
        {
            return Error("Наименование юридического лица не должно быть пустым");
        }

        if (string.IsNullOrEmpty(person.IndividualTaxpayerNumber))
        {
            return Error("ИНН юридического лица не должен быть пустым");
        }

        if (person.IndividualTaxpayerNumber.Length is < 10 or > 12)
        {
            return Error("ИНН юридического лица должен быть от 10 до 12 цифр");
        }

        if (string.IsNullOrEmpty(person.PrimaryStateRegistrationNumber))
        {
            return Error("ОГРН юридического лица не должен быть пустым");
        }

        if (person.PrimaryStateRegistrationNumber.Length is < 13 or > 15)
        {
            return Error("ОГРН юридического лица должен быть от 13 до 15 цифр");
        }

        return ValidateAddresses(person.Addresses, requireRegion: true) ?? Success;
    }

    private static Answer? ValidateAddresses(IEnumerable<AddressModel> addresses, bool requireRegion)
    {
        foreach (var address in addresses)
        {
            if (requireRegion && address.RegionId == "0")
            {
                return Error("В адресе необходимо выбрать регион");
            }

            if (!string.IsNullOrEmpty(address.DistrictType) && string.IsNullOrEmpty(address.DistrictName))
            {
                return Error("В адресе не заполнено Название района");
            }

            if (!string.IsNullOrEmpty(address.CityType) && string.IsNullOrEmpty(address.CityName))
            {
                return Error("В адресе не заполнено Название города");
            }

            if (!string.IsNullOrEmpty(address.VillageType) && string.IsNullOrEmpty(address.VillageName))
            {
                return Error("В адресе не заполнено населенного пункта");
            }
        }

        return null;
    }

    private static Answer Error(string message) => new(300, message);
}
