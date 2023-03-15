using DataObjects.BaseItems;
using System;

namespace DataObjects.DTO.Shop.BuyItems.Requests
{
    /// <summary>
    /// Запрос на получение статуса заказа
    /// </summary>
    public class CheckOrderStatusRequest : BaseRequest
    {
        /// <summary>
        /// Id заказа
        /// </summary>
        public Guid OrderId;
    }
}
