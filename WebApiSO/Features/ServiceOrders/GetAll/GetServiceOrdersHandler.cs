using FSA.Core.DataTypes;
using FSA.Core.Dtos;
using FSA.Core.Extensions;
using FSA.Core.Interfaces;
using FSA.Core.ServiceOrders.Dtos;
using FSA.Core.ServiceOrders.Models;
using FSA.Core.ServiceOrders.Models.Masters;
using FSA.Core.Utils;
using System.Linq.Dynamic.Core;
using WebApiSO.Data.Dtos;
using ServiceOrderRegisterDto = WebApiSO.Data.Dtos.ServiceOrderRegisterDto;

namespace WebApiSO.Features.ServiceOrders.GetAll
{
    public class GetServiceOrdersHandler : IServiceHandler<Pagination, IEnumerable<CustomServiceOrderDto>>
    {
        private readonly IRepository repository;

        public GetServiceOrdersHandler([FromKeyedServices("SO_Repository")] IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Result<IEnumerable<CustomServiceOrderDto>>> Handle(Pagination pagination)
        {
            pagination = Pagination.Create(pagination);

            var entity = repository.Entity<ServiceOrder>();
            var extraEntitySO = repository.Entity<ServiceOrder>();
            var types = repository.Entity<ServiceOrderType>();
            var registers = repository.Entity<ServiceOrderRegister>();

            entity = Search(entity, pagination);

            var result = entity.ApplyPagination(pagination).ToDynamicList<ServiceOrder>().Select(CustomServiceOrderDto.ToDto);

            List<CustomServiceOrderDto> newList = [];

            foreach (var item in result)
            {
                item.ServiceOrderType = ServiceOrderTypeDto.ToDto(await types.FirstOrDefaultAsync(t => t.Id == item.ServiceOrderTypeId));
                item.ParentServiceOrder = ServiceOrderDto.ToDto(await extraEntitySO.FirstOrDefaultAsync(so => so.Id == item.ParentServiceOrderId));
                item.Registers = registers.Where(reg => reg.ServiceOrderId == item.Id).Select(ServiceOrderRegisterDto.ToDto).ToList();

                newList.Add(item);
            }

            return Result<IEnumerable<CustomServiceOrderDto>>.SuccessWith(newList, pagination, CustomStatusCode.StatusOk);
        }

        private IQueryable<ServiceOrder> Search(IQueryable<ServiceOrder> query, Pagination pagination)
        {
            if (!string.IsNullOrEmpty(pagination.FilterTerm))
                return query.Where(q => q.Address!.Contains(pagination.FilterTerm));
            return query;
        }
    }
}
