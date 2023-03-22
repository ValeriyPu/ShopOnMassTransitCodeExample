using DataObjects.DTO.Warehouse.GetItemsList.Notification;
using DataObjects.DTO.Warehouse.GetItemsList.Requests;
using DataObjects.MassTransit;
using DataObjects.MassTransit.AbstractConsumer;
using DataObjects.MassTransit.ConsumersRegistration;
using MassTransit;
using Microsoft.Extensions.Logging;
using System;
using Warehouse.interfaces;

namespace Warehouse.src.Consumers
{
    /// <summary>
    /// Обработчик сообщений WarehouseItemListRequest
    /// </summary>
    [Consumer(queue = QueueNamesService.Queues.Warehouse)]
    public class WarehouseItemListRequestConsumer : AbstractRequestConsumer<WarehouseItemListRequest, IWarehouseService>
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="logger">логгер</param>
        /// <param name="service">сервис для работы со складом</param>
        public WarehouseItemListRequestConsumer(ILogger<WarehouseItemListRequest> logger, IWarehouseService service) : base(logger, service)
        {
        }

        /// <summary>
        /// Метод, обрабатывающий запрос количества товара
        /// </summary>
        /// <param name="context">контекст</param>
        /// <param name="msg">сообщение</param>
        /// <param name="service">сервис для работы со складом</param>
        /// <param name="logger">логгер</param>
        protected override void ProcessRequest(ConsumeContext<WarehouseItemListRequest> context, WarehouseItemListRequest msg, IWarehouseService service, ILogger<WarehouseItemListRequest> logger)
        {
            var items = service.GetItems(msg.ItemsType);

            var ans = new WarehouseItemListNotification()
            {
                Items = items
            };

           context.Send<WarehouseItemListNotification>(QueueNamesService.GetQueueName(QueueNamesService.Queues.Common), ans);
        }
    }
}
