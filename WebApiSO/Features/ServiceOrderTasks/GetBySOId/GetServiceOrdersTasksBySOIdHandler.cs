using FSA.Core.DataTypes;
using FSA.Core.Dtos;
using FSA.Core.Interfaces;
using WebApiSO.Data.Dtos;
using WebApiSO.Models;

namespace WebApiSO.Features.ServiceOrderTasks.GetBySOId
{
    public class GetServiceOrdersTasksBySOIdHandler : IServiceHandler<long, IEnumerable<ServiceOrderTaskDto>>
    {
        private readonly IRepository repository;

        public GetServiceOrdersTasksBySOIdHandler([FromKeyedServices("SO_Repository")] IRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// <see cref="Handle"/>: Obtiene un listado de todas las tareas de una orden de servicio partiendo del id de una orden de servicio.
        /// </summary>
        /// <param name="id">The service order's id</param>
        /// <returns>An instance of the <see cref="Task"/> object.</returns>
        public async Task<Result<IEnumerable<ServiceOrderTaskDto>>> Handle(long id)
        {
            var entity = repository.Entity<CustomServiceOrderTask>().Where(e => e.ServiceOrderId == id).ToList();

            var result = entity.Select(ServiceOrderTaskDto.ToDto);

            await Task.FromResult(result);

            return Result<IEnumerable<ServiceOrderTaskDto>>.SuccessWith(result!, CustomStatusCode.StatusOk);
        }
    }
}
