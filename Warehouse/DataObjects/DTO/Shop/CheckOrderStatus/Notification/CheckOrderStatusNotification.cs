using DataObjects.BaseItems.Notification;
using DataObjects.DTO.Shop.BuyItems.Requests;
using DataObjects.DTO.Shop.CheckOrderStatus;

namespace DataObjects.DTO.Warehouse.GetItemsList.Notification
{
    /// <summary>
    /// Сообщение с данными о статусе заказа
    /// </summary>
    public class CheckOrderStatusNotification : BaseSuccessNotification<CheckOrderStatusRequest>
    {
        /// <summary>
        /// Статус заказа
        /// </summary>
        public eShopStatuses OrderStatus;
    }
}
