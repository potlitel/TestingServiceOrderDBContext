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

namespace WebApiSO.Features.ServiceOrderRegisters.GetAll
{
    public class GetServiceOrderRegistersHandler : IServiceHandler<Pagination, IEnumerable<ServiceOrderRegisterDto>>
    {
        private readonly IRepository repository;

        public GetServiceOrderRegistersHandler([FromKeyedServices("SO_Repository")] IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Result<IEnumerable<ServiceOrderRegisterDto>>> Handle(Pagination pagination)
        {
            pagination = Pagination.Create(pagination);

            var entity = repository.Entity<ServiceOrderRegister>();
            var serviceOrders = repository.Entity<ServiceOrder>();
            var types = repository.Entity<ServiceOrderType>();

            entity = Search(entity, pagination);

            var result = entity.ApplyPagination(pagination).ToDynamicList<ServiceOrderRegister>().Select(ServiceOrderRegisterDto.ToDto);

            List<ServiceOrderRegisterDto> newList = [];

            foreach (var item in result)
            {
                item.ServiceOrder = CustomServiceOrderDto.ToDto(await serviceOrders.FirstOrDefaultAsync(so => so.Id == item.ServiceOrderId));
                item.ServiceOrder.ServiceOrderType = ServiceOrderTypeDto.ToDto(await types.FirstOrDefaultAsync(t => t.Id == item.ServiceOrder.ServiceOrderTypeId));
                newList.Add(item);
            }


            return Result<IEnumerable<ServiceOrderRegisterDto>>.SuccessWith(newList, pagination, CustomStatusCode.StatusOk);
        }

        private IQueryable<ServiceOrderRegister> Search(IQueryable<ServiceOrderRegister> query, Pagination pagination)
        {
            if (!string.IsNullOrEmpty(pagination.FilterTerm))
                return query.Where(q => q.Trigger.Contains(pagination.FilterTerm));
            return query;
        }
    }
}
