using FSA.Core.Dtos;

namespace WebApiSO.Data.Dtos
{
    public class UserDto : BaseDto
    {
        public string FirstName { get; set; } = string.Empty;


        public string LastName { get; set; } = string.Empty;


        public string Email { get; set; } = string.Empty;


        public string Phone { get; set; } = string.Empty;


        public int? CompanyId { get; set; }

        //public CompanyDto? Company { get; set; }

        public int? CompanyGroupId { get; set; }

        //public CompanyGroupDto? CompanyGroup { get; set; }

        public int? ConsortiumId { get; set; }

        //public ConsortiumDto? Consortium { get; set; }

        //public List<MembershipDto> Memberships { get; set; } = new List<MembershipDto>();


        public UserDto()
        {
        }

        public UserDto(UserDto item)
        {
            base.Id = ((BaseDto)item).Id;
            base.CreatedAt = item.CreatedAt;
            base.UpdatedAt = item.UpdatedAt;
            base.IsActive = item.IsActive;
            FirstName = item.FirstName;
            LastName = item.LastName;
            Email = item.Email;
            Phone = item.Phone;
            CompanyId = item.CompanyId;
            //Company = item.Company;
            //CompanyGroupId = item.CompanyGroupId;
            //CompanyGroup = item.CompanyGroup;
            //ConsortiumId = item.ConsortiumId;
            //Consortium = item.Consortium;
            //Memberships = item.Memberships;
        }

        public bool HasCompany()
        {
            if (CompanyId.HasValue)
            {
                return true;
            }

            return false;
        }

        public bool HasConsortium()
        {
            if (ConsortiumId.HasValue)
            {
                return true;
            }

            return false;
        }

        public bool HasCompanyGroup()
        {
            if (CompanyGroupId.HasValue)
            {
                return true;
            }

            return false;
        }
    }
}
