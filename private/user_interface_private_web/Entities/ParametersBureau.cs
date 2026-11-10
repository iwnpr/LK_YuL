namespace user_interface_private_web.Entities
{
    public class ParametersBureau
    {
        public bool PreviousRequests { get; set; } = false;
        public int PreviousRequestsCount { get; set; } = -1;
        public bool CreditReport { get; set; } = false;
        public int CreditReportDetalization { get; set; } = 3;
        public bool Fms { get; set; } = false;
        public bool Fns { get; set; } = false;
        public bool GetBailiffsServiceDebtInfo { get; set; } = false;
        public bool GetVerificationService { get; set; } = false;
        public bool GetReportWithAMP { get; set; } = false;
        public bool GetMIAServiceDocCheck { get; set; } = false;
        public bool GetMIAServiceRegCheck { get; set; } = false;
        public bool GetTaxServiceTaxNum { get; set; } = false;
        public bool GetTaxServiceTaxNumCheck { get; set; } = false;
        public bool GetActivityNavigator { get; set; } = false;
        public bool GetPFRServiceSocialNumCheck { get; set; } = false;
        public bool GetReportWithBailiffsDebtInfo { get; set; } = false;
        public bool GetSelfEmployedCheck { get; set; } = false;

    }
}
