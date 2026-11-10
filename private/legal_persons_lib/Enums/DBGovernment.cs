using System.ComponentModel;

namespace legal_persons_lib.Enums
{
    /// <summary>
    /// Госучреждения
    /// </summary>
    public enum DBGovernment
    {
        [Description("Суд")]
        court,
        [Description("Органы предварительного следствия")]
        preliminary_investigation_authorities,
        [Description("Финансовый управляющий")]
        financial_manager,
        [Description("Федеральная служба судебный приставов")]
        federal_bailiff_service,
        [Description("Нотариус")]
        notary,
        [Description("Центральный банк РФ")]
        central_bank
    }
}
