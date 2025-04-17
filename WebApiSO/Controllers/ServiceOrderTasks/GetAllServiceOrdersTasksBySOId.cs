using FSA.Core.Dtos;
using Microsoft.AspNetCore.Mvc;
using WebApiSO.Data.Dtos;
using WebApiSO.Features.ServiceOrderTasks.GetBySOId;

namespace WebApiSO.Controllers.ServiceOrderTasks
{
    [ApiController]
    [ApiExplorerSettings(GroupName = "Services Orders: Tasks")]
    [Route("api/so/tasks/all")]
    public class GetAllServiceOrdersTasksBySOId(GetServiceOrdersTasksBySOIdHandler handler) : ControllerBase
    {
        [HttpGet("{id_SO:int}")]
        public async Task<Result<IEnumerable<ServiceOrderTaskDto>>> GetAll(long id_SO, CancellationToken cancellationToken)
        {
            return await handler.Handle(id_SO);
        }
    }
}
