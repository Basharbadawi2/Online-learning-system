using System.Net.Http.Json;
using OnlineLearningSystem.Web.DTOs;

namespace OnlineLearningSystem.Web.Services
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;

        public AuthService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("ApiClient");
        }

        public async Task<LoginResponseDto?> LoginAsync(LoginDto login)
        {
            var response = await _httpClient.PostAsJsonAsync(
                "api/Auth/login",
                login
            );

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            return await response.Content
                .ReadFromJsonAsync<LoginResponseDto>();
        }
    }
}