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

        private readonly BlobServiceClient _blobClient;
        private readonly BlobContainerClient _containerClient;
        const string ContainerName = "sodocuments";

        public DownloadServiceOrderDocumentHandler(IValidator<DownloadServiceOrderDocumentRequest> validator,
                                                   ISOAzureStorageManagerFactory azureStorageManagerFactory)
        {
            this.validator = validator;
            this.azureStorageManager = azureStorageManagerFactory.GetAzureStorageManager(SOAzureStorageContainers.SERVICE_ORDER_SERVICE_CONTAINER);

            _blobClient = new BlobServiceClient("UseDevelopmentStorage=true");
            _containerClient = _blobClient.GetBlobContainerClient(ContainerName);
            _containerClient.CreateIfNotExists();
        }

        public async Task<Result<Stream>> Handle(DownloadServiceOrderDocumentRequest request)
        {
            var model = validator.Validate(request);
            if (!model.IsValid)
                return (Result<Stream>)Result.Failure(model.Errors.Select(e => e.ErrorMessage), CustomStatusCode.StatusBadRequest);

            #region Working 
            //https://www.c-sharpcorner.com/article/mastering-azure-blob-storage-with-asp-net-core-mvc/
            var blobClient = _containerClient.GetBlobClient(request.blobName);
            var ms = new MemoryStream();
            blobClient.DownloadTo(ms);
            ms.Position = 0;
            #endregion

            var result = await azureStorageManager.DownloadDocumentAsync(request.blobName);

            return Result<Stream>.SuccessWith(ms, null!, CustomStatusCode.StatusOk);
        }
    }
}
