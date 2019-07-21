using AutoMapper;
using System;
using System.Collections.Generic;
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

        public IEnumerable<UserDto> Get()
        {
            var users = _usersDomain.GetAll();

            var usersDto = _mapper.Map<IEnumerable<Entity.User>, IEnumerable<UserDto>>(users);

            return usersDto;
        }

        public UserDto Get(string id)
        {
            var user = _usersDomain.Get(new Guid(id));
            return _mapper.Map<Entity.User, UserDto>(user);
        }

        [HttpPut]
        public UserDto Update(UserDto userDto)
        {
            var user = _mapper.Map<UserDto, Entity.User>(userDto);

            var userUpdated = _usersDomain.Update(user);

            var userDtoUpdated = _mapper.Map<Entity.User, UserDto>(userUpdated);

            return userDtoUpdated;
        }

        [HttpDelete]
        public void Delete(string id)
        {
            _usersDomain.Delete(new Guid(id));
        }

        [HttpPost]
        public UserDto Create(UserDto userDto)
        {
            var user = _mapper.Map<UserDto, Entity.User>(userDto);

            var userCreated = _usersDomain.Create(user);

            var userDtoCreated = _mapper.Map<Entity.User, UserDto>(userCreated);

            return userDtoCreated;
        }
    }
}