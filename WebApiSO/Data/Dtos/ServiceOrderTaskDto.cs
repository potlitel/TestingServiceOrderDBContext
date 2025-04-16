using FSA.Core.Dtos;
using FSA.Core.ServiceOrders.Dtos;
using FSA.Core.ServiceOrders.Models;

namespace WebApiSO.Data.Dtos
{
    public class ServiceOrderTaskDto : BaseDto
    {
        public string? Observations { get; set; }
        public DateTime ExecutionDate { get; set; }

        public long ServiceOrderTaskStateId { get; set; }
        public virtual ServiceOrderTaskStateDto? ServiceOrderTaskState { get; set; }
        public long ServiceOrderId { get; set; }
        public virtual ServiceOrderDto? ServiceOrder { get; set; }
        //public virtual IEnumerable<SupplyDto> Supplies { get; set; } = [];
        //public virtual IEnumerable<ServiceOrderTaskDocumentDto> Documents { get; set; } = [];

        public ServiceOrderTaskDto()
        {

        }

        public ServiceOrderTaskDto(ServiceOrderTaskDto dto)
        {
            Observations = dto.Observations;
            ExecutionDate = dto.ExecutionDate;
            ServiceOrderTaskStateId = dto.ServiceOrderTaskStateId;
            ServiceOrderId = dto.ServiceOrderId;
            //Supplies = dto.Supplies;
            //Documents = dto.Documents;
        }

        public static ServiceOrderTaskDto ToDto(ServiceOrderTask entity)
        {
            if (entity is null)
                return null!;

            return new ServiceOrderTaskDto
            {
                Id = entity.Id,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt,
                IsActive = entity.IsActive,
                Observations = entity.Observations,
                ExecutionDate = entity.ExecutionDate,
                ServiceOrderTaskStateId = entity.ServiceOrderTaskStateId,
                ServiceOrderId = entity.ServiceOrderId,
                //Supplies = (ICollection<SupplyDto>)entity.Supplies,
                //Documents = (ICollection<ServiceOrderTaskDocumentDto>)entity.Documents
            };
        }
    }
}
