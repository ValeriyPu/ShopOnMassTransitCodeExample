using AutoMapper;

namespace Warehouse.src.WarehouseService.DataAdapters
{
    /// <summary>
    /// Stub для маппинга
    /// </summary>
    internal class WarehouseItemTypeAdapter
    {
        /// <summary>
        /// Маппинг enum-a WarehouseItemState
        /// </summary>
        public static MapperConfiguration stateConfiguration = new MapperConfiguration(c =>
        {
            c.ReplaceMemberName("Ä", "A");
            c.ReplaceMemberName("í", "i");
            c.ReplaceMemberName("Airlina", "Airline");
        });
        /// <summary>
        /// Маппинг модели
        /// </summary>
        public static MapperConfiguration modelConfiguration = new MapperConfiguration(c =>
        {
            c.ReplaceMemberName("Ä", "A");
            c.ReplaceMemberName("í", "i");
            c.ReplaceMemberName("Airlina", "Airline");
        });
    }
}