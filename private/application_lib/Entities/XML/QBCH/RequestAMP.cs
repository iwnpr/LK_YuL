using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;

namespace application_lib.Entities.XML.QBCH
{
    /// <summary>
    /// ЗапросСведенийОПлатежах  
    /// </summary>
    [XmlType(TypeName = "ЗапросСведений")]
    [EntityValidation]
    public class RequestAMP
    {
        /// <summary>
        /// Версия
        /// </summary>
        [XmlAttribute("Версия")] public string Version { get; set; } = "3.0";

        /// <summary>
        /// Отпечаток
        /// </summary>
        [XmlAttribute("Отпечаток")] public string Thumbprint { get; set; } = "-";
        public bool ShouldSerializeThumbprint() => false;

        /// <summary>
        /// Идентификатор запроса
        /// </summary>
        [XmlAttribute("ИдентификаторЗапроса")] public string RequestId { get; set; } = Guid.NewGuid().ToString();

        [XmlAttribute("ДатаЗапроса")] public string RequestDate { get; set; } = DateTime.Now.ToString("yyyy-MM-dd");

        /// <summary>
        /// Тип запроса
        /// </summary>
        [XmlAttribute("ТипЗапроса")] public string RequestType { get; set; } = "2";
        
        [XmlAttribute("КодСведений")] public string InformationCode { get; set; } = "6";

        [XmlAttribute("РежимЗапроса")] public string RequestMode { get; set; } = "1";

        /// <summary>
        /// Абонент
        /// </summary>
        [XmlElement("Абонент")] public Abonent Abonent { get; set; } = new();

        /// <summary>
        /// Запрос
        /// </summary>
        [XmlElement("Запрос")] public RequestData Request { get; set; } = new();

    }

    /// <summary>
    /// Запрос
    /// </summary>
    [XmlType(TypeName = "Запрос")]
    public class RequestData
    {
        /// <summary>
        /// Дата
        /// </summary>
        [XmlAttribute("ПорядковыйНомер")] public string Number { get; set; } = "1";

        /// <summary>
        /// Источник
        /// </summary>
        [XmlElement("Источник")] public Source Source { get; set; } = new();

        /// <summary>
        /// Субъект
        /// </summary>
        [XmlElement("Субъект")] public Subject Subject { get; set; } = new();

        /// <summary>
        /// Согласие
        /// </summary>
        [XmlElement("Согласие")] public Consent Consent { get; set; } = new();

        /// <summary>
        /// Цель
        /// </summary>
        [XmlElement("Цель")] public Purpose Purpose { get; set; } = new();

        /// <summary>
        /// Сумма обязательства
        /// </summary>
        [XmlElement("СуммаОбязательства")] public ObligationSum Amount { get; set; } = new();
        public bool ShouldSerializeAmount() => new List<string>() { "1", "2", "3", "4", "5", "10", "11", "12", "13", "14", "15"}.Contains(Purpose.Code);
    }

    /// <summary>
    /// Субъект
    /// </summary>
    [XmlType(TypeName = "Цель")]
    public class Purpose
    {
        /// <summary>
        /// КодЦели
        /// </summary>
        [XmlAttribute("КодЦели")] public string Code { get; set; } = "0";

        /// <summary>
        /// КодЦели
        /// </summary>
        [XmlAttribute("Описание")] public string Description { get; set; } = string.Empty;
        public bool ShouldSerializeDescription() => Code.Equals("99");
    }

    /// <summary>
    /// Субъект
    /// </summary>
    [XmlType(TypeName = "СуммаОбязательства")]
    public class ObligationSum
    {
        /// <summary>
        /// Валюта
        /// </summary>
        [XmlAttribute("Валюта")] public string Currency { get; set; } = "RUB";

        /// <summary>
        /// Сумма обязательства
        /// </summary>
        [XmlText] public string Text { get; set; } = string.Empty;
    }

    /// <summary>
    /// Договор
    /// </summary>
    [XmlType(TypeName = "Договор")]
    public class Obligation
    {
        /// <summary>
        /// Валюта
        /// </summary>
        [XmlAttribute("Дата")] public string Date { get; set; } = string.Empty;
    }

    /// <summary>
    /// Субъект
    /// </summary>
    [XmlType(TypeName = "Согласие")]
    public class Consent
    {
        /// <summary>
        /// Дата выдачи
        /// </summary>
        [XmlAttribute("ДатаВыдачи")] public string ConsentDate { get; set; } = DateTime.Now.ToShortDateString();

