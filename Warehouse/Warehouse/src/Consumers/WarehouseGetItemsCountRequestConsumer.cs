using DataObjects.DTO.Warehouse.GetItemsList.Notification;
using DataObjects.DTO.Warehouse.GetItemsList.Requests;
using DataObjects.MassTransit;
using DataObjects.MassTransit.AbstractConsumer;
using DataObjects.MassTransit.ConsumersRegistration;
using MassTransit;
using Microsoft.Extensions.Logging;
using Warehouse.interfaces;

namespace Warehouse.src.Consumers
{
    /// <summary>
    /// Обработчик сообщений WarehouseGetItemsCountRequest
    /// </summary>
    [Consumer(queue = QueueNamesService.Queues.Warehouse)]
    public class WarehouseGetItemsCountRequestConsumer : AbstractRequestConsumer<WarehouseGetItemsCountRequest, IWarehouseService>
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="logger">логгер</param>
        /// <param name="service">сервис для работы со складом</param>
        public WarehouseGetItemsCountRequestConsumer(ILogger<WarehouseGetItemsCountRequest> logger, IWarehouseService service) : base(logger, service)
        {
        }

        /// <summary>
        /// Метод, обрабатывающий запрос количества товара
        /// </summary>
        /// <param name="context">контекст</param>
        /// <param name="msg">сообщение</param>
        /// <param name="service">сервис для работы со складом</param>
        /// <param name="logger">логгер</param>
        protected override void ProcessRequest(ConsumeContext<WarehouseGetItemsCountRequest> context, WarehouseGetItemsCountRequest msg, IWarehouseService service, ILogger<WarehouseGetItemsCountRequest> logger)
        {
            var res = service.GetItemsCount(msg.items);

            var ans = new WarehouseGetItemsCountNotification()
            {
                Items = res
            };

            context.Send<WarehouseGetItemsCountNotification>(QueueNamesService.GetQueueName(QueueNamesService.Queues.Common), ans);
        }
    }
}
