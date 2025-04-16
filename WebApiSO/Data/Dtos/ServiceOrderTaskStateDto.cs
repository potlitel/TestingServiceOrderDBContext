using FSA.Core.Dtos;
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
    }
}
