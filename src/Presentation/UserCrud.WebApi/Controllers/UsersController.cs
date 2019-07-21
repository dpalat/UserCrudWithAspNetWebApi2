using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using UserCrud.Domain;
using UserCrud.WebApi.Dtos;

namespace UserCrud.WebApi.Controllers
{
    public class UsersController : ApiController
    {
        private readonly IUsersDomain _usersDomain;
        private readonly IMapper _mapper;

        public UsersController(IUsersDomain usersDomain, IMapper mapper)
        {
            _usersDomain = usersDomain;
            _mapper = mapper;
        }

        // GET: api/Users
        public IEnumerable<UserDto> Get()
        {
            var users = _usersDomain.GetAll();

            var usersDto = _mapper.Map<IEnumerable<Entity.User>, IEnumerable<UserDto>>(users);

            return usersDto;
        }

        // GET: api/Users/5
        public UserDto Get(string id)
        {
            return Get().FirstOrDefault();
        }
    }
}