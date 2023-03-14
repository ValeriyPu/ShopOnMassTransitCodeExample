using Common;
using System;

namespace DataObjects.MassTransit.ConsumersRegistration
{
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
