using System.Net.Http.Json;
using OnlineLearningSystem.Web.DTOs;

namespace OnlineLearningSystem.Web.Services
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly HttpClient _httpClient;

        public EnrollmentService(
            IHttpClientFactory httpClientFactory)
        {
            _httpClient =
                httpClientFactory.CreateClient("ApiClient");
        }

        public async Task<List<EnrollmentDto>>
            GetStudentEnrollmentsAsync(int studentId)
        {
            return await _httpClient.GetFromJsonAsync<
                List<EnrollmentDto>>(
                    $"api/Enrollments/student/{studentId}"
                ) ?? new List<EnrollmentDto>();
        }

        public async Task<List<EnrollmentDto>>
            GetAllEnrollmentsAsync()
        {
            return await _httpClient.GetFromJsonAsync<
                List<EnrollmentDto>>(
                    "api/Enrollments"
                ) ?? new List<EnrollmentDto>();
        }
    }
}