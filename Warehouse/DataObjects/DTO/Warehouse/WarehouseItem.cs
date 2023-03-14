using System;


namespace DataObjects.DTO.Warehouse
{
    /// <summary>
    /// Описывает товар на складе
    /// </summary>
    public class WarehouseItem
    {
        /// <summary>
        /// Идентификатор товара
        /// </summary>
        public Guid Id;
        //Имя товара
        public string Name;
        //Идентификатор товара на складе
        public Guid TypeId;
        //Статус товара
        public eWarehouseState State { get; set; }
    }
}
