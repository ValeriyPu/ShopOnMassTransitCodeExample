﻿using DataObjects.BaseItems.Notification;
using DataObjects.DTO.Shop.BuyItems.Requests;
using DataObjects.DTO.Warehouse.MoveData.Move;
using DataObjects.MassTransit;
using DataObjects.MassTransit.AbstractConsumer;
using DataObjects.MassTransit.ConsumersRegistration;
using MassTransit;
using Microsoft.Extensions.Logging;
using Shopping.interfaces;
using System;

namespace Warehouse.src.Consumers
{
    [Consumer(queue = QueueNamesService.Queues.Shopping)]
    public class ShopCreateOrderRequestConsumer : AbstractRequestConsumer<ShopCreateOrderRequest, IShoppingManager>
    {
        public ShopCreateOrderRequestConsumer(ILogger<ShopCreateOrderRequest> logger, IShoppingManager service) : base(logger, service)
        {
        }

        protected override void ProcessRequest(ConsumeContext<ShopCreateOrderRequest> context, ShopCreateOrderRequest msg, IShoppingManager service, ILogger<ShopCreateOrderRequest> logger)
        {
            try
            {
                var res = service.CreateOrder(msg.ItemsToBuy, msg.userId);

                context.Send<BaseSuccessNotification<ShopCreateOrderRequest>>(msg.ResponseQueueUri, new BaseSuccessNotification<ShopCreateOrderRequest> { MainObjectId = res, OriginalRequest = msg });

                context.Send<BaseSuccessNotification<ShopCreateOrderRequest>>(QueueNamesService.GetQueueName(QueueNamesService.Queues.Warehouse), new BaseSuccessNotification<ShopCreateOrderRequest> { MainObjectId = res, OriginalRequest = msg });
            }
            catch(Exception ex)
            {
                context.Send<BaseFailNotification<ShopCreateOrderRequest>>(msg.ResponseQueueUri, new BaseSuccessNotification<ShopCreateOrderRequest> { OriginalRequest = msg });
            }
        }
    }
}