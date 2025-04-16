using FSA.Core.Dtos;
using FSA.Core.Utils;
using Microsoft.AspNetCore.Mvc;
using WebApiSO.Data.Dtos;
using WebApiSO.Features.ServiceOrderTasks.GetAll;

namespace WebApiSO.Controllers.ServiceOrderTasks
{
    [ApiController]
    [ApiExplorerSettings(GroupName = "Services Orders: Tasks")]
    [Route("api/so/tasks/all")]
    public class GetAllServiceOrderTasks : ControllerBase
    {
        GetAllServiceOrderTasksHandler handler;

        public GetAllServiceOrderTasks(GetAllServiceOrderTasksHandler handler)
        {
            this.handler = handler;
        }

        [HttpPost]
        public async Task<Result<IEnumerable<ServiceOrderTaskDto>>> GetAll(Pagination? request, CancellationToken cancellationToken)
        {
            return await handler.Handle(request!);
        }
    }
}
