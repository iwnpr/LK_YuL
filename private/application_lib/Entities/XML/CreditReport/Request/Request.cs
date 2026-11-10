using System.ComponentModel.DataAnnotations;
using System.Xml;
using System.Xml.Serialization;

namespace application_lib.Entities.XML.CreditReport.Request
{
    /// <summary>
    /// Запрос
    /// </summary>
    [XmlType(TypeName = "REQUEST")]
    [EntityValidation]
    public class Request
    {
        /// <summary>
        /// Версия формата (платформы) запроса и ответа
        /// </summary>
        [XmlAttribute("version")] public string Version { get; set; } = "10.00";

        /// <summary>
        /// Заголовок запроса
        /// </summary>
        [XmlElement("HEADER")] public RequestHeader Header { get; set; } = null!;

        /// <summary>
        /// Основная часть запроса
        /// </summary>
        [XmlElement("BODY")] public RequestBody Body { get; set; } = null!;
    }

    /// <summary>
    /// Заголовок запроса
    /// </summary>
    [XmlType(TypeName = "HEADER")]
    public class RequestHeader
    {
        /// <summary>
        /// Сведения о пользователе, направляющем запрос
        /// </summary>
        [XmlElement("user")] public RequestUser User { get; set; } = null!;

        /// <summary>
        /// Дата запроса
        /// </summary>
        [XmlElement("request_date")] public string RequestDate { get; set; } = DateTime.Now.ToString("dd.mm.yyyy");

    }

    /// <summary>
    /// Сведения о пользователе, направляющем запрос
    /// </summary>
    [XmlType(TypeName = "user")]
    public class RequestUser
    {
        /// <summary>
        /// Идентификатор пользователя, присвоенный администратором Бюро
        /// </summary>
        [XmlElement("user_id")] public string UserId { get; set; } = string.Empty;

        /// <summary>
        /// Дополнительный идентификатор пользователя (используется, если пользователь - провайдер запросов)
        /// </summary>
        [XmlElement("external_id")] public string? EternalID { get; set; }

        /// <summary>
        /// Дополнительный идентификатор пользователя (используется, если пользователь - провайдер запросов)
        /// </summary>
        [XmlElement("user_code")] public string UserCode { get; set; } = string.Empty;

        /// <summary>
        /// Сведения о пользователе - юридическом лице 
        /// </summary>
        [XmlElement("user_legal_entity")] public RequestUserLegalEntity UserLegalEntity { get; set; } = new();

    }

    /// <summary>
    /// Сведения о пользователе - юридическом лице
    /// </summary>
    [XmlType(TypeName = "user_legal_entity")]
    public class RequestUserLegalEntity
    {
        /// <summary>
        /// Признак регистрации юридического лица в РФ
        /// </summary>
        [XmlElement("registered_in_rf")] public byte RegisteredInRf { get; set; } = 1;

        /// <summary>
        /// Сведения о наименовании пользователя
        /// </summary>
        [XmlElement("user_name")] public RequestUserName UserName { get; set; } = new();

        /// <summary>
        /// Сведения о регистрационном номере пользователя
        /// </summary>
        [XmlElement("user_psrn")] public RequestUserPSRN UserPSRN { get; set; } = new();

        /// <summary>
        /// Идентификатор LEI юридического лица
        /// </summary>
        [XmlElement("lei")] public string? LEI { get; set; }

        /// <summary>
        /// Сведения о номере налогоплательщика - пользователя
        /// </summary>
        [XmlElement("user_itn")] public RequestUserITN UserITN { get; set; } = new();
    }


    /// <summary>
    /// Сведения о наименовании пользователя
    /// </summary>
    [XmlType(TypeName = "user_name")]
    public class RequestUserName
    {
        /// <summary>
        /// Полное наименование
        /// </summary>
        [XmlElement("full_name")] public string FullName { get; set; } = string.Empty;

        /// <summary>
        /// Сокращенное наименование
        /// </summary>
        [XmlElement("short_name")] public string? ShortName { get; set; }

        /// <summary>
        /// Иное наименование
        /// </summary>
        [XmlElement("other_name")] public string? OtherName { get; set; }

    }

    /// <summary>
    /// Сведения о регистрационном номере пользователя
    /// </summary>
    [XmlType(TypeName = "user_psrn")]
    public class RequestUserPSRN
    {
        /// <summary>
        /// Код регистрационного номера
        /// </summary>
        [XmlElement("psrn_code")] public string PSRNCode { get; set; } = "1";

        /// <summary>
        /// Регистрационный номер
        /// </summary>
        [XmlElement("psrn")] public string? PSRN { get; set; } = string.Empty;

    }

    /// <summary>
    /// Сведения о номере налогоплательщика - пользователя
    /// </summary>
    [XmlType(TypeName = "user_itn")]
    public class RequestUserITN
    {
        /// <summary>
        /// Код номера налогоплательщика
        /// </summary>
        [XmlElement("itn_code")] public string ItnCode { get; set; } = "1";

        /// <summary>
        /// Номер налогоплательщика
        /// </summary>
        [XmlElement("itn")] public string? Itn { get; set; } = string.Empty;
    }

    /// <summary>
    /// Основная часть запроса
    /// </summary>
    [XmlType(TypeName = "BODY")]
    public class RequestBody
    {
        /// <summary>
        /// Атрибуты запроса
        /// </summary>
        [XmlElement("RequestAttributes")] public RequestRequestAttributes RequestAttributes { get; set; } = new();

        /// <summary>
        /// Сведения о заемщике - физическом лице
        /// </summary>
        [XmlElement("NaturalPersonSubject")] public RequestNaturalPersonSubject? NaturalPersonSubject { get; set; }
        public bool ShouldSerializeNaturalPersonSubject() => NaturalPersonSubject != null;

        /// <summary>
        /// Сведения о заемщике - юридическом лице
        /// </summary>
        [XmlElement("LegalPersonSubject")] public RequestLegalPersonSubject? LegalPersonSubject { get; set; }
        public bool ShouldSerializeLegalPersonSubject() => LegalPersonSubject != null;

