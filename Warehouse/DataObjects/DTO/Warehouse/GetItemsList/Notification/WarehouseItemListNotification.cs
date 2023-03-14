using DataObjects.BaseItems.Notification;
using DataObjects.DTO.Warehouse.GetItemsList.Requests;
using System.Collections.Generic;

namespace DataObjects.DTO.Warehouse.GetItemsList.Notification
{
    /// <summary>
    /// Сообщение с данными о товарах на складе
    /// </summary>
    public class WarehouseItemListNotification : BaseSuccessNotification<WarehouseItemListRequest>
    {
        /// <summary>
        /// Список всех товаров
        /// </summary>
        public List<WarehouseItem> Items;
    }
}
