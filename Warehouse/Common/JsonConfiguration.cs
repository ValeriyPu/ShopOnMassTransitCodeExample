using Newtonsoft.Json;

namespace Common
{
    /// <summary>
    /// Сервис, содержащий сведения о конфигурации
    /// </summary>
    public abstract class JsonConfiguration<T>
        where T : class
    {
        /// <summary>
        /// Обьект десериализован
        /// </summary>
        private bool cached = false;

        /// <summary>
        /// Кэшированный обьект конфигурации
        /// </summary>
        private T conf = null;

        /// <summary>
        /// имя файла с JSON конфигурацией
        /// </summary>
        protected string FileName = "config.xml";


        /// <summary>
        /// Конфигурация
        /// </summary>
        public T Config
        {
            get
            {
                if (!cached)
                {
                    Cache();
                    cached = true;
                }

                return conf;
            }
        }

        /// <summary>
        /// Кэширование конфигурации
        /// </summary>
        private void Cache()
        {
            var txt = File.ReadAllText(FileName);

            conf = JsonConvert.DeserializeObject<T>(txt);
        }
    }
}