using AutoMapper;
using DatabaseItems;
using DatabaseItems.Database;
using DataObjects.DTO.Shop.CheckOrderStatus;
using DataObjects.DTO.Warehouse;
using Microsoft.Extensions.Logging;
using Shopping.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using Warehouse.src.WarehouseService.DataAdapters;

namespace Shopping.src.ShoppingService
{
    class ShoppingService : IShoppingManager
    {
        //TODO: check lifetime management
        ConfigurationService dis = new ConfigurationService();

        DatabaseContext context;

        private readonly ILogger<Worker> _logger;

        private IMapper stateMapper = ShoppingItemTypeAdapter.stateConfiguration.CreateMapper();

        private IMapper modelMapper = ShoppingItemTypeAdapter.modelConfiguration.CreateMapper();

        public ShoppingService()
        {
            context = new DatabaseContext(dis.Config.ConnectionString);
        }

        public bool CancelOrder(Guid orderId)
        {
            try
            {
                var item = context.Orders.FirstOrDefault(item => item.Id == orderId);
                if (item != null)
                {
                    item.OrderState = DatabaseItems.Database.Shopping.eOrderState.Cancelled;
                    context.Orders.Update(item);

                    return true;
                }
                else
                {
                    _logger.LogError("No order found with id :" + orderId.ToString());
                    return false;
                }
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.ToString());
                return false;
            }
        }

        public eShopStatuses CheckOrderStatus(Guid orderId)
        {
            var item = context.Orders.FirstOrDefault(item => item.Id == orderId);
            if (item != null)
            {
                return modelMapper.Map<eShopStatuses>(item.OrderState);
            }

            return eShopStatuses.Cancelled;
            
        }

        public bool ConfirmDeliveryOrder(Guid orderId)
        {
            try
            {
                var item = context.Orders.FirstOrDefault(item => item.Id == orderId);
                if (item != null)
                {
                    item.OrderState = DatabaseItems.Database.Shopping.eOrderState.RecieveConfirm;
                    context.Orders.Update(item);

                    return true;
                }
                else
                {
                    _logger.LogError("No order found with id :" + orderId.ToString());
                    return false;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return false;
            }
        }

        public Guid CreateOrder(List<WarehouseItemWithCount> items, Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}
