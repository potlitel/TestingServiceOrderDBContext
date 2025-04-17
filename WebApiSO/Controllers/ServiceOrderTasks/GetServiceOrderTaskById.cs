using FSA.Core.Dtos;
using FSA.Core.Utils;
using Microsoft.AspNetCore.Mvc;
using WebApiSO.Data.Dtos;
using WebApiSO.Features.ServiceOrderTasks.GetById;

namespace WebApiSO.Controllers.ServiceOrderTasks
{
    [ApiController]
    [ApiExplorerSettings(GroupName = "Services Orders: Tasks")]
    [Route("api/so/tasks/")]
    public class GetServiceOrderTaskById(GetServiceOrderTaskByIdHandler handler) : ControllerBase
    {
        [HttpGet("{id:int}")]
        public async Task<Result<ServiceOrderTaskDto>> GetAll(long id, CancellationToken cancellationToken)
        {
            return await handler.Handle(id);
        }
    }
}
