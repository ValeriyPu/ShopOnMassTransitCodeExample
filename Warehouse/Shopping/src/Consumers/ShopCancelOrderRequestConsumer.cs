using DataObjects.BaseItems.Notification;
using DataObjects.DTO.Shop.BuyItems.Requests;
using DataObjects.DTO.Shop.CancelOrder.Notification;
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
                context.Respond<BaseSuccessNotification<CancelOrderRequest>>(new BaseSuccessNotification<CancelOrderRequest> { OriginalRequest = msg });

                var items = service.GetItems(msg.OrderId);
                //Отправим нотификацию в Common
                context.Send<ShopCancelOrderRequestNotification>(QueueNamesService.GetQueueName(QueueNamesService.Queues.Common), new ShopCancelOrderRequestNotification { ItemsToBuy = items });
            }
            else
            {
                context.Respond<BaseFailNotification<CancelOrderRequest>>(new BaseFailNotification<CancelOrderRequest> { OriginalRequest = msg });
            }
        }
    }
}
