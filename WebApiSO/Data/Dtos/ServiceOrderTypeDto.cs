using FSA.Core.Dtos;
using FSA.Core.ServiceOrders.Models;
using FSA.Core.ServiceOrders.Models.Masters;
using Microsoft.AspNetCore.Http.HttpResults;

namespace WebApiSO.Data.Dtos
{
    public class ServiceOrderTypeDto : MasterDto
    {
        public ServiceOrderTypeDto()
        {

        }

        public ServiceOrderTypeDto(ServiceOrderTypeDto item)
        {
            Id = item.Id;
            Code = item.Code;
            Description = item.Description;
            CreatedAt = item.CreatedAt;
            UpdatedAt = item.UpdatedAt;
            IsActive = item.IsActive;
        }

        /// <summary>
        /// <see cref="ToDto"/>: ...
        /// </summary>
        /// <param name="entity">ServiceOrderType instance</param>
        /// <returns></returns>
        public static ServiceOrderTypeDto ToDto(ServiceOrderType entity)
        {
            if (entity is null)
                return null!;

            return new ServiceOrderTypeDto
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
