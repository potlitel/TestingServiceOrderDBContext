using FSA.Core.Dtos;
using Microsoft.AspNetCore.Mvc;
using WebApiSO.Data.Dtos;
using WebApiSO.Features.ServiceOrderRegisters;

namespace WebApiSO.Controllers
{
    [ApiController]
    [ApiExplorerSettings(GroupName = "Services Orders: Registers")]
    [Route("api/so/registers/all")]
    public class GetAllRegisterBySOId : ControllerBase
    {
        GetServiceOrdersRegistersBySOIdHandler handler;

        public GetAllRegisterBySOId(GetServiceOrdersRegistersBySOIdHandler handler)
        {
            this.handler = handler;
        }

        [HttpGet("{id_so:int}")]
        public async Task<Result<IEnumerable<ServiceOrderRegisterDto>>> Get(long id_so)
        {
            return await handler.Handle(id_so);
        }
    }
}
