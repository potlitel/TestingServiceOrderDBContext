using FluentValidation;
using WebApiSO.Features.ServiceOrderDocuments.Download;

namespace WebApiSO.Features.ServiceOrderDocuments.DownloadAsStream
{
    public class DownloadServiceOrderDocumentAsStreamRequestValidator : AbstractValidator<DownloadServiceOrderDocumentAsStreamRequest>
    {
        public DownloadServiceOrderDocumentAsStreamRequestValidator()
        {
            RuleFor(x => x.blobName)
                    .NotNull().WithMessage("Please enter a Blog name");
        }
    }
    public class DownloadServiceOrderDocumentAsStreamHandler
    {
    }
}
