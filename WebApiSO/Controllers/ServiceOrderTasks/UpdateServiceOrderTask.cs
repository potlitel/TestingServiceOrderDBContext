using FSA.Core.Dtos;
using Microsoft.AspNetCore.Mvc;
using WebApiSO.Data.Dtos;
using WebApiSO.Features.ServiceOrderTasks.Create;
using WebApiSO.Features.ServiceOrderTasks.Update;

namespace WebApiSO.Controllers.ServiceOrderTasks
{
    [ApiController]
    [ApiExplorerSettings(GroupName = "Services Orders: Tasks")]
    [Route("api/so/tasks/")]
    public class UpdateServiceOrderTask(UpdateServiceOrderTaskHandler handler) : ControllerBase
    {
        [HttpPut]
        public async Task<Result> Create(UpdateServiceOrderTasksRequest request, CancellationToken cancellationToken)
        {
            return await handler.Handle(request!);
        }
    }
}
