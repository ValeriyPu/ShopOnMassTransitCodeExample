using System;
using static DataObjects.MassTransit.QueueNamesService;

namespace DataObjects.MassTransit.ConsumersRegistration
{
    public class ConsumerAttribute : Attribute
    { 
        public Queues queue;
    }
}
