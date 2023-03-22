using System;
using static DataObjects.MassTransit.QueueNamesService;

namespace DataObjects.MassTransit.ConsumersRegistration
{
    /// <summary>
    /// Аттрибут для регистрации IConsumer-ов
    /// </summary>
    public class ConsumerAttribute : Attribute
    { 
        /// <summary>
        /// Очередь, сообщения из которой обрабатывает Consumer
        /// </summary>
        public Queues queue;
    }
}
