using Microsoft.AspNetCore.Mvc;
using WebApiSO.Features.ServiceOrderDocuments.Download;

namespace WebApiSO.Controllers.ServiceOrdersDocuments
{
    [ApiController]
    [ApiExplorerSettings(GroupName = "Service Orders: Documents")]
    [Route("api/so/document/downloadAsStream")]
    public class DownloadServiceOrderDocumentAsStream(DownloadServiceOrderDocumentHandler handler) : ControllerBase
    {
        [HttpPost]
        public async Task<Stream> Get(DownloadServiceOrderDocumentRequest request)
        {
            var response = await handler.Handle(request);

            return response.Data!;
        }
    }
}
