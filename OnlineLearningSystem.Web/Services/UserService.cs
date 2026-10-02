using System.Net.Http.Json;
using OnlineLearningSystem.Web.DTOs;

namespace OnlineLearningSystem.Web.Services
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;

        public UserService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("ApiClient");
        }

        public async Task<List<UserDto>> GetUsersAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<UserDto>>(
                "api/Users"
            ) ?? new List<UserDto>();
        }
    }
}