        /// <summary>
        /// Договор
        /// </summary>
        [XmlElement("Contract")] public Contract? Contract { get; set; }
        public bool ShouldSerializeContract() => Contract is not null;

    }

    [EntityValidation]
    public class Contract
    {
        [XmlElement("Uid")] public string? Uid { get; set; } = string.Empty;
        public bool ShouldSerializeUid() => !string.IsNullOrEmpty(Uid);

        [XmlElement("LegalPersonId")] public string? LegalPersonId { get; set; } = "0";
        public bool ShouldSerializeLegalPersonId() => !string.IsNullOrEmpty(LegalPersonId);
    }

    /// <summary>
    /// Сведения о заемщике - юридическом лице
    /// </summary>
    [XmlType(TypeName = "LegalPersonSubject")]
    [EntityValidation]
    public class RequestLegalPersonSubject
    {
        /// <summary>
        /// Код страны по ОКСМ
        /// </summary>
        [XmlAttribute("CountryCode")] public string CountryCode { get; set; } = "643";

        /// <summary>
        /// Реквизиты юридического лица
        /// </summary>
        [XmlElement("Title")] public RequestLegalPersonSubjectTitle Title { get; set; } = null!;
        public bool ShouldSerializeTitle() => Title != null;

        /// <summary>
        /// Адрес юридического лица
        /// </summary>
        [XmlElement("Address")] public List<RequestAddress> Addresses { get; set; } = new List<RequestAddress>();
        public bool ShouldSerializeAddress() => Addresses.Any();


        /// <summary>
        /// Телефон юридического лица
        /// </summary>
        [XmlElement("Phone")] public List<RequestPhone> Phones { get; set; } = new List<RequestPhone>();
        public bool ShouldSerializePhones() => Phones.Any();

    }

    /// <summary>
    /// Наименование юридического лица
    /// </summary>
    [XmlType(TypeName = "LegalPersonSubjectTitle")]
    public class RequestLegalPersonSubjectTitle
    {
        /// <summary>
        /// Наименование юридического лица
        /// </summary>
        [XmlElement("Name")] public RequestName? Name { get; set; }

        /// <summary>
        /// ИНН юридического лица
        /// </summary>
        [XmlElement("IndividualTaxpayerNumber")] public string IndividualTaxpayerNumber { get; set; } = string.Empty;

        /// <summary>
        /// Регистрационный номер, присвоенный иностранным налоговым органом
        /// </summary>
        [XmlElement("ForeignID")] public string? ForeignID { get; set; }
        public bool ShouldSerializeForeignID() => !string.IsNullOrEmpty(ForeignID);

        /// <summary>
        /// Регистрационный номер, присвоенный уполномоченным органом в РФ (ОГРН)
        /// </summary>
        [XmlElement("PrimaryStateRegistrationNumber")] public string? PrimaryStateRegistrationNumber { get; set; } = string.Empty;
        public bool ShouldSerializePrimaryStateRegistrationNumber() => !string.IsNullOrEmpty(PrimaryStateRegistrationNumber);

        /// <summary>
        /// Регистрационный номер, присвоенный иностранным уполномоченным органом
        /// </summary>
        [XmlElement("RegistrationNumber")] public string? RegistrationNumber { get; set; }


    }

    /// <summary>
    /// Наименование юридического лица
    /// </summary>
    [XmlType(TypeName = "Name")]
    public class RequestName
    {
        /// <summary>
        /// Полное наименование юридического лица
        /// </summary>
        [XmlAttribute("FullName")] public string FullName { get; set; } = string.Empty;

        /// <summary>
        /// Краткое наименование юридического лица
        /// </summary>
        [XmlAttribute("ShortName")] public string? ShortName { get; set; }
        public bool ShouldSerializeShortName() => !string.IsNullOrEmpty(ShortName);

        /// <summary>
        /// Место рождения
        /// </summary>
        [XmlAttribute("FirmName")] public string? FirmName { get; set; }
        public bool ShouldSerializeFirmName() => !string.IsNullOrEmpty(FirmName);

        /// <summary>
        /// Наименование юридического лица на национальном языке
        /// </summary>
        [XmlAttribute("NationalName")] public string? NationalName { get; set; }
        public bool ShouldSerializeNationalName() => !string.IsNullOrEmpty(NationalName);

        /// <summary>
        /// Наименование юридического лица на иностранном языке
        /// </summary>
        [XmlAttribute("EngName")] public string? EngName { get; set; }
        public bool ShouldSerializeEngName() => !string.IsNullOrEmpty(EngName);
    }

    /// <summary>
    /// Атрибуты запроса
    /// </summary>
    [XmlType(TypeName = "RequestAttributes")]
    public class RequestRequestAttributes
    {
        /// <summary>
        /// Идентификатор запроса
        /// </summary>
        [XmlAttribute("id")] public int Id { get; set; } = 0;
        public bool ShouldSerializeId() => !Id.Equals(0);

        /// <summary>
        /// Параметры ответа
        /// </summary>
        [XmlElement("ResponseCapabilities", Order = 1)] public RequestResponseCapabilities ResponseCapabilities { get; set; } = new();

        /// <summary>
        /// Цель запроса
        /// </summary>
        [XmlElement("Reason", Order = 2)] public RequestReason Reason { get; set; } = new();
        public bool ShouldSerializeReason() => !Reason.ID.Equals("0");
        
        /// <summary>
        /// Цель запроса
        /// </summary>
        [XmlElement("RequestPurpose", Order = 3)] public List<RequestRequestPurpose> RequestPurpose { get; set; } = new() { new()};


        /// <summary>
        /// Информация о согласии субъекта
        /// </summary>
        [XmlElement("Consent", Order = 4)] public RequestConsent Consent { get; set; } = new();
        public bool ShouldSerializeConsent() => !Consent.Available.Equals("1");
    }

