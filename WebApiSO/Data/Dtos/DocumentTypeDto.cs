using FSA.Core.Dtos;
using FSA.Core.ServiceOrders.Models;
using FSA.Core.ServiceOrders.Models.Masters;
using FSA.Core.Utils;

namespace WebApiSO.Data.Dtos
{
    public class DocumentTypeDto : MasterDto
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTimeHelper.Now();
        public DateTime UpdatedAt { get; set; } = DateTimeHelper.Now();
        public bool IsActive { get; set; } = true;

        public DocumentTypeDto()
        {

        }

        public DocumentTypeDto(DocumentTypeDto item)
        {
            Id = Convert.ToInt32(item.Id);
            Code = item.Code;
            Description = item.Description;
            CreatedAt = item.CreatedAt;
            UpdatedAt = item.UpdatedAt;
            IsActive = item.IsActive;
        }

        public static DocumentTypeDto ToDto(DocumentType entity)
        {
            if (entity == null)
            {
                return null;
            }

            return new DocumentTypeDto
            {
                Id = (int)entity.Id,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt,
                IsActive = entity.IsActive,
                Code = entity.Code,
                Description = entity.Description
            };
        }
    }
}
