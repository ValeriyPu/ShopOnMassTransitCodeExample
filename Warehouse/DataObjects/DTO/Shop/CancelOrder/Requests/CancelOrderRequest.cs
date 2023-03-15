using DataObjects.BaseItems;
using System;

namespace DataObjects.DTO.Shop.BuyItems.Requests
{
    /// <summary>
    /// Запрос на отмену заказа
    /// </summary>
    public class CancelOrderRequest : BaseRequest
    {
        /// <summary>
        /// Id заказа
        /// </summary>
        public Guid OrderId;
    }
}
