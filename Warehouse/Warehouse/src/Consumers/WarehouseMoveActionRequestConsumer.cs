using DataObjects.DTO.Warehouse.MoveData.Move;
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
    /// Обработчик сообщений WarehouseMoveActionRequest
    /// </summary>
    [Consumer(queue = QueueNamesService.Queues.Warehouse)]
    public class WarehouseMoveActionRequestConsumer : AbstractRequestConsumer<WarehouseMoveActionRequest, IWarehouseService>
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="logger">логгер</param>
        /// <param name="service">сервис для работы со складом</param>
        public WarehouseMoveActionRequestConsumer(ILogger<WarehouseMoveActionRequest> logger, IWarehouseService service) : base(logger, service)
        {
        }

        /// <summary>
        /// Метод, обрабатывающий запрос количества товара
        /// </summary>
        /// <param name="context">контекст</param>
        /// <param name="msg">сообщение</param>
        /// <param name="service">сервис для работы со складом</param>
        /// <param name="logger">логгер</param>
        protected override void ProcessRequest(ConsumeContext<WarehouseMoveActionRequest> context, WarehouseMoveActionRequest msg, IWarehouseService service, ILogger<WarehouseMoveActionRequest> logger)
        {
            if (!service.MoveItems(msg.Action, msg.Items))
            {
                throw new Exception("Cant process message");
            }
        }
    }
}
