using DataObjects.BaseItems.Notification;
using DataObjects.DTO.Shop.BuyItems.Requests;
using DataObjects.DTO.Warehouse.GetItemsList.Notification;
using DataObjects.MassTransit;
using DataObjects.MassTransit.AbstractConsumer;
using DataObjects.MassTransit.ConsumersRegistration;
using MassTransit;
using Microsoft.Extensions.Logging;
using Shopping.interfaces;


namespace Warehouse.src.Consumers
{
    [Consumer(queue = QueueNamesService.Queues.Shopping)]
    public class ShopCheckOrderStatusRequestConsumer : AbstractRequestConsumer<CheckOrderStatusRequest, IShoppingManager>
    {
        public ShopCheckOrderStatusRequestConsumer(ILogger<CheckOrderStatusRequest> logger, IShoppingManager service) : base(logger, service)
        {
        }

        protected override void ProcessRequest(ConsumeContext<CheckOrderStatusRequest> context, CheckOrderStatusRequest msg, IShoppingManager service, ILogger<CheckOrderStatusRequest> logger)
        {
            var status = service.CheckOrderStatus(msg.OrderId);
            
            context.Send<CheckOrderStatusNotification>(msg.ResponseQueueUri, new CheckOrderStatusNotification{ OriginalRequest = msg, OrderStatus = status });
        }
    }
}
