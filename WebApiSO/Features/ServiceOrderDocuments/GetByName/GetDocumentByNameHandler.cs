using Azure.Storage.Blobs;
using FluentValidation;
using FSA.Core.DataTypes;
using FSA.Core.Dtos;
using FSA.Core.Interfaces;
using FSA.Core.Server.ServiceOrders.Implementations;
using FSA.Core.ServiceOrders.Utils;
using WebApiSO.Features.ServiceOrderDocuments.Download;

namespace WebApiSO.Features.ServiceOrderDocuments.GetByName
{
    public class GetDocumentByNameRequestValidator : AbstractValidator<GetDocumentByNameRequest>
    {
        public GetDocumentByNameRequestValidator()
        {
            RuleFor(x => x.BlobName)
                    .NotNull().WithMessage("Please enter a Blog name");
        }
    }
    public class GetDocumentByNameHandler : IServiceHandler<GetDocumentByNameRequest, string>
    {
        private readonly IValidator<GetDocumentByNameRequest> validator;
        private readonly IAzureStorageManager azureStorageManager;

        private readonly BlobServiceClient _blobClient;
        private readonly BlobContainerClient _containerClient;
        const string ContainerName = "sodocuments";

        public GetDocumentByNameHandler(IValidator<GetDocumentByNameRequest> validator,
                                                   ISOAzureStorageManagerFactory azureStorageManagerFactory)
        {
            this.validator = validator;
            this.azureStorageManager = azureStorageManagerFactory.GetAzureStorageManager(SOAzureStorageContainers.SERVICE_ORDER_SERVICE_CONTAINER);

            _blobClient = new BlobServiceClient("UseDevelopmentStorage=true");
            _containerClient = _blobClient.GetBlobContainerClient(ContainerName);
            _containerClient.CreateIfNotExists();
        }

        public async Task<Result<string>> Handle(GetDocumentByNameRequest request)
        {
            var model = validator.Validate(request);
            if (!model.IsValid)
                return (Result<string>)Result.Failure(model.Errors.Select(e => e.ErrorMessage), CustomStatusCode.StatusBadRequest);

            var blobClient = _containerClient.GetBlobClient(request.BlobName);
            var url = blobClient.GenerateSasUri(Azure.Storage.Sas.BlobSasPermissions.Read, DateTimeOffset.UtcNow.AddDays(1));

            return Result<string>.SuccessWith(url.AbsoluteUri, null!, CustomStatusCode.StatusOk);
        }
    }
}
