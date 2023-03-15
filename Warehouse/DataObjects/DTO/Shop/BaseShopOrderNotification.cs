using DataObjects.DTO.Warehouse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects.DTO.Shop
{
    /// <summary>
    /// Данные о заказе 
    /// </summary>
    public class BaseShopOrderNotification
    {
        /// <summary>
        /// Id заказа
        /// </summary>
        public Guid orderId;
        /// <summary>
        /// Список товаров
        /// </summary>
        public List<WarehouseItemWithCount> ItemsToBuy;
    }
}