    public class RequestReason
    {
        /// <summary>
        /// Сумма заявки на кредит (лимит карты)
        /// </summary>
        [XmlAttribute("CustomerClaimCreditLimit")] public string? CustomerClaimCreditLimit { get; set; } = string.Empty;
        public bool ShouldSerializeCustomerClaimCreditLimit() => !ID.Equals(0) && !string.IsNullOrEmpty(CustomerClaimCreditLimit);

        /// <summary>
        /// Буквенное обозначение валюты
        /// </summary>
        [XmlAttribute("CurrencyCaption")] public string? CurrencyCaption { get; set; } = "RUR";
        public bool ShouldSerializeCurrencyCaption() => !ID.Equals(0) && !string.IsNullOrEmpty(CurrencyCaption);

        /// <summary>
        /// Сумма заявки на кредит (лимит карты)
        /// </summary>
        [XmlAttribute("ID")] public string ID { get; set; } = "0";


        /// <summary>
        /// Тип кредитной заявки
        /// </summary>
        [XmlElement("ApplicationType")] public ApplicationType ApplicationType { get; set; } = new();
        public bool ShouldSerializeApplicationType() => !ID.Equals(0);

        /// <summary>
        /// Инициатор кредитной заявки
        /// </summary>
        [XmlElement("ApplicationOrigin")] public ApplicationOrigin ApplicationOrigin { get; set; } = new();
        public bool ShouldSerializeApplicationOrigin() => !ID.Equals(0);
    }

    public class ApplicationOrigin
    {
        /// <summary>
        /// Код инициатора кредитной заявки
        /// </summary>
        [XmlAttribute("type")] public string Type { get; set; } = "1";

        /// <summary>
        /// Описание
        /// </summary>
        [XmlText] public string Text { get; set; } = "Обращение клиента";
    }

    public class ApplicationType
    {
        /// <summary>
        /// Код типа кредитной заявки
        /// </summary>
        [XmlAttribute("type")] public string Type { get; set; } = "1";

        /// <summary>
        /// Описание
        /// </summary>
        [XmlText] public string Text { get; set; } = "Новый продукт";
    }

    /// <summary>
    /// Информация о согласии субъекта
    /// </summary>
    [XmlType(TypeName = "Consent")]
    [EntityValidation]
    public class RequestConsent
    {
        /// <summary>
        /// Наличие согласия (1 - отсутствует, 2 - имеется)
        /// </summary>
        [XmlAttribute("Available")]
        public string Available { get; set; } = "2";
        public bool ShouldSerializeAvailable() => false;

        /// <summary>
        /// Цель (цели) выдачи согласия
        /// </summary>
        [XmlElement("Purpose", Order = 15)]
        public List<RequestRequestPurpose> Purpose { get; set; } = new() { new()};

        /// <summary>
        /// Дата выдачи согласия
        /// </summary>
        [XmlAttribute("IssueDate")]
        public string? IssueDate { get; set; } = DateTime.Now.ToShortDateString();
        public bool ShouldSerializeIssueDate() => !string.IsNullOrWhiteSpace(IssueDate);

        /// <summary>
        /// Иная цель (цели) выдачи согласия
        /// Если код цели выдачи согласия "99", то параметр обязательный
        /// </summary>
        [XmlAttribute("OtherPurposeAsText")]
        public string OtherPurposeAsText { get; set; } = string.Empty;
        public bool ShouldSerializeOtherPurposeAsText() => Purpose.Equals("99") && !string.IsNullOrWhiteSpace(OtherPurposeAsText);

        /// <summary>
        /// Дата окончания действия согласия
        /// </summary>
        [XmlAttribute("ExpiryDate")]
        public string ExpiryDate { get; set; } = DateTime.Now.AddMonths(6).ToShortDateString();
        public bool ShouldSerializeExpiryDate() => !string.IsNullOrWhiteSpace(ExpiryDate);

        /// <summary>
        /// Дата заключения договора
        /// </summary>
        [XmlAttribute("DateOfContract")]
        public string DateOfContract { get; set; } = string.Empty;
        public bool ShouldSerializeDateOfContract() => !string.IsNullOrWhiteSpace(DateOfContract);

        /// <summary>
        /// Основание передачи согласия
        /// </summary>
        [XmlAttribute("ReasonForConsentTransfer")]
        public string ReasonForConsentTransfer { get; set; } = string.Empty;
        public bool ShouldSerializeReasonForConsentTransfer() => !string.IsNullOrWhiteSpace(ReasonForConsentTransfer);

        /// <summary>
        /// Срок действия согласия
        /// </summary>
        [XmlAttribute("ConsentExpiration")]
        public string ConsentExpiration { get; set; } = "1";

        /// <summary>
        /// Субъект запроса относится к категории лиц, у которых нет СНИЛС
        /// </summary>
        [XmlAttribute("noPensionNumber")]
        public bool NoPensionNumber { get; set; }
        public bool ShouldSerializeNoPensionNumber() => NoPensionNumber;

        /// <summary>
        /// Признак получения согласия субъекта в электронной форме
        /// Если признак наличия согласия "1", то параметр обязательный
        /// </summary>
        [XmlAttribute("ConsentEForm")]
        public bool ConsentEForm { get; set; }

        /// <summary>
        /// Возвращать исходный запрос в ответе
        /// </summary>
        [XmlAttribute("HashCode")]
        public string? HashCode { get; set; }

        /// <summary>
        /// Сведения о заемщике - физическом лице
        /// </summary>
        [XmlElement("NaturalPersonSubject", Order = 16)] public ConsentNaturalPersonSubject? NaturalPersonSubject { get; set; }
        public bool ShouldSerializeNaturalPersonSubject() => NaturalPersonSubject != null;

        /// <summary>
        /// Сведения о заемщике - юридическом лице
        /// </summary>
        [XmlElement("LegalPersonSubject", Order = 17)] public ConsentLegalPersonSubject? LegalPersonSubject { get; set; }
        public bool ShouldSerializeLegalPersonSubject() => LegalPersonSubject != null;

        /// <summary>
        /// Сведения о пользователе - юридическом лице
        /// </summary>
        [XmlElement("UserLegalEntity", Order = 18)] public ConsentUserLegalEntity? UserLegalEntity { get; set; }
        public bool ShouldSerializeUserLegalEntity() => UserLegalEntity != null;

