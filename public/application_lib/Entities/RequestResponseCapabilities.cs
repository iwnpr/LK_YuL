using System.Xml.Serialization;

namespace application_lib.Entities
{
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
        public bool ShouldSerializePreviousRequestsCountLimit() => !PreviousRequestsCountLimit.Equals(-1) && !PreviousRequestsCountLimit.Equals(0);

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
        public bool ShouldSerializeGetRating2() => !string.IsNullOrWhiteSpace(GetRating2) && !GetRating2.Equals("false");

        /// <summary>
        /// Запрос совокупного рейтинга в строковом представлении
        /// </summary>
        [XmlAttribute("getRating3")]
        public string GetRating3 { get; set; } = string.Empty;
        public bool ShouldSerializeGetRating3() => !string.IsNullOrWhiteSpace(GetRating3) && !GetRating3.Equals("false");

        /// <summary>
        /// Запрос сервиса верификации
        /// </summary>
        [XmlAttribute("getVerificationService")]
        public string GetVerificationService { get; set; } = string.Empty;
        public bool ShouldSerializeGetVerificationService() => !string.IsNullOrWhiteSpace(GetVerificationService) && !GetVerificationService.Equals("false");

        /// <summary>
        /// Запрос сервиса ФССП
        /// </summary>
        [XmlAttribute("getBailiffsServiceDebtInfo")]
        public string GetBailiffsServiceDebtInfo { get; set; } = string.Empty;
        public bool ShouldSerializeGetBailiffsServiceDebtInfo() => !string.IsNullOrWhiteSpace(GetBailiffsServiceDebtInfo) && !GetBailiffsServiceDebtInfo.Equals("false");

        /// <summary>
        /// Запрос сервиса антифрода
        /// </summary>
        [XmlAttribute("getFraudInfo")]
        public string GetFraudInfo { get; set; } = string.Empty;
        public bool ShouldSerializeGetFraudInfo() => !string.IsNullOrWhiteSpace(GetFraudInfo) && !GetFraudInfo.Equals("false");

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
    }
}
