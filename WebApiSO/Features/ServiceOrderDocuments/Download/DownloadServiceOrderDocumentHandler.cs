using Azure.Storage.Blobs;
using FluentValidation;
using FSA.Core.DataTypes;
using FSA.Core.Dtos;
using FSA.Core.Interfaces;
using FSA.Core.Server.ServiceOrders.Implementations;
using FSA.Core.ServiceOrders.Utils;

namespace WebApiSO.Features.ServiceOrderDocuments.Download
{
    public class DownloadServiceOrderDocumentRequestValidator : AbstractValidator<DownloadServiceOrderDocumentRequest>
    {
        public DownloadServiceOrderDocumentRequestValidator()
        {
            RuleFor(x => x.blobName)
                    .NotNull().WithMessage("Please enter a Blog name");
        }
    }
    public class DownloadServiceOrderDocumentHandler : IServiceHandler<DownloadServiceOrderDocumentRequest, Stream>
    {
        private readonly IValidator<DownloadServiceOrderDocumentRequest> validator;
        private readonly IAzureStorageManager azureStorageManager;

        public DownloadServiceOrderDocumentHandler(IValidator<DownloadServiceOrderDocumentRequest> validator,
                                                   ISOAzureStorageManagerFactory azureStorageManagerFactory)
        {
            this.validator = validator;
            this.azureStorageManager = azureStorageManagerFactory.GetAzureStorageManager(SOAzureStorageContainers.SERVICE_ORDER_SERVICE_CONTAINER);
        }

        public async Task<Result<Stream>> Handle(DownloadServiceOrderDocumentRequest request)
        {
            var model = validator.Validate(request);
            if (!model.IsValid)
                return (Result<Stream>)Result.Failure(model.Errors.Select(e => e.ErrorMessage), CustomStatusCode.StatusBadRequest);

            // Create a BlobClient using the blob URL (with SAS token if needed)
            //var blobClient = new BlobClient(new Uri(blobUrl));

            //// Download the blob content
            //var downloadInfo = await blobClient.DownloadAsync();


            var result = await azureStorageManager.DownloadDocumentAsync(request.blobName);

            return Result<Stream>.SuccessWith(result, null!, CustomStatusCode.StatusOk);
        }
    }
}