        /// <summary>
        /// Цель (цели) выдачи согласия
        /// </summary>
        [XmlElement("RequestorResponsibility", Order = 19)]
        public bool RequestorResponsibility { get; set; } = true;

    }

    /// <summary>
    /// Сведения о пользователе - юридическом лице
    /// </summary>
    public class ConsentUserLegalEntity
    {
        /// <summary>
        /// Место рождения
        /// </summary>
        [XmlAttribute("FullName")] public string? FullName { get; set; }

        /// <summary>
        /// Идентификационный номер налогоплательщика (ИНН)
        /// </summary>
        [XmlAttribute("IndividualTaxpayerNumber")] public string IndividualTaxpayerNumber { get; set; } = string.Empty;
        public bool ShouldSerializeIndividualTaxpayerNumber() => !string.IsNullOrEmpty(IndividualTaxpayerNumber);

        /// <summary>
        /// Реквизиты физического лица
        /// </summary>
        [XmlElement("PrimaryStateRegistrationNumber")] public string PrimaryStateRegistrationNumber { get; set; } = string.Empty;
        public bool ShouldSerializePrimaryStateRegistrationNumber() => !string.IsNullOrEmpty(PrimaryStateRegistrationNumber);
    }

    public class ConsentLegalPersonSubject
    {
        /// <summary>
        /// Место рождения
        /// </summary>
        [XmlAttribute("Address")] public string Address { get; set; } = string.Empty;
        public bool ShouldSerializeAddress() => !string.IsNullOrEmpty(Address);

        /// <summary>
        /// Место рождения
        /// </summary>
        [XmlAttribute("PhoneNumber")] public string? PhoneNumber { get; set; }

        /// <summary>
        /// Место рождения
        /// </summary>
        [XmlAttribute("IndividualTaxpayerNumber")] public string? IndividualTaxpayerNumber { get; set; }
        public bool ShouldSerializeIndividualTaxpayerNumber() => !string.IsNullOrEmpty(IndividualTaxpayerNumber);

        /// <summary>
        /// Место рождения
        /// </summary>
        [XmlElement("PrimaryStateRegistrationNumber", Order = 2)] public string? PrimaryStateRegistrationNumber { get; set; }
        public bool ShouldSerializePrimaryStateRegistrationNumber() => !string.IsNullOrEmpty(PrimaryStateRegistrationNumber);

        /// <summary>
        /// Место рождения
        /// </summary>
        [XmlElement("RegistrationNumber", Order = 3)] public string? RegistrationNumber { get; set; }
        public bool ShouldSerializeRegistrationNumber() => !string.IsNullOrEmpty(RegistrationNumber);

        [XmlElement("Name", Order = 1)] public ConsentLegalPersonName Name { get; set; } = new();
    }

    public class ConsentLegalPersonName
    {
        /// <summary>
        /// Место рождения
        /// </summary>
        [XmlAttribute("FullName")] public string? FullName { get; set; } = string.Empty;

        /// <summary>
        /// Место рождения
        /// </summary>
        [XmlAttribute("ShortName")] public string? ShortName { get; set; }

        /// <summary>
        /// Место рождения
        /// </summary>
        [XmlAttribute("FirmName")] public string? FirmName { get; set; }
    }

    /// <summary>
    /// Сведения о субъекте кредитной истории - физическом лице
    /// </summary>
    public class ConsentNaturalPersonSubject
    {
        /// <summary>
        /// Дата рождения
        /// </summary>
        [Required(ErrorMessage = "Данное поле обязательно для ввода")][XmlAttribute("BirthDate")] public string BirthDate { get; set; } = string.Empty;

        /// <summary>
        /// Место рождения
        /// </summary>
        [XmlAttribute("BirthPlace")] public string? BirthPlace { get; set; }
        public bool ShouldSerializeBirthPlace() => !string.IsNullOrEmpty(BirthPlace);

        /// <summary>
        /// Реквизиты физического лица
        /// </summary>
        [XmlElement("Name")] public List<NaturalPersonName> Name { get; set; } = new();
        public bool ShouldSerializeName() => Name.Any();

        /// <summary>
        /// Данные документа, удостоверяющего личность физического лица
        /// </summary>
        [XmlElement("IdentificationDocument")] public List<RequestIdentificationDocument> IdentificationDocuments { get; set; } = new List<RequestIdentificationDocument>();
        public bool ShouldSerializeIdentificationDocuments() => IdentificationDocuments.Any();

        /// <summary>
        /// Идентификационный номер налогоплательщика (ИНН)
        /// </summary>
        [XmlAttribute("IndividualTaxpayerNumber")] public string IndividualTaxpayerNumber { get; set; } = string.Empty;
        public bool ShouldSerializeIndividualTaxpayerNumber() => !string.IsNullOrEmpty(IndividualTaxpayerNumber);


        /// <summary>
        /// Номер страхового свидетельства обязательного пенсионного страхования
        /// </summary>
        [XmlAttribute("PensionNumber")] public string PensionNumber { get; set; } = string.Empty;
        public bool ShouldSerializePensionNumber() => !string.IsNullOrEmpty(PensionNumber);
    }


    /// <summary>
    /// Сведения об имени физического лица
    /// </summary>
    public class NaturalPersonName
    {
        /// <summary>
        /// Фамилия
        /// </summary>
        [XmlAttribute("LastName")] public string LastName { get; set; } = string.Empty;
        public bool ShouldSerializeLastName() => !string.IsNullOrEmpty(LastName);


        /// <summary>
        /// Имя
        /// </summary>
        [XmlAttribute("FirstName")] public string FirstName { get; set; } = string.Empty;
        public bool ShouldSerializeFirstName() => !string.IsNullOrEmpty(FirstName);

        /// <summary>
        /// Отчество
        /// </summary>
        [XmlAttribute("MiddleName")] public string MiddleName { get; set; } = string.Empty;
        public bool ShouldSerializeMiddleName() => !string.IsNullOrEmpty(MiddleName);

    }


