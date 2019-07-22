using AutoMapper;
using System.Web.Mvc;
using UserCrud.Domain;
using UserCrud.WebApi.Dtos;

namespace UserCrud.WebApi.Controllers
{
    public class SecurityController : System.Web.Http.ApiController
    {
        private readonly IAuthenticationDomain _authenticationDomain;
        private readonly IMapper _mapper;

        public SecurityController(IAuthenticationDomain authenticationDomain, IMapper mapper)
        {
            _authenticationDomain = authenticationDomain;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("LogIn")]
        public UserDto LogIn([System.Web.Http.FromBody]LoginDto loginDto)
        {
            var user = _authenticationDomain.LogInUser(loginDto.UserEmail, loginDto.Password);
            var userDto = _mapper.Map<Entity.User, UserDto>(user);

            return userDto;
        }
    }
}