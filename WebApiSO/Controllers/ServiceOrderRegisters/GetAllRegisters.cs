using FSA.Core.Dtos;
using FSA.Core.Utils;
using Microsoft.AspNetCore.Mvc;
using WebApiSO.Data.Dtos;
using WebApiSO.Features.ServiceOrderRegisters.GetAll;

namespace WebApiSO.Controllers.ServiceOrderRegisters
{
    [ApiController]
    [ApiExplorerSettings(GroupName = "Services Orders: Registers")]
    [Route("api/so/registers/include-related-objects/all")]
    public class GetAllRegisters(GetServiceOrderRegistersHandler handler) : ControllerBase
    {
        [HttpPost]
        public async Task<Result<IEnumerable<ServiceOrderRegisterDto>>> GetAll(Pagination? request, CancellationToken cancellationToken)
        {
            return await handler.Handle(request!);
        }
    }
}