    /// <summary>
    /// Параметры ответа
    /// </summary>
    [XmlType(TypeName = "ResponseCapabilities")]
    public class RequestResponseCapabilities
    {
        /// <summary>
        /// Запрашиваемая степень детализации отчета
        /// </summary>
        [XmlAttribute("CreditReportDetalization")]
        public int CreditReportDetalization { get; set; } = -1;

        /// <summary>
        /// Максимальное количество возвращаемых в ответе запросов по указанному субъекту, сделанных ранее («-1» - не возвращать информацию о предыдущих запросах)
        /// </summary>
        [XmlAttribute("PreviousRequestsCountLimit")]
        public int PreviousRequestsCountLimit { get; set; } = -1;
        public bool ShouldSerializePreviousRequestsCountLimit() => PreviousRequestsCountLimit > 0;

        /// <summary>
        /// Запрос кредитного рейтинга
        /// </summary>
        [XmlAttribute("getRating1")]
        public string GetRating1 { get; set; } = string.Empty;
        public bool ShouldSerializeGetRating1() => !string.IsNullOrWhiteSpace(GetRating1) && !GetRating1.Equals("false");

        /// <summary>
        /// Запрос рейтинга вероятности дефолта по юридическому лицу - работодателю
        /// </summary>
        [XmlAttribute("getRating2")]
        public string GetRating2 { get; set; } = string.Empty;
        public bool ShouldSerializeGetRating2() => !string.IsNullOrWhiteSpace(GetRating2) && !GetRating2.ToLower().Equals("false");

        /// <summary>
        /// Запрос совокупного рейтинга в строковом представлении
        /// </summary>
        [XmlAttribute("getRating3")]
        public string GetRating3 { get; set; } = string.Empty;
        public bool ShouldSerializeGetRating3() => !string.IsNullOrWhiteSpace(GetRating3) && !GetRating3.ToLower().Equals("false");

        /// <summary>
        /// Запрос сервиса верификации
        /// </summary>
        [XmlAttribute("getVerificationService")]
        public string GetVerificationService { get; set; } = string.Empty;
        public bool ShouldSerializeGetVerificationService() => !string.IsNullOrWhiteSpace(GetVerificationService) && !GetVerificationService.ToLower().Equals("false");

        /// <summary>
        /// Запрос сервиса ФССП
        /// </summary>
        [XmlAttribute("getBailiffsServiceDebtInfo")]
        public string GetBailiffsServiceDebtInfo { get; set; } = string.Empty;
        public bool ShouldSerializeGetBailiffsServiceDebtInfo() => !string.IsNullOrWhiteSpace(GetBailiffsServiceDebtInfo) && !GetBailiffsServiceDebtInfo.ToLower().Equals("false");

        /// <summary>
        /// Запрос сервиса антифрода
        /// </summary>
        [XmlAttribute("getFraudInfo")]
        public string GetFraudInfo { get; set; } = string.Empty;
        public bool ShouldSerializeGetFraudInfo() => !string.IsNullOrWhiteSpace(GetFraudInfo) && !GetFraudInfo.ToLower().Equals("false");

        /// <summary>
        /// Запрос сервиса платежной истории
        /// </summary>
        [XmlAttribute("getPaymentHistory")]
        public byte GetPaymentHistory { get; set; } = 0;
        public bool ShouldSerializeGetPaymentHistory() => !GetPaymentHistory.Equals(0);

        /// <summary>
        /// Запрос сервиса ФМС
        /// </summary>
        [XmlAttribute("getMigrationServiceDocumentCheck")]
        public byte GetMigrationServiceDocumentCheck { get; set; } = 0;
        public bool ShouldSerializeGetMigrationServiceDocumentCheck() => !GetMigrationServiceDocumentCheck.Equals(0);

        /// <summary>
        /// Возвращать исходный запрос в ответе
        /// </summary>
        [XmlAttribute("SelfRequestInResponse")]
        public bool SelfRequestInResponse { get; set; } = true;

        /// <summary>
        /// Запрос кредитного отчета, содержащего сведения о среднемесячных платежах
        /// </summary>
        [XmlAttribute("getReportWithAmp")]
        public string GetReportWithAmp { get; set; } = "false";
        public bool ShouldSerializeGetReportWithAmp() => GetReportWithAmp.ToLower().Equals("true");

        /// <summary>
        /// Запрос проверки паспорта в МВД
        /// </summary>
        [XmlAttribute("getMIAServiceDocCheck")]
        public string GetMIAServiceDocCheck { get; set; } = string.Empty;
        public bool ShouldSerializeGetMIAServiceDocCheck() => !string.IsNullOrWhiteSpace(GetMIAServiceDocCheck) && !GetMIAServiceDocCheck.ToLower().Equals("false");

        /// <summary>
        /// Запрос проверки регистрации в МВД
        /// </summary>
        [XmlAttribute("getMIAServiceRegCheck")]
        public string GetMIAServiceRegCheck { get; set; } = string.Empty;
        public bool ShouldSerializeGetMIAServiceRegCheck() => !string.IsNullOrWhiteSpace(GetMIAServiceRegCheck) && !GetMIAServiceRegCheck.ToLower().Equals("false");

        /// <summary>
        /// Запрос ИНН в ФНС
        /// </summary>
        [XmlAttribute("getTaxServiceTaxNum")]
        public string GetTaxServiceTaxNum { get; set; } = string.Empty;
        public bool ShouldSerializeGetTaxServiceTaxNum() => !string.IsNullOrWhiteSpace(GetTaxServiceTaxNum) && !GetTaxServiceTaxNum.ToLower().Equals("false");

        /// <summary>
        /// Запрос проверки ИНН в ФНС
        /// </summary>
        [XmlAttribute("getTaxServiceTaxNumCheck")]
        public string GetTaxServiceTaxNumCheck { get; set; } = string.Empty;
        public bool ShouldSerializeGetTaxServiceTaxNumCheck() => !string.IsNullOrWhiteSpace(GetTaxServiceTaxNumCheck) && !GetTaxServiceTaxNumCheck.ToLower().Equals("false");

