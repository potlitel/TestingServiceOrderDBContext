using FSA.Core.Dtos;
using FSA.Core.ServiceOrders.Dtos;
using FSA.Core.ServiceOrders.Models;

namespace WebApiSO.Data.Dtos
{
    public class CustomServiceOrderDto : BaseDto
    {
        public string Number { get; set; }
        public DateTime EstimatedEndingDate { get; set; }
        public string? Observations { get; set; }
        public string? Address { get; set; }
        public long OwnerId { get; set; }
        public long ExecutorId { get; set; }
        public long? ParentServiceOrderId { get; set; }
        public virtual ServiceOrderDto? ParentServiceOrder { get; set; }
        public long ServiceOrderTypeId { get; set; }
        public virtual ServiceOrderTypeDto? ServiceOrderType { get; set; }

        public virtual ICollection<ServiceOrderDocumentDto> Documents { get; set; } = [];
        public virtual ICollection<ServiceOrderTaskDto> Tasks { get; set; } = [];
        public virtual ICollection<ServiceOrderRegisterDto> Registers { get; set; } = [];
        public virtual ICollection<ServiceOrderFeatureDto> Features { get; set; } = [];

        public CustomServiceOrderDto()
        {
            
        }

        public CustomServiceOrderDto(CustomServiceOrderDto dto)
        {
            Id = dto.Id;
            CreatedAt = dto.CreatedAt;
            UpdatedAt = dto.UpdatedAt;
            IsActive = dto.IsActive;
            Address = dto.Address;
        }

        public static CustomServiceOrderDto ToDto(ServiceOrder entity)
        {
            if (entity == null)
            {
                return null!;
            }

            return new CustomServiceOrderDto
            {
                Id = entity.Id,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt,
                IsActive = entity.IsActive,
                Number = entity.Number,
                EstimatedEndingDate = entity.EstimatedEndingDate,
                Observations = entity.Observations,
                Address = entity.Address,
                OwnerId = entity.OwnerId,
                ExecutorId = entity.ExecutorId,
                ParentServiceOrderId = entity.ParentServiceOrderId,
                ServiceOrderTypeId = entity.ServiceOrderTypeId
            };
        }
    }
}
