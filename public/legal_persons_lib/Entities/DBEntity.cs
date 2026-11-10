using System.ComponentModel.DataAnnotations.Schema;

namespace legal_persons_lib.Entities
{
    /// <summary>
    /// Базовый класс для сущностей таблиц
    /// </summary>
    public class DBEntity
    {
        /// <summary>
        /// Идентификатор записи (PrimaryKey)
        /// </summary>
        [Column("id")] public int Id { get; set; }

    }
}
