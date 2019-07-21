using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using UserCrud.WebUI.Dtos;

namespace UserCrud.WebUI.Services
{
    public interface IUserService
    {
        Task<List<UserDto>> GetAllUsers();
        Task<UserDto> GetAsync(string id);
        Task<UserDto> Update(UserDto userDto);
        Task DeleteAsync(string id);
    }
}