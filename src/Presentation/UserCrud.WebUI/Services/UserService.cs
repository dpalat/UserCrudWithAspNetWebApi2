using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using UserCrud.WebUI.Dtos;

namespace UserCrud.WebUI.Services
{
    public class UserService : IUserService
    {
        private HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        private void SetAuthenticationBasicToken(string accessToken)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", accessToken);
        }

        public async Task<List<UserDto>> GetAllUsersAsync(string accessToken)
        {
            SetAuthenticationBasicToken(accessToken);
            var response = await _httpClient.GetAsync("Users");

            var jsonResponse = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode) return null;

            var usersDto = JsonConvert.DeserializeObject<List<UserDto>>(jsonResponse);

            return usersDto;
        }

        public async Task<UserDto> GetAsync(string id, string accessToken)
        {
            SetAuthenticationBasicToken(accessToken);
            var response = await _httpClient.GetAsync($"Users/{id}");

            var jsonResponse = await response.Content.ReadAsStringAsync();

            var userDto = JsonConvert.DeserializeObject<UserDto>(jsonResponse);

            return userDto;
        }

        public async Task<UserDto> UpdateAsync(UserDto userDto, string accessToken)
        {
            SetAuthenticationBasicToken(accessToken);
            var response = await _httpClient.PutAsJsonAsync($"Users/{userDto.Id}", userDto);

            var jsonResponse = await response.Content.ReadAsStringAsync();

            var userDtoUpdated = JsonConvert.DeserializeObject<UserDto>(jsonResponse);

            return userDtoUpdated;
        }

        public async Task DeleteAsync(string id, string accessToken)
        {
            SetAuthenticationBasicToken(accessToken);
            await _httpClient.DeleteAsync($"Users/{id}");
        }

        public async Task<UserDto> CreateAsync(UserDto userDto, string accessToken)
        {
            SetAuthenticationBasicToken(accessToken);
            var response = await _httpClient.PostAsJsonAsync($"Users", userDto);

            var jsonResponse = await response.Content.ReadAsStringAsync();

            var userDtoUpdated = JsonConvert.DeserializeObject<UserDto>(jsonResponse);

            return userDtoUpdated;
        }
    }
}