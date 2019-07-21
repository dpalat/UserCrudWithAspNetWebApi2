using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using UserCrud.WebUI.Dtos;

namespace UserCrud.WebUI.Services
{
    public class UserService : IUserService
    {
        private HttpClient _httpClient = new HttpClient();

        public UserService()
        {
            _httpClient.BaseAddress = new Uri("http://localhost:50000/api/");
            _httpClient.DefaultRequestHeaders.Accept.Add(
               new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<UserDto>> GetAllUsersAsync()
        {
            var response = await _httpClient.GetAsync("Users");

            var jsonResponse = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode) return null;

            var usersDto = JsonConvert.DeserializeObject<List<UserDto>>(jsonResponse);

            return usersDto;
        }

        public async Task<UserDto> GetAsync(string id)
        {
            var response = await _httpClient.GetAsync($"Users/{id}");

            var jsonResponse = await response.Content.ReadAsStringAsync();

            var userDto = JsonConvert.DeserializeObject<UserDto>(jsonResponse);

            return userDto;
        }

        public async Task<UserDto> UpdateAsync(UserDto userDto)
        {
            var response = await _httpClient.PutAsJsonAsync($"Users/{userDto.Id}", userDto);

            var jsonResponse = await response.Content.ReadAsStringAsync();

            var userDtoUpdated = JsonConvert.DeserializeObject<UserDto>(jsonResponse);

            return userDtoUpdated;
        }

        public async Task DeleteAsync(string id)
        {
            await _httpClient.DeleteAsync($"Users/{id}");
        }

        public async Task<UserDto> CreateAsync(UserDto userDto)
        {
            var response = await _httpClient.PostAsJsonAsync($"Users", userDto);

            var jsonResponse = await response.Content.ReadAsStringAsync();

            var userDtoUpdated = JsonConvert.DeserializeObject<UserDto>(jsonResponse);

            return userDtoUpdated;
        }
    }
}