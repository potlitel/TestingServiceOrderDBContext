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

            var entity = repository.Entity<Supply>();
            var supplyOperations = repository.Entity<SupplyOperation>();
            var serviceOrderTasks = repository.Entity<CustomServiceOrderTask>();

            entity = Search(entity, pagination);

            var result = entity.ApplyPagination(pagination).ToDynamicList<Supply>().Select(CustomSupplyDto.ToDto);

            List<CustomSupplyDto> newList = [];

            foreach (var item in result)
            {
                item.SupplyOperation = SupplyOperationDto.ToDto(await supplyOperations.FirstOrDefaultAsync(so => so.Id == item.SupplyOperationId));
                item.ServiceOrderTask = ServiceOrderTaskDto.ToDto(await serviceOrderTasks.FirstOrDefaultAsync(so => so.Id == item.ServiceOrderTaskId));
                newList.Add(item);
            }

            return Result<IEnumerable<CustomSupplyDto>>.SuccessWith(newList, pagination, CustomStatusCode.StatusOk);
        }

        private IQueryable<Supply> Search(IQueryable<Supply> query, Pagination pagination)
        {
            if (!string.IsNullOrEmpty(pagination.FilterTerm))
                return query.Where(q => q.Description.Contains(pagination.FilterTerm));
            return query;
        }
    }
}
