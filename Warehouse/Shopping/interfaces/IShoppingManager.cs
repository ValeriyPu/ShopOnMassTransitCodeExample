﻿using DataObjects.DTO.Shop.CheckOrderStatus;
using DataObjects.DTO.Warehouse;
using System;
using System.Collections.Generic;

namespace Shopping.interfaces
{
    /// <summary>
    /// Интерфейс со всеми методами магазина
    /// </summary>
    public interface IShoppingManager
    {
        /// <summary>
        /// Отменить заказ
        /// </summary>
        /// <param name="request">запрос на изменение заказа</param>
        /// <returns></returns>
        public bool CancelOrder(Guid orderId);

        /// <summary>
        /// Запрос о получении статуса заказа
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public eShopStatuses CheckOrderStatus(Guid orderId);

        /// <summary>
        /// Создать заказ
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Guid CreateOrder(List<WarehouseItemWithCount> items, Guid userId );

        /// <summary>
        /// Получить товары для данного заказа
        /// </summary>
        /// <param name="orderId">Id заказа</param>
        /// <returns>Список заказов</returns>
        public List<WarehouseItemWithCount> GetItems(Guid orderId);

        /// <summary>
        /// Подтвердить получение заказа
        /// </summary>
        /// <param name="orderId">Id заказа</param>
        /// <returns>true в случае успеха</returns>
        public bool ConfirmDeliveryOrder(Guid orderId);

    }
}
