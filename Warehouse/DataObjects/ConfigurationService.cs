using Common;

namespace DatabaseItems
{
    /// <summary>
    /// Обьект конфигурации очереди и БД
    /// </summary>
    public class Config
    {
        /// <summary>
        /// Текст строки подключения к БД
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// Url подключения к Masstransit
        /// </summary>
        public string MassTransitConnectionParams { get; set; }
    }

    /// <summary>
    /// Сервис, содержащий сведения для работы с БД и очередью
    /// </summary>
    public class ConfigurationService : JsonConfiguration<Config>
    {
       public ConfigurationService() 
        {
            FileName = "DbMtConf.json";
        }
    }
}
