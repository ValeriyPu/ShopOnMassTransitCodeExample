namespace DataObjects.DTO.Shop.CheckOrderStatus
{
    /// <summary>
    /// Статусы заказа
    /// </summary>
    public enum eShopStatuses
    {
        /// <summary>
        /// Забронирован
        /// </summary>
        Booked,
        /// <summary>
        /// Отменен
        /// </summary>
        Cancelled,
        /// <summary>
        /// Отправлен
        /// </summary>
        Sended,
        /// <summary>
        /// Получено подтверждение
        /// </summary>
        RecieveConfirm
    }
}
