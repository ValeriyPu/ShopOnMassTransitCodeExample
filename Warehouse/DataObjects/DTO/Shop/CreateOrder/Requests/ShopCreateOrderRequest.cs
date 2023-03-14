using DataObjects.BaseItems;
using DataObjects.DTO.Warehouse;
using System;
using System.Collections.Generic;

namespace DataObjects.DTO.Shop.BuyItems.Requests
{
    /// <summary>
    /// Обьект, описывающий базовые действия в магазине
    /// </summary>
    public class ShopCreateOrderRequest : BasePersonaficiedRequest
    {
        /// <summary>
        /// Список товаров
        /// </summary>
        public List<WarehouseItemWithCount> ItemsToBuy;

        /// <summary>
        /// Данные о пользователе
        /// </summary>
        public Guid userId;
    }
}