        /// <summary>
        /// Срок действия
        /// </summary>
        [XmlAttribute("СрокДействия")] public string ConsentExpiration { get; set; } = "1";

        ///// <summary>
        ///// Основание Передачи
        ///// </summary>
        //[XmlAttribute("ОснованиеПередачи")] public string ReasonForConsentTransfer { get; set; } = string.Empty;
        //public bool ShouldSerializeDReasonForConsentTransfer() => !string.IsNullOrEmpty(ReasonForConsentTransfer);

        /// <summary>
        /// Об ответственности предупрежден
        /// </summary>
        [XmlAttribute("ОбОтветственностиПредупрежден")] public string IsWarned { get; set; } = "1";

        /// <summary>
        /// Выдано
        /// </summary>
        [XmlElement("Выдано")] public Issued Issued { get; set; } = new();

        /// <summary>
        /// Цель
        /// </summary>
        [XmlElement("Цель")] public Purpose Purpose { get; set; } = new();

        /// <summary>
        /// Договор
        /// </summary>
        [XmlElement("Договор")] public Obligation Obligation { get; set; } = new();
        public bool ShouldSerializeObligation() => ConsentExpiration.Equals("3");

        /// <summary>
        /// ХэшКод
        /// </summary>
        [XmlElement("ХэшКод")] public string HashCode { get; set; } = string.Empty;
        public bool ShouldSerializeHashCode() => !string.IsNullOrEmpty(HashCode);
    }

    /// <summary>
    /// Субъект
    /// </summary>
    [XmlType(TypeName = "Выдано")]
    public class Issued
    {
        /// <summary>
        /// ЮридическоеЛицо
        /// </summary>
        [XmlElement("ЮридическоеЛицо")] public LegalEntity? IssuedLegalEntity { get; set; }

        [XmlElement("ИндивидуальныйПредприниматель")] public IndividualEntrepreneur? IssuedIndividualEntrepreneur { get; set; }
    }

    /// <summary>
    /// Субъект
    /// </summary>
    [XmlType(TypeName = "Субъект")]
    public class Subject
    {
        /// <summary>
        /// ФИО
        /// </summary>
        [XmlElement("ФИО")] public Initials Initials { get; set; } = new();

        /// <summary>
        /// Дата рождения
        /// </summary>
        [XmlElement("ДатаРождения")] public string BirthDate { get; set; } = "";

        /// <summary>
        /// Документ
        /// </summary>
        [XmlElement("ДокументЛичности")] public IdentityDocument IdentityDocument { get; set; } = new();

        /// <summary>
        /// ИНН
        /// </summary>
        [XmlElement("ИНН")] public TaxNum TaxNum { get; set; } = new();
        public bool ShouldSerializeTaxNum() => !string.IsNullOrEmpty(TaxNum.Value);

        /// <summary>
        /// СНИЛС
        /// </summary>
        [XmlElement("СНИЛС")] public string SocialNum { get; set; } = string.Empty;
        public bool ShouldSerializeSocialNum() => !string.IsNullOrEmpty(SocialNum);
    }

    public class TaxNum
    {
        [XmlAttribute("ПризнакПроверки")] public string Checked { get; set; } = "1";
        public bool ShouldSerializeChecked => !string.IsNullOrEmpty(Value);
        [XmlText] public string Value { get; set; } = string.Empty;
    }

    /// <summary>
    /// Документ личности
    /// </summary>
    [XmlType(TypeName = "ДокументЛичности")]
    public class IdentityDocument
    {
        /// <summary>
        /// Код ДУЛ
        /// </summary>
        [XmlAttribute("КодДУЛ")] public string Code { get; set; } = "21";

        /// <summary>
        /// Источник
        /// </summary>
        [XmlElement("Серия")] public string Seria { get; set; } = "";
        public bool ShouldSerializeSeria() => !string.IsNullOrEmpty(Seria);

        /// <summary>
        /// Субъект
        /// </summary>
        [XmlElement("Номер")] public string Number { get; set; } = "";

        /// <summary>
        /// Согласие
        /// </summary>
        [XmlElement("ДатаВыдачи")] public string DocDate { get; set; } = "";

        /// <summary>
        /// Гражданство
        /// </summary>
        [XmlElement("Гражданство")] public string Citizenship { get; set; } = "643";

    }

    /// <summary>
    /// ФИО
    /// </summary>
    [XmlType(TypeName = "ФИО")]
    public class Initials
    {
        /// <summary>
        /// Фамилия
        /// </summary>
        [XmlElement("Фамилия")] public string LastName { get; set; } = "";

