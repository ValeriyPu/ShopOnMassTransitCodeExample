using DatabaseItems.Database.Shopping;
using DatabaseItems.Database.Warehouse;
using Microsoft.EntityFrameworkCore;

namespace DatabaseItems.Database
{
    /// <summary>
    /// БД с заказами и товарам
    /// </summary>
    public class DatabaseContext : DbContext
    {
        /// <summary>
        /// Создает контекст БД используя указанную строку подключения
        /// </summary>
        /// <param name="connectionString">Строка подключения</param>
        public DatabaseContext(string connectionString) : base(GetOptions(connectionString))
        {
            if (Database.EnsureCreated()) Database.Migrate();
        }
        /// <summary>
        /// Необходимо для задания строки подключения 
        /// </summary>
        /// <param name="connectionString">строка подключения</param>
        /// <returns>ContextOptions</returns>
        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
        }
        /// <summary>
        /// Таблица с заказами
        /// </summary>
        public DbSet<OrderModel> Orders { get; set; }
        /// <summary>
        /// Таблица с товарами
        /// </summary>
        public DbSet<WarehouseItemModel> WarehouseItems { get; set; }

    }
}
