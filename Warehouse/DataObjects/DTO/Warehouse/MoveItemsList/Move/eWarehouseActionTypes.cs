namespace DataObjects.DTO.Warehouse.MoveData.Move
{
    /// <summary>
    /// Возможные операции на складе
    /// </summary>
    public enum eWarehouseActionTypes
    {
        /// <summary>
        /// Добавить товары
        /// </summary>
        Add,
        /// <summary>
        /// Удалить товары
        /// </summary>
        Remove,
        /// <summary>
        /// Зарезервировать товары
        /// </summary>
        Book,
        /// <summary>
        /// Отменить резерв
        /// </summary>
        Unbook
    }
}
