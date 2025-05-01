using FSA.Core.Dtos;
using Microsoft.AspNetCore.Mvc;
using WebApiSO.Data.Dtos;
using WebApiSO.Features.ServiceOrderDocuments.GetAllBySOId;

namespace WebApiSO.Controllers.ServiceOrdersDocuments
{
    [ApiController]
    [ApiExplorerSettings(GroupName = "Service Orders: Documents")]
    [Route("api/so/documents/all")]
    public class GetAllServiceOrdersDocumentsBySOId(GetServiceOrdersDocumentsBySOIdHandler handler) : ControllerBase
    {

        [HttpGet("{id_so:int}")]
        public async Task<Result<IEnumerable<ServiceOrderDocDto>>> Get(long id_so)
        {
            return await handler.Handle(id_so);
        }
    }
}
