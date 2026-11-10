using application_lib.Entities;

namespace user_interface_public_web.Entities
{
    public class ParametersBureau
    {
        public bool PreviousRequests { get; set; } = false;
        public int PreviousRequestsCount { get; set; } = -1;
        public bool CreditReport { get; set; } = false;
        public int CreditReportDetalization { get; set; } = 3;
        public bool Fms { get; set; } = false;
        public bool Fns { get; set; } = false;
        public bool GetRating1 { get; set; } = false;
        public bool GetRating2 { get; set; } = false;
        public bool GetRating3 { get; set; } = false;
        public bool GetBailiffsServiceDebtInfo { get; set; } = false;
        public bool GetVerificationService { get; set; } = false;
        public bool PaymentHistory { get; set; } = false;
        public byte GetPaymentHistory { get; set; }
        public bool GetFraudInfo { get; set; } = false;
        public bool GetReportWithAMP { get; set; } = false;

        public ParametersBureau(RequestResponseCapabilities _requestParameters)
        {
            PreviousRequests = _requestParameters.PreviousRequestsCountLimit > 0;
            PreviousRequestsCount = _requestParameters.PreviousRequestsCountLimit;
            CreditReport = !_requestParameters.CreditReportDetalization.Equals(3);
            CreditReportDetalization = _requestParameters.CreditReportDetalization;
            PaymentHistory = !_requestParameters.GetPaymentHistory.Equals(0);
            GetPaymentHistory = _requestParameters.GetPaymentHistory;
            GetReportWithAMP = _requestParameters.GetReportWithAmp.ToLower().Equals("true");
            GetRating1 = !string.IsNullOrWhiteSpace(_requestParameters.GetRating1) && _requestParameters.GetRating1.ToLower().Equals("true");
            GetRating2 = !string.IsNullOrWhiteSpace(_requestParameters.GetRating2) && _requestParameters.GetRating2.ToLower().Equals("true");
            GetRating3 = !string.IsNullOrWhiteSpace(_requestParameters.GetRating3) && _requestParameters.GetRating3.ToLower().Equals("true");
            GetBailiffsServiceDebtInfo = !string.IsNullOrWhiteSpace(_requestParameters.GetBailiffsServiceDebtInfo) && _requestParameters.GetBailiffsServiceDebtInfo.Equals("true");
            GetFraudInfo = !string.IsNullOrWhiteSpace(_requestParameters.GetFraudInfo) && _requestParameters.GetFraudInfo.ToLower().Equals("true");
            GetVerificationService = !string.IsNullOrWhiteSpace(_requestParameters.GetVerificationService) && _requestParameters.GetVerificationService.ToLower().Equals("true");

            switch (_requestParameters.GetMigrationServiceDocumentCheck)
            {
                case (2): Fns = true; Fms = true; break;
                case (1): Fns = false; Fms = true; break;
                case (0): Fns = false; Fms = false; break;
            }
        }

        public RequestResponseCapabilities ToBureauRequestParameters()
        {
            var _requestParameters = new RequestResponseCapabilities
            {
                CreditReportDetalization = CreditReport ? CreditReportDetalization : 3,
                PreviousRequestsCountLimit = PreviousRequests ? PreviousRequestsCount : 0,
                GetPaymentHistory = (byte)(PaymentHistory ? GetPaymentHistory : 0),
                GetRating1 = GetRating1.ToString().ToLower(),
                GetRating2 = GetRating2.ToString().ToLower(),
                GetRating3 = GetRating3.ToString().ToLower(),
                GetBailiffsServiceDebtInfo = GetBailiffsServiceDebtInfo.ToString().ToLower(),
                GetVerificationService = GetVerificationService.ToString().ToLower(),
                GetFraudInfo = GetFraudInfo.ToString().ToLower(),
                GetReportWithAmp = GetReportWithAMP.ToString().ToLower(),
                GetMigrationServiceDocumentCheck = (byte)(!Fms ? 0 : !Fns ? 1 : 2),
            };

            return _requestParameters;
        }
    }
}
