using DataObjects.BaseItems;

namespace DataObjects.DTO.Warehouse.GetItemsList.Requests
{
    /// <summary>
    /// Запрос информации о наличии товара на складе
    /// </summary>
    public class WarehouseItemListRequest : BaseRequest
    {
        /// <summary>
        /// Тип товаров для запроса
        /// </summary>
        public eWarehouseItemType ItemsType;
    }
}
