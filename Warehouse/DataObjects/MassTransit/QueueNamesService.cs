using System;
using System.Collections.Generic;

namespace DataObjects.MassTransit
{
    /// <summary>
    /// Сервис, содержащий имена очередей в MassTransit
    /// </summary>
    public class QueueNamesService
    {
        /// <summary>
        /// Список всех очередей
        /// </summary>
        public enum Queues
        {
            Common,
            Shopping,
            Warehouse
        }

        /// <summary>
        /// Возвращает имя очереди в MassTransit
        /// </summary>
        /// <param name="queues">Очередь</param>
        /// <returns>Имя очереди</returns>
        public static Uri GetQueueName(Queues queues)
        {
            return Names[queues];
        }

        /// <summary>
        /// Сопоставление списка всех очередей с именами
        /// </summary>
        protected static Dictionary<Queues, Uri> Names = new Dictionary<Queues, Uri>
        {
            {Queues.Common, new Uri("backend:common") },
            {Queues.Shopping, new Uri("backend:shopping")},
            {Queues.Warehouse, new Uri("backend:warehouse")}
        };
    }
}
