using DataObjects.DTO.Warehouse;
using DataObjects.DTO.Warehouse.GetItemsList.Requests;
using DataObjects.DTO.Warehouse.MoveData.Move;
using System;
using System.Collections.Generic;

namespace Warehouse.interfaces
{
    /// <summary>
    /// Интерфейс сервиса, работающего с данными склада
    /// </summary>
    public interface IWarehouseService
    {
        /// <summary>
        /// Изменяет состояние выбранных товаров на складе
        /// </summary>
        /// <param name="actionType">Тип действия</param>
        /// <param name="items">Список товаров</param>
        /// <returns>True в случае успеха</returns>
        public bool MoveItems(eWarehouseActionTypes actionType, List<WarehouseItemWithCount> items);

        bool MoveItems(eWarehouseActionTypes actionType, Guid orderId);

        /// <summary>
        /// Получает все товары заданного типа
        /// </summary>
        /// <param name="itemType">Тип товара на складе</param>
        /// <returns>Список товаров заданного типа</returns>
        public List<WarehouseItem> GetItems(eWarehouseItemType itemType);

        /// <summary>
        /// Получает количество для каждого товара из списка
        /// </summary>
        /// <param name="item">Список товаров</param>
        /// <returns>Список товаров с количеством доступных для резервирования</returns>
        public List<WarehouseItemWithCount> GetItemsCount(List<WarehouseItem> item);
        

    }
}
