namespace DataObjects.DTO.Warehouse
{
    /// <summary>
    /// Описывает товары на складе и их количество
    /// </summary>
    public class WarehouseItemWithCount : WarehouseItem
    {
        //Количество товара
        public int Quantity;
    }
}
