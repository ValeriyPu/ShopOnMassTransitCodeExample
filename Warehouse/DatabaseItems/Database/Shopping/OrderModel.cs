using DatabaseItems.Database.Warehouse;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseItems.Database.Shopping
{
    /// <summary>
    /// Статусы заказа
    /// </summary>
    public enum eOrderState
    {
        /// <summary>
        /// Забронирован
        /// </summary>
        Booked,
        /// <summary>
        /// Отменен
        /// </summary>
        Cancelled,
        /// <summary>
        /// Отправлен
        /// </summary>
        Sended,
        /// <summary>
        /// Получено подтверждение
        /// </summary>
        RecieveConfirm
    }

    /// <summary>
    /// Запись о заказе
    /// </summary>
    public class OrderModel
    {
        /// <summary>
        /// Id заказа
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        /// <summary>
        /// Id ползователя, сделавшего заказ
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Статус заказа
        /// </summary>
        public eOrderState OrderState { get; set; }

        /// <summary>
        /// Список товаров
        /// </summary>
        public virtual ICollection<WarehouseItemModel> Items { get; set; }

    }
}