        /// <summary>
        /// Запрос навигатора активности
        /// </summary>
        [XmlAttribute("getActivityNavigator")]
        public string GetActivityNavigator { get; set; } = string.Empty;
        public bool ShouldSerializeGetActivityNavigator() => !string.IsNullOrWhiteSpace(GetActivityNavigator) && !GetActivityNavigator.ToLower().Equals("false");

        /// <summary>
        /// Запрос проверки СНИЛС в ПФР
        /// </summary>
        [XmlAttribute("getPFRServiceSocialNumCheck")]
        public string GetPFRServiceSocialNumCheck { get; set; } = string.Empty;
        public bool ShouldSerializeGetPFRServiceSocialNumCheck() => !string.IsNullOrWhiteSpace(GetPFRServiceSocialNumCheck) && !GetPFRServiceSocialNumCheck.ToLower().Equals("false");

        /// <summary>
        /// Запрос кредитного отчета и сервиса ФССП
        /// </summary>
        [XmlAttribute("getReportWithBailiffsDebtInfo")]
        public string GetReportWithBailiffsDebtInfo { get; set; } = string.Empty;
        public bool ShouldSerializeGetReportWithBailiffsDebtInfo() => !string.IsNullOrWhiteSpace(GetReportWithBailiffsDebtInfo) && !GetReportWithBailiffsDebtInfo.ToLower().Equals("false");

        /// <summary>
        /// Запрос проверки статуса самозанятого
        /// </summary>
        [XmlAttribute("getSelfEmployedCheck")]
        public string GetSelfEmployedCheck { get; set; } = string.Empty;
        public bool ShouldSerializeGetSelfEmployedCheck() => !string.IsNullOrWhiteSpace(GetSelfEmployedCheck) && !GetSelfEmployedCheck.ToLower().Equals("false");
    }

    /// <summary>
    /// Цель запроса
    /// </summary>
    [XmlType(TypeName = "RequestPurpose")]
    public class RequestRequestPurpose
    {
        /// <summary>
        /// Код цели запроса
        /// Если код цели запроса "99", то конкретные сведения об иной цели запроса указываются в параметре "RequestPurpose"
        /// </summary>
        [XmlAttribute("type")] public string Type { get; set; } = "1";

        /// <summary>
        /// Цель запроса
        /// </summary>
        [XmlText] public string RequestPurposeValue { get; set; } = string.Empty;

    }


    /// <summary>
    /// Сведения о заемщике - физическом лице
    /// </summary>
    [XmlType(TypeName = "NaturalPersonSubject")]
    [EntityValidation]
    public class RequestNaturalPersonSubject
    {
        /// <summary>
        /// Дата рождения
        /// </summary>
        [XmlAttribute("BirthDate")] public string BirthDate { get; set; } = "";

        /// <summary>
        /// Место рождения
        /// </summary>
        [XmlAttribute("BirthPlace")] public string? BirthPlace { get; set; }
        public bool ShouldSerializeBirthPlace() => !string.IsNullOrEmpty(BirthPlace);

        /// <summary>
        /// Код страны гражданства по ОКСМ
        /// </summary>
        [XmlAttribute("CitizenshipCountryCode")] public string? CitizenshipCountryCode { get; set; } = "643";
        
        /// <summary>
        /// Признак проверки ИНН в ФНС
        /// Если указан ИНН,то параметр обязательный
        /// </summary>
        [XmlAttribute("innChecked")] public bool InnChecked { get; set; } = false;

        /// <summary>
        /// Реквизиты физического лица
        /// </summary>
        [XmlElement("Title")] public RequestTitle? Title { get; set; }
        public bool ShouldSerializeTitle() => Title != null;

        /// <summary>
        /// Данные документа, удостоверяющего личность физического лица
        /// </summary>
        [XmlElement("IdentificationDocument")] public List<RequestIdentificationDocument> IdentificationDocuments { get; set; } = new List<RequestIdentificationDocument>();
        [EntityValidation]
        public bool ShouldSerializeIdentificationDocuments() => IdentificationDocuments.Any();

        /// <summary>
        /// Регистрационный номер, присвоенный иностранным налоговым органом
        /// </summary>
        [XmlAttribute("IndividualTaxpayerNumber")] public string IndividualTaxpayerNumber { get; set; } = string.Empty;
        public bool ShouldSerializeIndividualTaxpayerNumber() => !string.IsNullOrEmpty(IndividualTaxpayerNumber);


        /// <summary>
        /// Номер страхового свидетельства обязательного пенсионного страхования
        /// </summary>
        [XmlAttribute("PensionNumber")] public string PensionNumber { get; set; } = string.Empty;
        public bool ShouldSerializePensionNumber() => !string.IsNullOrEmpty(PensionNumber);

        /// <summary>
        /// Семейное положение
        /// </summary>
        [XmlAttribute("MaritalStatus")] public string MaritalStatus { get; set; } = "0";
        public bool ShouldSerializeMaritalStatus() => !MaritalStatus.Equals("0");

        /// <summary>
        /// Пол заемщика
        /// </summary>
        [XmlAttribute("Gender")] public string Gender { get; set; } = "0";
        public bool ShouldSerializeGender() => !Gender.Equals("0");

        /// <summary>
        /// Адрес физического лица
        /// </summary>
        [XmlElement("Address")] public List<RequestAddress> Addresses { get; set; } = new List<RequestAddress>();
        public bool ShouldSerializeAddress() => Addresses.Any();


        /// <summary>
        /// Телефон физического лица
        /// </summary>
        [XmlElement("Phone")] public List<RequestPhone> Phones { get; set; } = new List<RequestPhone>();
        public bool ShouldSerializePhones() => Phones.Any();

        /// <summary>
        /// Сведения о юридическом лице - работодателе физического лица
        /// </summary>
        [XmlElement("Employer")] public List<RequestLegalPersonSubject> Employers { get; set; } = new List<RequestLegalPersonSubject>();
        public bool ShouldSerializeEmployer() => Employers.Any();

    }

