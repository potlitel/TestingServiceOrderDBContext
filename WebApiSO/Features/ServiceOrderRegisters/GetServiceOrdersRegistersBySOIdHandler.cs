using FSA.Core.DataTypes;
using FSA.Core.Dtos;
using FSA.Core.Interfaces;
using FSA.Core.ServiceOrders.Models;
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
            List<string> errors = [];
            if (!repository.Exist<ServiceOrderRegister>(id))
                errors.Add($"{typeof(ServiceOrderRegister).Name} not found");

            if (errors.Count > 0)
                return Result<IEnumerable<ServiceOrderRegisterDto>>.Failure(errors, CustomStatusCode.StatusBadRequest);


            var entityList = await repository.Entity<ServiceOrderRegister>()
                                             .Where(t => t.ServiceOrderId == id)
                                             .ToListAsync();

            //await appDbContext.Entry(entityList)
            //                  .Reference(e => e.ServiceOrder)
            //                  .LoadAsync();

            //var dependencides = await appDbContext.ServiceOrderRegisters.Where(e => e.ServiceOrderId == id)
            //                          .GetDependedDataFromEntriesAsync(appDbContext);

            var result = entityList.Select(ServiceOrderRegisterDto.ToDto);

            return Result<IEnumerable<ServiceOrderRegisterDto>>.SuccessWith(result!, CustomStatusCode.StatusOk);
        }
    }
}
