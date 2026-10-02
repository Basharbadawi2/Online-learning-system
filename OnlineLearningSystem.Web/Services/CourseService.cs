using System.Net.Http.Json;
using OnlineLearningSystem.Web.DTOs;

namespace OnlineLearningSystem.Web.Services
{
    public class CourseService : ICourseService
    {
        private readonly HttpClient _httpClient;

        public CourseService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("ApiClient");
        }

        public async Task<List<CourseDto>> GetCoursesAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<CourseDto>>(
                "api/Courses"
            ) ?? new List<CourseDto>();
        }
        public async Task<CourseDto?> GetCourseByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<CourseDto>(
                $"api/Courses/{id}"
            );
        }
        public async Task<bool> CreateCourseAsync(CreateCourseDto course)
        {
            var response = await _httpClient.PostAsJsonAsync(
                "api/Courses",
                course
            );

            return response.IsSuccessStatusCode;
        }
        public async Task<bool> UpdateCourseAsync(int id, UpdateCourseDto course)
        {
            var response = await _httpClient.PutAsJsonAsync(
                $"api/Courses/{id}",
                course
            );

            return response.IsSuccessStatusCode;
        }
        public async Task<bool> DeleteCourseAsync(int id)
        {
            var response = await _httpClient.DeleteAsync(
                $"api/Courses/{id}"
            );

            return response.IsSuccessStatusCode;
        }
        public async Task<List<CourseDto>> GetCoursesByInstructorAsync(
int instructorId)
        {
            return await _httpClient.GetFromJsonAsync<List<CourseDto>>(
            $"api/Courses/instructor/{instructorId}"
            ) ?? new List<CourseDto>();
        }

        public async Task<List<CourseDto>> GetCoursesByInstructorUserAsync(
int userId)
        {
            return await _httpClient.GetFromJsonAsync<List<CourseDto>>(
            $"api/Courses/by-user/{userId}"
            ) ?? new List<CourseDto>();
        }

    }
}