        /// <summary>
        /// Имя
        /// </summary>
        [XmlElement("Имя")] public string FirstName { get; set; } = "";

        /// <summary>
        /// Отчество
        /// </summary>
        [XmlElement("Отчество")] public string MiddleName { get; set; } = "";
        public bool ShouldSerializeMiddleName() => !string.IsNullOrEmpty(MiddleName);
    }

    /// <summary>
    /// Источник
    /// </summary>
    [XmlType(TypeName = "Источник")]
    public class Source
    {
        /// <summary>
        /// ЮридическоеЛицо
        /// </summary>
        [XmlElement("ЮридическоеЛицо")] public LegalEntity? SourceLegalEntity { get; set; }

        [XmlElement("ИндивидуальныйПредприниматель")] public IndividualEntrepreneur? SourceIndividualEntrepreneur { get; set; }
    }

    /// <summary>
    /// Абонент
    /// </summary>
    [XmlType(TypeName = "Абонент")]
    public class Abonent
    {
        /// <summary>
        /// Юридическое лицо
        /// </summary>
        [XmlElement("ЮридическоеЛицо")] public LegalEntity? LegalEntity { get; set; } 

        [XmlElement("ИндивидуальныйПредприниматель")] public IndividualEntrepreneur? IndividualEntrepreneur { get; set; } 
    }

    /// <summary>
    /// Абонент
    /// </summary>
    [XmlType(TypeName = "ЮридическоеЛицо")]
    public class LegalEntity
    {
        /// <summary>
        /// Абонент
        /// </summary>
        [XmlElement("ИНН")] public string TaxpayerIdentificationNumber { get; set; } = string.Empty;

        /// <summary>
        /// Запрос
        /// </summary>
        [XmlElement("ОГРН")] public string PrimaryStateRegister { get; set; } = string.Empty;

        /// <summary>
        /// Запрос
        /// </summary>
        [XmlElement("ПолноеНаименование")] public string FullName { get; set; } = string.Empty;
        public bool ShouldSerializeFullName() => !string.IsNullOrEmpty(FullName);

        /// <summary>
        /// Запрос
        /// </summary>
        [XmlElement("СокращенноеНаименование")] public string ShortName { get; set; } = string.Empty;
        public bool ShouldSerializeShortName() => !string.IsNullOrEmpty(ShortName);

        /// <summary>
        /// Запрос
        /// </summary>
        [XmlAttribute("КодВидаПользователя")] public string TypeCode { get; set; } = string.Empty;
        public bool ShouldSerializeTypeCode() => !string.IsNullOrEmpty(TypeCode);

        /// <summary>
        /// Запрос
        /// </summary>
        [XmlAttribute("ПризнакРегистрацииРФ")] public string RegisterInRF { get; set; } = "1";
        public bool ShouldSerializeRegisterInRF() => !string.IsNullOrEmpty(RegisterInRF);
    }


    [XmlType(TypeName = "ИндивидуальныйПредприниматель")]
    public class IndividualEntrepreneur
    {
        /// <summary>
        /// Абонент
        /// </summary>
        [XmlElement("ИННИП")] public string TaxpayerIdentificationNumber { get; set; } = string.Empty;

        /// <summary>
        /// Запрос
        /// </summary>
        [XmlElement("ОГРНИП")] public string PrimaryStateRegister { get; set; } = string.Empty;

        /// <summary>
        /// Запрос
        /// </summary>
        [XmlElement("ПолноеНаименование")] public string FullName { get; set; } = string.Empty;
        public bool ShouldSerializeFullName() => !string.IsNullOrEmpty(FullName);

        /// <summary>
        /// Запрос
        /// </summary>
        [XmlElement("СокращенноеНаименование")] public string ShortName { get; set; } = string.Empty;
        public bool ShouldSerializeShortName() => !string.IsNullOrEmpty(ShortName);

        /// <summary>
        /// Запрос
        /// </summary>
        [XmlAttribute("КодВидаПользователя")] public string TypeCode { get; set; } = string.Empty;
        public bool ShouldSerializeTypeCode() => !string.IsNullOrEmpty(TypeCode);

        /// <summary>
        /// Запрос
        /// </summary>
        [XmlAttribute("ПризнакРегистрацииРФ")] public string RegisterInRF { get; set; } = "1";
        public bool ShouldSerializeRegisterInRF() => !string.IsNullOrEmpty(RegisterInRF);
    }
}
