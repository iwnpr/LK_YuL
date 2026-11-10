namespace application_lib.Entities
{
    public class UserCertificate
    {
        public int Version { get; set; }
        public string SubjectName { get; set; } = string.Empty;
        public string Thumbprint { get; set; } = string.Empty;
        public string IssuerName { get; set; } = string.Empty;
        public string ValidFromDate { get; set; } = string.Empty;
        public string ValidToDate { get; set; } = string.Empty;
        public string Algorithm { get; set; } = string.Empty;
        public string SerialNumber { get; set; } = string.Empty;
        public string PublicKey { get; set; } = string.Empty;
        public string PrivateKey { get; set; } = string.Empty;
    }
}
