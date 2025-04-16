using Microsoft.AspNetCore.Mvc;
using WebApiSO.Data.Dtos;
using WebApiSO.Features.ServiceOrderRegisters;

namespace WebApiSO.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GetAllRegisterBySOId : ControllerBase
    {
        GetServiceOrdersRegistersBySOIdHandler handler;

        public GetAllRegisterBySOId(GetServiceOrdersRegistersBySOIdHandler handler)
        {
            this.handler = handler;
        }

        [HttpGet(Name = "GetSORegistersBySOId")]
        public async Task<IEnumerable<ServiceOrderRegisterDto>> Get(long id)
        {
            return (IEnumerable<ServiceOrderRegisterDto>)await handler.Handle(id).ToHttpResult();
        }
    }
}
