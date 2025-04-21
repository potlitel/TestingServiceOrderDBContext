using FSA.Core.Dtos;
using FSA.Core.ServiceOrders.Dtos;
using FSA.Core.ServiceOrders.Models;
using FSA.Core.ServiceOrders.Models.Masters;
using Microsoft.AspNetCore.Http.HttpResults;

namespace WebApiSO.Data.Dtos
{
    public class ServiceOrderTaskStateDto : MasterDto
    {
        public ServiceOrderTaskStateDto()
        {

        }

        public ServiceOrderTaskStateDto(ServiceOrderTaskStateDto item)
        {
            Id = item.Id;
            Code = item.Code;
            Description = item.Description;
            CreatedAt = item.CreatedAt;
            UpdatedAt = item.UpdatedAt;
            IsActive = item.IsActive;
        }

        public static ServiceOrderTaskStateDto ToDto(ServiceOrderTaskState entity)
        {
            if (entity == null)
            {
                return null;
            }

            return new ServiceOrderTaskStateDto
            {
                Id          = entity.Id,
                CreatedAt   = entity.CreatedAt,
                UpdatedAt   = entity.UpdatedAt,
                IsActive    = entity.IsActive,
                Code        = entity.Code,
                Description = entity.Description
            };
        }
    }
}
