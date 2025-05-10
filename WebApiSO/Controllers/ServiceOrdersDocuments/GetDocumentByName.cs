using Microsoft.AspNetCore.Mvc;
using WebApiSO.Features.ServiceOrderDocuments.Download;
using WebApiSO.Features.ServiceOrderDocuments.GetByName;
using WebApiSO.Helpers;

namespace WebApiSO.Controllers.ServiceOrdersDocuments
{
    [ApiController]
    [ApiExplorerSettings(GroupName = "Service Orders: Documents")]
    [Route("api/so/document/view")]
    public class GetDocumentByName(GetDocumentByNameHandler handler) : ControllerBase
    {
        [HttpPost]
        public async Task<string> Get(GetDocumentByNameRequest request)
        {
            var response = await handler.Handle(request);
            return response.Data!;
        }
    }
}