    /// <summary>
    /// Реквизиты физического лица
    /// </summary>
    [XmlType(TypeName = "Title")]
    public class RequestTitle
    {
        /// <summary>
        /// Фамилия
        /// </summary>
        [XmlAttribute("LastName")] public string LastName { get; set; } = "";

        /// <summary>
        /// Имя
        /// </summary>
        [XmlAttribute("FirstName")] public string FirstName { get; set; } = "";

        /// <summary>
        /// Отчество
        /// </summary>
        [XmlAttribute("MiddleName")] public string MiddleName { get; set; } = "";
        public bool ShouldSerializeMiddleName() => !string.IsNullOrEmpty(MiddleName);

    }

    /// <summary>
    /// Паспортные данные субъекта для запроса кредитного отчета
    /// </summary>
    [XmlType(TypeName = "IdentificationDocument")]
    [EntityValidation]
    public class RequestIdentificationDocument
    {
        /// <summary>
        ///Серия паспорта
        /// </summary>
        [XmlAttribute("DocSer")] public string DocSer { get; set; } = "";
        public bool ShouldSerializeDocSer() => !string.IsNullOrEmpty(DocSer);

        /// <summary>
        /// Номер паспорта
        /// </summary>
        [XmlAttribute("DocNum")] public string DocNum { get; set; } = "";

        /// <summary>
        /// Тип документа. 21 - паспорт
        /// </summary>
        [XmlAttribute("DocTypeID")] public string DocTypeID { get; set; } = "21";

        /// <summary>
        /// Дата выдачи паспорта
        /// </summary>
        [XmlAttribute("DocDate")] public string DocDate { get; set; } = "";
        //public bool ShouldSerializeDocDate() => !string.IsNullOrEmpty(DocDate);

        /// <summary>
        /// Наименование органа, выдавшего документ, удостоверяющий личность физического лица
        /// </summary>
        [XmlAttribute("DocDelivInstName")] public string DocDelivInstName { get; set; } = "";
        public bool ShouldSerializeDocDelivInstName() => !string.IsNullOrEmpty(DocDelivInstName);

        /// <summary>
        /// Код подразделения, выдавшего документ, удостоверяющий личность
        /// </summary>
        [XmlAttribute("DocDelivInstCode")] public string DocDelivInstCode { get; set; } = "";
        public bool ShouldSerializeDocDelivInstCode() => !string.IsNullOrEmpty(DocDelivInstCode);
    }

    /// <summary>
    /// Телефон физического лица
    /// </summary>
    [XmlType(TypeName = "Phone")]
    [EntityValidation]
    public class RequestPhone
    {
        /// <summary>
        ///Идентификатор типа номера телефона физического лица
        /// </summary>
        [XmlAttribute("ID")] public string ID { get; set; } = "1";

        /// <summary>
        /// Текстовое описание типа номера телефона физического лица
        /// </summary>
        [XmlAttribute("Text")] public string? Text { get; set; }
        public bool ShouldSerializeText() => !string.IsNullOrEmpty(Text);

        /// <summary>
        /// Номер телефона физического лица
        /// </summary>
        [XmlAttribute("Number")] public string? Number { get; set; }
        public bool ShouldSerializeNumber() => !string.IsNullOrEmpty(Number);

        /// <summary>
        /// Код признака подтверждения номера телефона. 
        /// Показывает, каким способом был подтвержден номер телефона при оформлении заявки на кредит
        /// </summary>
        [XmlAttribute("ConfirmationType")] public string? ConfirmationType { get; set; }
        public bool ShouldSerializeConfirmationType() => !string.IsNullOrEmpty(ConfirmationType);


    }

    /// <summary>
    /// Адрес для запроса
    /// </summary>
    [XmlType(TypeName = "Address")]
    [EntityValidation]
    public class RequestAddress
    {
        [XmlAttribute("registrationDate")] public string? RegistrationDate { get; set; }

        /// <summary>
        /// Тип адреса
        /// </summary>
        [XmlElement("Caption")] public RequestCaption Caption { get; set; } = new();
        public bool ShouldSerializeCaption() => Caption != null;

        /// <summary>
        /// Регион (территориальное деление 1-го уровня)
        /// </summary>
        [XmlElement("Region")] public RequestRegion Region { get; set; } = new();
        public bool ShouldSerializeRegion() => !Region.ID.Equals("0");

        /// <summary>
        /// Район (территориальное деление 2-го уровня)
        /// </summary>
        [XmlElement("District")] public RequestDistrict District { get; set; } = new();
        public bool ShouldSerializeDistrict() => !string.IsNullOrEmpty(District.Ext);

        /// <summary>
        /// Город (территориальное деление 3-го уровня
        /// </summary>
        [XmlElement("City")] public RequestCity City { get; set; } = new();

        public bool ShouldSerializeCity() => !string.IsNullOrEmpty(City.Ext);
        /// <summary>
        /// Населенный пункт (территориальное деление 4-го уровня)
        /// </summary>
        [XmlElement("Village")] public RequestVillage Village { get; set; } = new();
        public bool ShouldSerializeVillage() => !string.IsNullOrEmpty(Village.Ext);

        /// <summary>
        /// Атрибуты адреса (улица-дом-корпус-строение-квартира)
        /// </summary>
        [XmlElement("StreetAddress")] public RequestStreetAddress StreetAddress { get; set; } = new();
        public bool ShouldSerializeStreetAddress() => !string.IsNullOrEmpty(StreetAddress.Street.Caption) || !string.IsNullOrEmpty(StreetAddress.HouseNum);

