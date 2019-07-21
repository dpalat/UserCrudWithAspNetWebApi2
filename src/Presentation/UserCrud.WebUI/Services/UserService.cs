using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using UserCrud.WebUI.Dtos;

namespace UserCrud.WebUI.Services
{
    public class UserService
    {
        private HttpClient _httpClient = new HttpClient();

        public async Task<List<UserDto>> GetAllUsers()
        {
            var response = await _httpClient.GetAsync("http://localhost:50000/api/Users");

            var jsonResponse = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode) return null;

            var usersDto = JsonConvert.DeserializeObject<List<UserDto>>(jsonResponse);

            return usersDto;
        }

        public async Task<UserDto> GetAsync(string id)
        {
            var response = await _httpClient.GetAsync($"http://localhost:50000/api/Users/{id}");

            var jsonResponse = await response.Content.ReadAsStringAsync();

            var userDto = JsonConvert.DeserializeObject<UserDto>(jsonResponse);

            return userDto;
        }
    }
}