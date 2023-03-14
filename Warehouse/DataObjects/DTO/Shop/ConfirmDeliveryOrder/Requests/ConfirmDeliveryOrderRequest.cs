using DataObjects.BaseItems;
using System;

namespace DataObjects.DTO.Shop.BuyItems.Requests
{
    /// <summary>
    /// Запрос на подтверждение получения заказа
    /// </summary>
    public class ConfirmDeliveryOrderRequest : BasePersonaficiedRequest
    {
        /// <summary>
        /// Id заказа
        /// </summary>
        public Guid OrderId;
    }
}
