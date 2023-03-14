using AutoMapper;

namespace Warehouse.src.WarehouseService.DataAdapters
{
    /// <summary>
    /// Должны быть рабочие конфигурации мапперов, но увы )
    /// </summary>
    internal class ShoppingItemTypeAdapter
    {
        /// <summary>
        /// Маппинг enum-а
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