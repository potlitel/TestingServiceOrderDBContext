using FSA.Core.Dtos;
using FSA.Core.ServiceOrders.Models;
using FSA.Core.ServiceOrders.Models.Masters;

namespace WebApiSO.Data.Dtos
{
    public class SupplyOperationDto : MasterDto
    {
        public SupplyOperationDto()
        {

        }

        public SupplyOperationDto(SupplyOperationDto item)
        {
            Id = item.Id;
            Code = item.Code;
            Description = item.Description;
            CreatedAt = item.CreatedAt;
            UpdatedAt = item.UpdatedAt;
            IsActive = item.IsActive;
        }

        public static SupplyOperationDto ToDto(SupplyOperation entity)
        {
            if (entity is null)
                return null!;

            return new SupplyOperationDto
            {
                Id = entity.Id,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt,
                IsActive = entity.IsActive,
                Code = entity.Code,
                Description = entity.Description,
            };
        }
    }
}
