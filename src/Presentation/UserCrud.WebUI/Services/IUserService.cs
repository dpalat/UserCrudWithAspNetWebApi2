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
        Task<List<UserDto>> GetAllUsersAsync();
        Task<UserDto> GetAsync(string id);
        Task<UserDto> UpdateAsync(UserDto userDto);
        Task<UserDto> CreateAsync(UserDto userDto);
        Task DeleteAsync(string id);
    }
}