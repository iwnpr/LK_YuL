
using System.ComponentModel;

namespace legal_persons_lib.Enums
{
    /// <summary>
    /// Статусы сертификата
    /// </summary>
    public enum DBCertificateStatus: byte
    {
        [Description("Выдан")]
        issued,
        [Description("Отменен пользователем")]
        cancelled_by_user,
        [Description("В очереди")]
        requested,
        [Description("Отменен администратором")]
        cancelled_by_admin
    }
}
