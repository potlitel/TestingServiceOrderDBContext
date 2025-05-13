using FSA.Core.DataTypes;
using FSA.Core.Dtos;
using FSA.Core.Extensions;
using FSA.Core.Interfaces;
using FSA.Core.ServiceOrders.Dtos;
using FSA.Core.ServiceOrders.Models;
using FSA.Core.ServiceOrders.Models.Masters;
using FSA.Core.Utils;
using System.Collections.Concurrent;
using System.Linq.Dynamic.Core;
using WebApiSO.Data.Dtos;
using WebApiSO.Models;

namespace WebApiSO.Features.Supplies
{
    public class GetSuppliesHandler : IServiceHandler<Pagination, IEnumerable<CustomSupplyDto>>
    {
        private readonly IRepository repository;

        public GetSuppliesHandler([FromKeyedServices("SO_Repository")] IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Result<IEnumerable<CustomSupplyDto>>> Handle(Pagination pagination)
        {
            pagination = Pagination.Create(pagination);
            List<CustomSupplyDto> newList = [];

            GetEntities(out IQueryable<Supply> entity, out IQueryable<ServiceOrder> serviceOrders, out IQueryable<SupplyOperation> supplyOperations,
                        out IQueryable<CustomServiceOrderTask> serviceOrderTasks, out IQueryable<ServiceOrderTaskState> states,
                        out IQueryable<ServiceOrderType> types);

            entity = Search(entity, pagination);

            var result = entity.ApplyPagination(pagination).ToDynamicList<Supply>().Select(CustomSupplyDto.ToDto);
            
            ListsToDicts(serviceOrders, supplyOperations, serviceOrderTasks, states, types, out Dictionary<long, SupplyOperation> suppliesDic, 
                         out Dictionary<long, CustomServiceOrderTask> serviceOrdersTasksDic, out Dictionary<long, ServiceOrder> serviceOrdersDic, 
                         out Dictionary<long, ServiceOrderTaskState> statesDic, out Dictionary<long, ServiceOrderType> typesDic);

            foreach (var item in result)
            {
                UpdateItemProps(suppliesDic, serviceOrdersTasksDic, serviceOrdersDic, statesDic, typesDic, item);
                newList.Add(item);
            }

            return Result<IEnumerable<CustomSupplyDto>>.SuccessWith(newList, pagination, CustomStatusCode.StatusOk);
        }

        /// <summary>
        /// <see cref="UpdateItemProps"/>
        /// </summary>
        /// <param name="suppliesDic"></param>
        /// <param name="serviceOrdersTasksDic"></param>
        /// <param name="serviceOrdersDic"></param>
        /// <param name="statesDic"></param>
        /// <param name="typesDic"></param>
        /// <param name="item"></param>
        private static void UpdateItemProps(Dictionary<long, SupplyOperation> suppliesDic, 
                                            Dictionary<long, CustomServiceOrderTask> serviceOrdersTasksDic, 
                                            Dictionary<long, ServiceOrder> serviceOrdersDic, 
                                            Dictionary<long, ServiceOrderTaskState> statesDic, 
                                            Dictionary<long, ServiceOrderType> typesDic, 
                                            CustomSupplyDto item)
        {
            if (suppliesDic.TryGetValue(item.SupplyOperationId, out var supplyOperation))
                item.SupplyOperation = SupplyOperationDto.ToDto(supplyOperation);

            if (serviceOrdersTasksDic.TryGetValue(item.ServiceOrderTaskId, out var Task))
                item.ServiceOrderTask = ServiceOrderTaskDto.ToDto(Task);

            if (serviceOrdersDic.TryGetValue(item.ServiceOrderTask.ServiceOrderId, out var serviceOrder))
                item.ServiceOrderTask.ServiceOrder = CustomServiceOrderDto.ToDto(serviceOrder);

            if (statesDic.TryGetValue(item.ServiceOrderTask.ServiceOrderTaskStateId, out var state))
                item.ServiceOrderTask.ServiceOrderTaskState = ServiceOrderTaskStateDto.ToDto(state);

            if (typesDic.TryGetValue(item.ServiceOrderTask.ServiceOrder!.ServiceOrderTypeId, out var type))
                item.ServiceOrderTask.ServiceOrder.ServiceOrderType = ServiceOrderTypeDto.ToDto(type);
        }

        /// <summary>
        /// ListsToDicts
        /// </summary>
        /// <param name="serviceOrders"></param>
        /// <param name="supplyOperations"></param>
        /// <param name="serviceOrderTasks"></param>
        /// <param name="states"></param>
        /// <param name="types"></param>
        /// <param name="suppliesDic"></param>
        /// <param name="serviceOrdersTasksDic"></param>
        /// <param name="serviceOrdersDic"></param>
        /// <param name="statesDic"></param>
        /// <param name="typesDic"></param>
        private static void ListsToDicts(IQueryable<ServiceOrder> serviceOrders, IQueryable<SupplyOperation> supplyOperations, IQueryable<CustomServiceOrderTask> serviceOrderTasks, IQueryable<ServiceOrderTaskState> states, IQueryable<ServiceOrderType> types, out Dictionary<long, SupplyOperation> suppliesDic, out Dictionary<long, CustomServiceOrderTask> serviceOrdersTasksDic, out Dictionary<long, ServiceOrder> serviceOrdersDic, out Dictionary<long, ServiceOrderTaskState> statesDic, out Dictionary<long, ServiceOrderType> typesDic)
        {
            suppliesDic = supplyOperations.ToDictionary(supply => supply.Id);
            serviceOrdersTasksDic = serviceOrderTasks.ToDictionary(task => task.Id);
            serviceOrdersDic = serviceOrders.ToDictionary(serviceOrder => serviceOrder.Id);
            statesDic = states.ToDictionary(state => state.Id);
            typesDic = types.ToDictionary(type => type.Id);
        }

        /// <summary>
        /// <see cref="GetEntities"/>
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="serviceOrders"></param>
        /// <param name="supplyOperations"></param>
        /// <param name="serviceOrderTasks"></param>
        /// <param name="states"></param>
        /// <param name="types"></param>
        private void GetEntities(out IQueryable<Supply> entity, out IQueryable<ServiceOrder> serviceOrders, 
                                 out IQueryable<SupplyOperation> supplyOperations, out IQueryable<CustomServiceOrderTask> serviceOrderTasks, 
                                 out IQueryable<ServiceOrderTaskState> states, out IQueryable<ServiceOrderType> types)
        {
            entity = repository.Entity<Supply>();
            serviceOrders = repository.Entity<ServiceOrder>();
            supplyOperations = repository.Entity<SupplyOperation>();
            serviceOrderTasks = repository.Entity<CustomServiceOrderTask>();
            states = repository.Entity<ServiceOrderTaskState>();
            types = repository.Entity<ServiceOrderType>();
        }

        private IQueryable<Supply> Search(IQueryable<Supply> query, Pagination pagination)
        {
            if (!string.IsNullOrEmpty(pagination.FilterTerm))
                return query.Where(q => q.Description.Contains(pagination.FilterTerm));
            return query;
        }
    }
}
