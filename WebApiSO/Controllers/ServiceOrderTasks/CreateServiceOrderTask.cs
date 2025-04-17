using FSA.Core.Dtos;
using FSA.Core.Utils;
using Microsoft.AspNetCore.Mvc;
using WebApiSO.Data.Dtos;
using WebApiSO.Features.ServiceOrderTasks.Create;

namespace WebApiSO.Controllers.ServiceOrderTasks
{
    [ApiController]
    [ApiExplorerSettings(GroupName = "Services Orders: Tasks")]
    [Route("api/so/tasks/")]
    public class CreateServiceOrderTask(CreateServiceOrderTaskHandler handler) : ControllerBase
    {
        [HttpPost]
        public async Task<Result<ServiceOrderTaskDto>> Create(CreateServiceOrderTasksRequest request, CancellationToken cancellationToken)
        {
            return await handler.Handle(request!);
        }
    }
}
