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
    [Consumer(queue = QueueNamesService.Queues.Shopping)]
    public class ShopConfirmDeliveryOrderConsumer : AbstractRequestConsumer<ConfirmDeliveryOrderRequest, IShoppingManager>
    {
        public ShopConfirmDeliveryOrderConsumer(ILogger<ConfirmDeliveryOrderRequest> logger, IShoppingManager service) : base(logger, service)
        {
        }

        protected override void ProcessRequest(ConsumeContext<ConfirmDeliveryOrderRequest> context, ConfirmDeliveryOrderRequest msg, IShoppingManager service, ILogger<ConfirmDeliveryOrderRequest> logger)
        {
            if (service.ConfirmDeliveryOrder(msg.OrderId))
            {
                context.Send<BaseSuccessNotification<ConfirmDeliveryOrderRequest>>(msg.ResponseQueueUri, new BaseSuccessNotification<ConfirmDeliveryOrderRequest> { OriginalRequest = msg });

                //Отправим нотификацию в Common
                context.Send<BaseSuccessNotification<ConfirmDeliveryOrderRequest>>(QueueNamesService.GetQueueName(QueueNamesService.Queues.Common), new BaseSuccessNotification<ConfirmDeliveryOrderRequest> { OriginalRequest = msg });
            }
            else
            {
                context.Send<BaseFailNotification<ConfirmDeliveryOrderRequest>>(msg.ResponseQueueUri, new BaseSuccessNotification<ConfirmDeliveryOrderRequest> { OriginalRequest = msg });
            }
        }
    }
}
