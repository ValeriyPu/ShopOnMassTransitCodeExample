using DataObjects.BaseItems;
using System.Collections.Generic;

namespace DataObjects.DTO.Warehouse.GetItemsList.Requests
{
    /// <summary>
    /// Запрос информации о наличии товара на складе
    /// </summary>
    public class WarehouseGetItemsCountRequest : BaseRequest
    {
        /// <summary>
        /// Список товаров, для которых запрашивается количество
        /// </summary>
        public List<WarehouseItem> items;
    }
}
