using FSA.Core.Dtos;
using FSA.Core.ServiceOrders.Dtos;
using FSA.Core.ServiceOrders.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace WebApiSO.Data.Dtos
{
    public class CustomSupplyDto : BaseDto
    {
        public int Amount { get; set; } = 0;
        public double Price { get; set; } = 0;
        public string Description { get; set; } = string.Empty;
        public long SupplyOperationId { get; set; }
        public SupplyOperationDto SupplyOperation { get; set; } = new();
        public long ServiceOrderTaskId { get; set; }
        public ServiceOrderTaskDto ServiceOrderTask { get; set; } = new();

        public CustomSupplyDto()
        {

        }

        /// <summary>
        /// Class 's constructor: Recibe un objeto dto (SupplyDto) e inicializa la clase SupplyDto con los valores de dicho objeto
        /// </summary>
        /// <param name="dto">SupplyDto instance</param>
        public CustomSupplyDto(CustomSupplyDto dto)
        {
            Id = dto.Id;
            CreatedAt = dto.CreatedAt;
            UpdatedAt = dto.UpdatedAt;
            IsActive = dto.IsActive;
            Amount = dto.Amount;
            Price = dto.Price;
            Description = dto.Description;
            SupplyOperation = dto.SupplyOperation;
            SupplyOperationId = dto.SupplyOperationId;
            ServiceOrderTask = dto.ServiceOrderTask;
            ServiceOrderTaskId = dto.ServiceOrderTaskId;
        }

        public static CustomSupplyDto ToDto(Supply entity)
        {
            if (entity is null)
                return null!;

            return new CustomSupplyDto
            {
                Id = entity.Id,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt,
                IsActive = entity.IsActive,
                Amount = entity.Amount,
                Price = entity.Price,
                Description = entity.Description,
                SupplyOperationId = entity.SupplyOperationId,
                ServiceOrderTaskId = entity.ServiceOrderTaskId
            };
        }
    }
}
