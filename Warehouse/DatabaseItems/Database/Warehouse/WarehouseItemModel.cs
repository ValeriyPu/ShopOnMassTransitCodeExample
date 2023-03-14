using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseItems.Database.Warehouse
{
    /// <summary>
    /// Статус товара на складе
    /// </summary>
    public enum eState
    {
        /// <summary>
        /// Доступно
        /// </summary>
        Avaible,
        /// <summary>
        /// Зарезервирован
        /// </summary>
        Reserved
    }

    public class WarehouseItemModel
    {
        /// <summary>
        /// Id товара
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        /// <summary>
        /// Тип товара
        /// </summary>
        public Guid TypeId { get; set; }

        /// <summary>
        /// Название товара
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Статус товара
        /// </summary>
        public eState State { get; set; }

    }
}