        public string AddressToString() => 
            $"{(Region.ID.Equals("0") ? string.Empty : Region.Text)}{(string.IsNullOrEmpty(District.Caption) ? string.Empty : $", {District.Caption} {District.Ext}")}{(string.IsNullOrEmpty(City.Caption) ? string.Empty : $", {City.Ext} {City.Caption}")}{(string.IsNullOrEmpty(Village.Caption) ? string.Empty : $", {Village.Caption} {Village.Ext}")}{(string.IsNullOrEmpty(StreetAddress.Street.Caption) ? string.Empty : $", {StreetAddress.Street.Ext} {StreetAddress.Street.Caption}")}{(string.IsNullOrEmpty(StreetAddress.HouseNum) ? string.Empty : ", д. " + StreetAddress.HouseNum)}{(string.IsNullOrEmpty(StreetAddress.BuildingNum) ? string.Empty : ", к. " + StreetAddress.BuildingNum)}{(string.IsNullOrEmpty(StreetAddress.FlatNum) ? string.Empty : ", кв. " + StreetAddress.FlatNum)}";

        
    }

    /// <summary>
    /// Тип адреса
    /// </summary>
    [XmlType(TypeName = "Caption")]
    public class RequestCaption
    {
        /// <summary>
        /// Идентификатор типа адреса
        /// </summary>
        [XmlAttribute("ID")] public string ID { get; set; } = "1";


        /// <summary>
        /// Текстовое описание типа адреса
        /// </summary>
        [XmlAttribute("Text")] public string Text { get; set; } = string.Empty;
        public bool ShouldSerializeText() => !string.IsNullOrEmpty(Text);
    }


    /// <summary>
    /// Регион (территориальное деление 1-го уровня)
    /// </summary>
    [XmlType(TypeName = "Region")]
    public class RequestRegion
    {
        /// <summary>
        /// Идентификатор региона
        /// </summary>
        [XmlAttribute("ID")] public string ID { get; set; } = "0";
        //public bool ShouldSerializeID() => !ID.Equals(0);


        /// <summary>
        /// Название региона
        /// </summary>
        [XmlAttribute("Text")] public string? Text { get; set; }
        public bool ShouldSerializeText() => !string.IsNullOrEmpty(Text);
    }


    /// <summary>
    /// Район (территориальное деление 2-го уровня)
    /// </summary>
    [XmlType(TypeName = "District")]
    public class RequestDistrict
    {
        /// <summary>
        /// Название района
        /// </summary>
        [XmlAttribute("Caption")] public string Caption { get; set; } = string.Empty;
        public bool ShouldSerializeCaption() => !string.IsNullOrEmpty(Caption);


        /// <summary>
        /// Сокращенное обозначение
        /// </summary>
        [XmlAttribute("Ext")] public string Ext { get; set; } = string.Empty;
        public bool ShouldSerializeExt() => !string.IsNullOrEmpty(Ext);
    }


    /// <summary>
    /// Город (территориальное деление 3-го уровня)
    /// </summary>
    [XmlType(TypeName = "City")]
    public class RequestCity
    {
        /// <summary>
        /// Название города
        /// </summary>
        [XmlAttribute("Caption")] public string? Caption { get; set; }
        public bool ShouldSerializeCaption() => !string.IsNullOrEmpty(Caption);


        /// <summary>
        /// Сокращенное обозначение
        /// </summary>
        [XmlAttribute("Ext")] public string Ext { get; set; } = string.Empty;
        public bool ShouldSerializeExt() => !string.IsNullOrEmpty(Ext);
    }


    /// <summary>
    /// Населенный пункт (территориальное деление 4-го уровня)
    /// </summary>
    [XmlType(TypeName = "Village")]
    public class RequestVillage
    {
        /// <summary>
        /// Название населенного пункта
        /// </summary>
        [XmlAttribute("Caption")] public string? Caption { get; set; }
        public bool ShouldSerializeCaption() => !string.IsNullOrEmpty(Caption);

        /// <summary>
        /// Сокращенное обозначение
        /// </summary>
        [XmlAttribute("Ext")] public string Ext { get; set; } = string.Empty;
        public bool ShouldSerializeExt() => !string.IsNullOrEmpty(Ext);
    }


    /// <summary>
    /// Атрибуты адреса (улица-дом-корпус-строение-квартира
    /// </summary>
    [XmlType(TypeName = "StreetAddress")]
    public class RequestStreetAddress
    {
        /// <summary>
        /// Номер дома
        /// </summary>
        [XmlAttribute("HouseNum")] public string HouseNum { get; set; } = string.Empty;
        public bool ShouldSerializeHouseNum() => !string.IsNullOrEmpty(HouseNum);

        /// <summary>
        /// Номер корпуса
        /// </summary>
        [XmlAttribute("BuildingNum")] public string BuildingNum { get; set; } = string.Empty;
        public bool ShouldSerializeBuildingNum() => !string.IsNullOrEmpty(BuildingNum);

        /// <summary>
        /// Символьное обозначение (номер) строения
        /// </summary>
        [XmlAttribute("BuildingSymbol")] public string BuildingSymbol { get; set; } = string.Empty;
        public bool ShouldSerializeBuildingSymbol() => !string.IsNullOrEmpty(BuildingSymbol);

        /// <summary>
        /// Номер квартиры/офиса
        /// </summary>
        [XmlAttribute("FlatNum")] public string FlatNum { get; set; } = string.Empty;
        public bool ShouldSerializeFlatNum() => !string.IsNullOrEmpty(FlatNum);

        /// <summary>
        /// Улица (территориальное деление 5-го уровня
        /// </summary>
        [XmlElement("Street")] public RequestStreet Street { get; set; } = new();
        public bool ShouldSerializeStreet() => !string.IsNullOrEmpty(Street.Caption);

    }

    /// <summary>
    /// Улица (территориальное деление 5-го уровня)
    /// </summary>
    [XmlType(TypeName = "Street")]
    public class RequestStreet
    {
        /// <summary>
        /// Название улицы
        /// </summary>
        [XmlAttribute("Caption")] public string Caption { get; set; } = string.Empty;
        public bool ShouldSerializeCaption() => !string.IsNullOrEmpty(Caption);

        /// <summary>
        /// Сокращенное обозначение
        /// </summary>
        [XmlAttribute("Ext")] public string Ext { get; set; } = string.Empty;
        public bool ShouldSerializeExt() => !string.IsNullOrEmpty(Ext);
    }
}


