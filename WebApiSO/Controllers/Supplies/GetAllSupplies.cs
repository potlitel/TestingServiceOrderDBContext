using FSA.Core.Dtos;
using FSA.Core.Utils;
using Microsoft.AspNetCore.Mvc;
using WebApiSO.Data.Dtos;
using WebApiSO.Features.Supplies;

namespace WebApiSO.Controllers.Supplies
{
    [ApiController]
    [ApiExplorerSettings(GroupName = "Supplies")]
    [Route("api/so/supplies/include-related-objects/all")]
    public class GetAllSupplies(GetSuppliesHandler handler) : ControllerBase
    {
        [HttpPost]
        public async Task<Result<IEnumerable<CustomSupplyDto>>> GetAll(Pagination? request, CancellationToken cancellationToken)
        {
            return await handler.Handle(request!);
        }
    }
}
