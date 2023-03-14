using DataObjects.BaseItems.Notification;
using DataObjects.DTO.Shop.BuyItems.Requests;
using DataObjects.MassTransit;
using DataObjects.MassTransit.AbstractConsumer;
using DataObjects.MassTransit.ConsumersRegistration;
using MassTransit;
using Microsoft.Extensions.Logging;
using Shopping.interfaces;


namespace Warehouse.src.Consumers
{
    [Consumer( queue = QueueNamesService.Queues.Shopping)]
    public class ShopCancelOrderRequestConsumer : AbstractRequestConsumer<CancelOrderRequest, IShoppingManager>
    {
        public ShopCancelOrderRequestConsumer(ILogger<CancelOrderRequest> logger, IShoppingManager service) : base(logger, service)
        {
        }

        protected override void ProcessRequest(ConsumeContext<CancelOrderRequest> context, CancelOrderRequest msg, IShoppingManager service, ILogger<CancelOrderRequest> logger)
        {
            if (service.CancelOrder(msg.OrderId))
            {
                context.Send<BaseSuccessNotification<CancelOrderRequest>>(msg.ResponseQueueUri, new BaseSuccessNotification<CancelOrderRequest> { OriginalRequest = msg });
                //Отправим нотификацию в Common
                context.Send<BaseSuccessNotification<CancelOrderRequest>>(QueueNamesService.GetQueueName(QueueNamesService.Queues.Common), new BaseSuccessNotification<CancelOrderRequest> { OriginalRequest = msg });
            }
            else
            {
                context.Send<BaseFailNotification<CancelOrderRequest>>(msg.ResponseQueueUri, new BaseSuccessNotification<CancelOrderRequest> { OriginalRequest = msg });
            }
        }
    }
}
