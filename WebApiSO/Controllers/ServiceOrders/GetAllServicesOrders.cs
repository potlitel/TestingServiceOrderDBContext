using FSA.Core.Dtos;
using FSA.Core.ServiceOrders.Dtos;
using FSA.Core.Utils;
using Microsoft.AspNetCore.Mvc;
using WebApiSO.Data.Dtos;
using WebApiSO.Features.ServiceOrders.GetAll;

namespace WebApiSO.Controllers.ServiceOrders
{
    [ApiController]
    [ApiExplorerSettings(GroupName = "Services Orders")]
    [Route("api/so/include-related-objects/all")]
    public class GetAllServicesOrders(GetServiceOrdersHandler handler) : ControllerBase
    {
        [HttpPost]
        public async Task<Result<IEnumerable<CustomServiceOrderDto>>> GetAll(Pagination? request, CancellationToken cancellationToken)
        {
            return await handler.Handle(request!);
        }
    }
}
