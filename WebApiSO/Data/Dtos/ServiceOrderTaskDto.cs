using FSA.Core.Dtos;
using FSA.Core.ServiceOrders.Dtos;
using FSA.Core.ServiceOrders.Models;
using WebApiSO.Models;

namespace WebApiSO.Data.Dtos
{
    public class ServiceOrderTaskDto : BaseDto
    {
        public string? Observations { get; set; }
        public DateTime ExecutionDate { get; set; }
        public long ServiceOrderTaskStateId { get; set; }
        public virtual ServiceOrderTaskStateDto? ServiceOrderTaskState { get; set; }
        public long ServiceOrderId { get; set; }
        public string CustomFieldSOTask { get; set; }
        public virtual ServiceOrderDto? ServiceOrder { get; set; }
        //public virtual IEnumerable<SupplyDto> Supplies { get; set; } = [];
        //public virtual IEnumerable<ServiceOrderTaskDocumentDto> Documents { get; set; } = [];

        public ServiceOrderTaskDto()
        {

        }

        public ServiceOrderTaskDto(ServiceOrderTaskDto dto)
        {
            Id = dto.Id;
            CreatedAt = dto.CreatedAt;
            UpdatedAt = dto.UpdatedAt;
            Observations = dto.Observations;
            ExecutionDate = dto.ExecutionDate;
            ServiceOrderTaskStateId = dto.ServiceOrderTaskStateId;
            ServiceOrderId = dto.ServiceOrderId;
            CustomFieldSOTask = dto.CustomFieldSOTask;
            //Supplies = dto.Supplies;
            //Documents = dto.Documents;
        }

        public static ServiceOrderTaskDto ToDto(CustomServiceOrderTask entity)
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
                CustomFieldSOTask = entity.CustomFieldSOTask
                //Supplies = (ICollection<SupplyDto>)entity.Supplies,
                //Documents = (ICollection<ServiceOrderTaskDocumentDto>)entity.Documents
            };
        }
    }
}
