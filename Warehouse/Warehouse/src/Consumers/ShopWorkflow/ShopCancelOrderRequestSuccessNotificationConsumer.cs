using DataObjects.BaseItems.Notification;
using DataObjects.DTO.Shop.BuyItems.Requests;
using DataObjects.DTO.Warehouse.GetItemsList.Notification;
using DataObjects.DTO.Warehouse.GetItemsList.Requests;
using DataObjects.MassTransit;
using DataObjects.MassTransit.AbstractConsumer;
using DataObjects.MassTransit.ConsumersRegistration;
using MassTransit;
using Microsoft.Extensions.Logging;
using Warehouse.interfaces;

namespace Warehouse.src.Consumers.ShopWorkflow
{
    /// <summary>
    /// Обработчик сообщений BaseSuccessNotification<ShopCreateOrderRequest>
    /// </summary>
    [Consumer(queue = QueueNamesService.Queues.Common)]
    public class ShopCancelOrderRequestSuccessNotificationConsumer : AbstractRequestConsumer<BaseSuccessNotification<CancelOrderRequest>, IWarehouseService>
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="logger">логгер</param>
        /// <param name="service">сервис для работы со складом</param>
        public ShopCancelOrderRequestSuccessNotificationConsumer(ILogger<BaseSuccessNotification<CancelOrderRequest>> logger, IWarehouseService service) : base(logger, service)
        {
        }

        /// <summary>
        /// Метод, обрабатывающий сообщение об отмене заказа
        /// </summary>
        /// <param name="context">контекст</param>
        /// <param name="msg">сообщение</param>
        /// <param name="service">сервис для работы со складом</param>
        /// <param name="logger">логгер</param>
        protected override void ProcessRequest(ConsumeContext<BaseSuccessNotification<CancelOrderRequest>> context, BaseSuccessNotification<CancelOrderRequest> msg, IWarehouseService service, ILogger<BaseSuccessNotification<CancelOrderRequest>> logger)
        {
            var res = service.MoveItems(DataObjects.DTO.Warehouse.MoveData.Move.eWarehouseActionTypes.Unbook, msg.OriginalRequest.OrderId);

            if (res == false)
            {
                var ans = new CancelOrderRequest { OrderId = msg.MainObjectId };
                context.Send(QueueNamesService.GetQueueName(QueueNamesService.Queues.Shopping), ans);
            };
        }
    }
}
