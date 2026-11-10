namespace application_lib.Entities.Diagnostic
{
    public class UserCertificate
    {
        public int Version { get; set; }
        public string SubjectName { get; set; } = null!;
        public string Thumbprint { get; set; } = null!;
        public string IssuerName { get; set; } = null!;
        public string ValidFromDate { get; set; } = null!;
        public string ValidToDate { get; set; } = null!;
        public string AlgoName { get; set; } = null!;
        public string SerialNumber { get; set; } = null!;
        public string PublicKey { get; set; } = null!;
        public string PrivateKey { get; set; } = null!;
        public string IsValid { get; set; } = null!;
    }
}
