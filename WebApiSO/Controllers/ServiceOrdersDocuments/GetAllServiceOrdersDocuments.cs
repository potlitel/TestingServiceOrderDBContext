using FSA.Core.Dtos;
using FSA.Core.Utils;
using Microsoft.AspNetCore.Mvc;
using WebApiSO.Data.Dtos;
using WebApiSO.Features.ServiceOrderDocuments.GetAll;

namespace WebApiSO.Controllers.ServiceOrdersDocuments
{
    [ApiController]
    [ApiExplorerSettings(GroupName = "Service Orders: Documents")]
    [Route("api/so/documents/include-related-objects/all")]
    public class GetAllServiceOrdersDocuments(GetAllServiceOrdersDocumentsHandler handler) : ControllerBase
    {
        [HttpPost]
        public async Task<Result<IEnumerable<ServiceOrderDocDto>>> GetAll(Pagination? request, CancellationToken cancellationToken)
        {
            return await handler.Handle(request!);
        }
    }
}
