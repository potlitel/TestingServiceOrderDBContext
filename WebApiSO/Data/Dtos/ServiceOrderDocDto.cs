using FSA.Core.Dtos;
using FSA.Core.ServiceOrders.Dtos;
using FSA.Core.ServiceOrders.Models;

namespace WebApiSO.Data.Dtos
{
    public class ServiceOrderDocDto : BaseDto
    {
        public required string Name { get; set; }
        public required string Url { get; set; }
        public long ServiceOrderId { get; set; }
        public virtual CustomServiceOrderDto? ServiceOrder { get; set; }
        public long DocumentTypeId { get; set; }
        public virtual DocumentTypeDto? DocumentType { get; set; }
        public static ServiceOrderDocDto ToDto(ServiceOrderDocument entity)
        {
            if (entity == null)
            {
                return null;
            }

            return new ServiceOrderDocDto
            {
                Id = entity.Id,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt,
                IsActive = entity.IsActive,
                Name = entity.Name,
                Url = entity.Url,
                ServiceOrderId = entity.ServiceOrderId,
                DocumentTypeId = entity.DocumentTypeId
            };
        }
    }
}
