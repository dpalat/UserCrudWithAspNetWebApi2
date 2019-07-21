using AutoMapper;
using UserCrud.Entity;
using UserCrud.WebApi.Dtos;

namespace UserCrud.WebApi.Configurations
{
    public class AutomapperWebApiProfile : Profile
    {
        public AutomapperWebApiProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
        }
    }
}