using System.Net.Http.Json;
using OnlineLearningSystem.Web.DTOs;

namespace OnlineLearningSystem.Web.Services
{
    public class InstructorService : IInstructorService
    {
        private readonly HttpClient _httpClient;

        public InstructorService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("ApiClient");
        }

        public async Task<InstructorDto?> GetInstructorByUserAsync(int userId)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<InstructorDto>(
                    $"api/Instructors/by-user/{userId}");
            }
            catch
            {
                return null;
            }
        }
    }
}