using FSA.Core.DataTypes;
using FSA.Core.Dtos;
using FSA.Core.Extensions;
using FSA.Core.Interfaces;
using FSA.Core.ServiceOrders.Models;
using FSA.Core.Utils;
using System.Linq.Dynamic.Core;
using WebApiSO.Data.Dtos;
using WebApiSO.Models;

namespace WebApiSO.Features.ServiceOrderTasks.GetAll
{
    public class GetAllServiceOrderTasksHandler : IServiceHandler<Pagination, IEnumerable<ServiceOrderTaskDto>>
    {
        private readonly IRepository repository;

        public GetAllServiceOrderTasksHandler([FromKeyedServices("SO_Repository")] IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Result<IEnumerable<ServiceOrderTaskDto>>> Handle(Pagination pagination)
        {
            pagination = Pagination.Create(pagination);

            var entity = repository.Entity<CustomServiceOrderTask>();

            entity = Search(entity, pagination);

            var result = entity.ApplyPagination(pagination).ToDynamicList<CustomServiceOrderTask>().Select(ServiceOrderTaskDto.ToDto).ToList();

            return Result<IEnumerable<ServiceOrderTaskDto>>.SuccessWith(result, pagination, CustomStatusCode.StatusOk);
        }

        private IQueryable<CustomServiceOrderTask> Search(IQueryable<CustomServiceOrderTask> query, Pagination pagination)
        {
            if (!string.IsNullOrEmpty(pagination.FilterTerm))
                return query.Where(q => q.Observations!.Contains(pagination.FilterTerm));
            return query;
        }
    }
}
