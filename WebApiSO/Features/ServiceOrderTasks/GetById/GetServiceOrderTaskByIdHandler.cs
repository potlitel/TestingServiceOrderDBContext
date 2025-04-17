using FSA.Core.DataTypes;
using FSA.Core.Dtos;
using FSA.Core.Interfaces;
using WebApiSO.Data.Dtos;
using WebApiSO.Models;

namespace WebApiSO.Features.ServiceOrderTasks.GetById
{
    public class GetServiceOrderTaskByIdHandler : IServiceHandler<long, ServiceOrderTaskDto>
    {
        private readonly IRepository repository;

        public GetServiceOrderTaskByIdHandler([FromKeyedServices("SO_Repository")] IRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// <see cref="Handle"/>: Obtiene un objeto de tipo ServiceOrderTask mediante su identificador.
        /// </summary>
        /// <param name="id">The identifier</param>
        /// <returns>An instance of the <see cref="Task"/> object.</returns>
        public async Task<Result<ServiceOrderTaskDto>> Handle(long id)
        {
            var entity = await repository.GetByIdAsync<CustomServiceOrderTask>(id);

            if (entity is null)
                return Result<ServiceOrderTaskDto>.Failure([$"{typeof(ServiceOrderTaskDto).Name} Not Found"], CustomStatusCode.StatusNotFound);

            var result = ServiceOrderTaskDto.ToDto(entity);

            return Result<ServiceOrderTaskDto>.SuccessWith(result!, CustomStatusCode.StatusOk);
        }
    }
}
