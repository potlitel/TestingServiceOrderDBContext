using FSA.Core.DataTypes;
using FSA.Core.Dtos;
using FSA.Core.Extensions;
using FSA.Core.Interfaces;
using FSA.Core.ServiceOrders.Models;
using FSA.Core.Utils;
using System.Linq.Dynamic.Core;
using WebApiSO.Data.Dtos;
using WebApiSO.Models;

namespace WebApiSO.Features.ServiceOrderRegisters
{
    public class GetServiceOrdersRegistersBySOIdHandler : IServiceHandler<long, IEnumerable<ServiceOrderRegisterDto>>
    {
        private readonly IRepository repository;

        private readonly AppDbContext appDbContext;

        public GetServiceOrdersRegistersBySOIdHandler([FromKeyedServices("SO_Repository")] IRepository repository, AppDbContext appDbContext)
        {
            this.repository = repository;
            this.appDbContext = appDbContext;
        }

        public async Task<Result<IEnumerable<ServiceOrderRegisterDto>>> Handle(long id)
        {
            Pagination pagination = new Pagination(10);

            List<string> errors = [];
            if (!repository.Exist<ServiceOrder>(id))
                errors.Add($"{typeof(ServiceOrder).Name} not found");

            if (errors.Count > 0)
                return Result<IEnumerable<ServiceOrderRegisterDto>>.Failure(errors, CustomStatusCode.StatusBadRequest);


            var entityList = repository.Entity<ServiceOrderRegister>().Where(t => t.ServiceOrderId == id);

            entityList = Search(entityList, pagination);

            //await appDbContext.Entry(entityList)
            //                  .Reference(e => e.ServiceOrder)
            //                  .LoadAsync();

            //var dependencides = await appDbContext.ServiceOrderRegisters.Where(e => e.ServiceOrderId == id)
            //                          .GetDependedDataFromEntriesAsync(appDbContext);

            //var result = entityList.Select(ServiceOrderRegisterDto.ToDto);
            var result = entityList.ApplyPagination(pagination).ToDynamicList<ServiceOrderRegister>().Select(ServiceOrderRegisterDto.ToDto).ToList();

            return Result<IEnumerable<ServiceOrderRegisterDto>>.SuccessWith(result!, pagination, CustomStatusCode.StatusOk);
        }

        private IQueryable<ServiceOrderRegister> Search(IQueryable<ServiceOrderRegister> query, Pagination pagination)
        {
            if (!string.IsNullOrEmpty(pagination.FilterTerm))
                return query.Where(q => q.Observations!.Contains(pagination.FilterTerm));
            return query;
        }
    }
}
