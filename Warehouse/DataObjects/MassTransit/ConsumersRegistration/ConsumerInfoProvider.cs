using Common;
using System;

namespace DataObjects.MassTransit.ConsumersRegistration
{
    /// <summary>
    /// Класс с информацией о регистрации IConsumer-ов
    /// </summary>
    public class Info
    {
        /// <summary>
        /// Uri очереди сообщений
        /// </summary>
        public Uri QueueUri;
        /// <summary>
        /// ссылка на IConsumer тип 
        /// </summary>
        public Type type;
    }

    /// <summary>
    /// Сервис для получения всех типов с аттрибутом ConsumerAttribute и дополнительной информации о них
    /// </summary>
    public class ConsumerInfoProvider : AttributeProcessor<ConsumerAttribute, Info>
    {
        
        protected override ConsumersRegistration.Info processTypeAndAttribute(Type type, ConsumerAttribute attr)
        {
            var uri = QueueNamesService.GetQueueName(attr.queue);
            var typeVal = type;

            return new ConsumersRegistration.Info
            {
                QueueUri = uri,
                type = typeVal
            };
        }
    }
}
