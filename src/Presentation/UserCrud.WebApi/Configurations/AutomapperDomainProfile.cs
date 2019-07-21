using AutoMapper;
using UserCrud.Entity;
using UserCrud.WebApi.Dtos;

namespace UserCrud.WebApi.Configurations
{
    public class AutomapperDomainProfile : Profile
    {
        public AutomapperDomainProfile()
        {
            CreateMap<User, UserDto>();
        }
    }
}