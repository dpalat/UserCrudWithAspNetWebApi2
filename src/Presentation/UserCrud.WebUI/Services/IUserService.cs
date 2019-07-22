using System.Collections.Generic;
using System.Threading.Tasks;
using UserCrud.WebUI.Dtos;

namespace UserCrud.WebUI.Services
{
    public interface IUserService
    {
        Task<List<UserDto>> GetAllUsersAsync(string accessToken);

        Task<UserDto> GetAsync(string id, string accessToken);

        Task<UserDto> UpdateAsync(UserDto userDto, string accessToken);

        Task<UserDto> CreateAsync(UserDto userDto, string accessToken);

        Task DeleteAsync(string id, string accessToken);
    }
}