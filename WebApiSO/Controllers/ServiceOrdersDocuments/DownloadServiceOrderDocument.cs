using FSA.Core.Dtos;
using Microsoft.AspNetCore.Mvc;
using WebApiSO.Features.ServiceOrderDocuments.Download;
using WebApiSO.Helpers;

namespace WebApiSO.Controllers.ServiceOrdersDocuments
{
    [ApiController]
    [ApiExplorerSettings(GroupName = "Service Orders: Documents")]
    [Route("api/so/document/download")]
    public class DownloadServiceOrderDocument(DownloadServiceOrderDocumentHandler handler) : ControllerBase
    {
        [HttpPost]
        public async Task<FileContentResult> Get(DownloadServiceOrderDocumentRequest request)
        {
            var response = await handler.Handle(request);
            var bytes = Utils.StreamToByteArrayUsingBinaryReader(response.Data!);
            // Return the blob content as a file
            return File(
                bytes,
                "application/octet-stream",
                Path.GetFileName(request.blobName)
            );
        }
    }
}
