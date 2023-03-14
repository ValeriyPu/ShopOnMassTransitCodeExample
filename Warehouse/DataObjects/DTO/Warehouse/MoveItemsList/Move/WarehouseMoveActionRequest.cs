using DataObjects.BaseItems;
using System.Collections.Generic;

namespace DataObjects.DTO.Warehouse.MoveData.Move
{
    /// <summary>
    /// Описывает базовую операцию на складе
    /// </summary>
    public class WarehouseMoveActionRequest : BaseRequest
    {
        /// <summary>
        /// Список товаров
        /// </summary>
        public List<WarehouseItemWithCount> Items;
        /// <summary>
        /// Действие
        /// </summary>
        public eWarehouseActionTypes Action;
    }
}
