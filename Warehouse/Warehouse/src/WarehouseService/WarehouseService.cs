using AutoMapper;
using DatabaseItems;
using DatabaseItems.Database;
using DatabaseItems.Database.Warehouse;
using DataObjects.DTO.Warehouse;
using DataObjects.DTO.Warehouse.GetItemsList.Requests;
using DataObjects.DTO.Warehouse.MoveData.Move;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using Warehouse.interfaces;
using Warehouse.src.WarehouseService.DataAdapters;

namespace Warehouse.src.WarehouseService
{
    public class WarehouseService : IWarehouseService
    {
        /// <summary>
        /// Контекст БД
        /// </summary>
        DatabaseContext context;
        /// <summary>
        /// Сервис получения настроек
        /// </summary>
        ConfigurationService dis = new ConfigurationService();
        /// <summary>
        /// Логгер
        /// </summary>
        private readonly ILogger<Worker> _logger;

        /// <summary>
        /// Маппер enum-a
        /// </summary>
        private IMapper stateMapper = WarehouseItemTypeAdapter.stateConfiguration.CreateMapper();
        
        /// <summary>
        /// Маппер модели 
        /// </summary>
        private IMapper modelMapper = WarehouseItemTypeAdapter.modelConfiguration.CreateMapper();

        public WarehouseService()
        {
            context = new DatabaseContext(dis.Config.ConnectionString);
        }

        public List<WarehouseItem> GetItems(eWarehouseItemType itemType)
        {
            var targetState = stateMapper.Map<eState>(itemType);
            return context.WarehouseItems.Where(item => item.State == targetState)
                .Select(item=> modelMapper.Map<WarehouseItem>(item)).ToList();
        }

        public List<WarehouseItemWithCount> GetItemsCount(List<WarehouseItem> items)
        {
            var id_list = items.Select(item => item.TypeId);

            return context.WarehouseItems.Where(item => id_list.Contains(item.TypeId))
            .GroupBy(item => item.TypeId)
            .Select(item => new WarehouseItemWithCount { TypeId = item.Key, Quantity = item.Count() })
            .ToList();
        }

        public bool MoveItems(eWarehouseActionTypes actionType, Guid orderId)
        {
            var items = context.Orders.Where(item => item.Id == orderId).Select(item => item.Items).FirstOrDefault();
            return MoveItems(actionType, items.Select(item=> modelMapper.Map<WarehouseItemWithCount>(item)).ToList());
        }

        //CRUD с обработкой ошибок
        public bool MoveItems(eWarehouseActionTypes actionType, List<WarehouseItemWithCount> items)
        {
            try
            {
                var id_list = items.Select(item => item.Id);

                var itemsToProcess = context.WarehouseItems.Where(item => id_list.Contains(item.Id));

                if ((actionType == eWarehouseActionTypes.Unbook) ||
                    (actionType == eWarehouseActionTypes.Book))
                    foreach (var item in itemsToProcess)
                    {
                        preformAction(modelMapper.Map<WarehouseItem>(item), actionType);
                    }
                else
                {
                    switch (actionType)
                    {
                        case eWarehouseActionTypes.Add:
                            var data = modelMapper.Map<WarehouseItemModel>(items);

                            context.WarehouseItems.AddRange(data);
                            context.SaveChanges();
                            break;
                        case eWarehouseActionTypes.Remove:
                            var ids = items.Select(item => item.Id).ToList();
                            var items_to_delete = context.WarehouseItems.Where(item => ids.Contains(item.Id));

                            context.WarehouseItems.RemoveRange(items_to_delete);

                            context.SaveChanges();
                            break;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Меняет статус вещей на складе на заданный
        /// </summary>
        /// <param name="item">вещь на складе</param>
        /// <param name="actionType">действие</param>
        private void preformAction(WarehouseItem item, eWarehouseActionTypes actionType)
        {
            switch(actionType)
            {
                case eWarehouseActionTypes.Book:
                    item.State = eWarehouseState.Reserved;
                    break;
                case eWarehouseActionTypes.Unbook:
                    item.State = eWarehouseState.Avaible;
                    break;
            }
        }
    }
}
