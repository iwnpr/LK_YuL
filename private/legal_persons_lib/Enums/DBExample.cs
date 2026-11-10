using System.ComponentModel;

namespace legal_persons_lib.Enums
{
    /// <summary>
    /// Госучреждения
    /// </summary>
    public enum DBExampleType
    {
        [Description("Проверка КИ")]
        check_contracts,
        [Description("Запросы для Госорганов")]
        for_government,
        [Description("Запросы в Бюро")]
        bureau,
        [Description("Загрузки")]
        upload,
        [Description("Запросы ЦККИ")]
        ccch
    }
}
