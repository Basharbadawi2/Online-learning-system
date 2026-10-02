using System.Net.Http.Json;
using OnlineLearningSystem.Web.DTOs;

namespace OnlineLearningSystem.Web.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _httpClient;

        public CategoryService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("ApiClient");
        }

        public async Task<List<CategoryDto>> GetCategoriesAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<CategoryDto>>(
                "api/Categories"
            ) ?? new List<CategoryDto>();
        }

        public async Task<CategoryDto?> GetCategoryByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<CategoryDto>(
                $"api/Categories/{id}"
            );
        }

        public async Task<List<CourseDto>> GetCoursesByCategoryAsync(int categoryId)
        {
            return await _httpClient.GetFromJsonAsync<List<CourseDto>>(
                $"api/Categories/{categoryId}/courses"
            ) ?? new List<CourseDto>();
        }

        public async Task<bool> CreateCategoryAsync(string name)
        {
            var response = await _httpClient.PostAsJsonAsync(
                "api/Categories",
                new { name }
            );

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateCategoryAsync(int id, string name)
        {
            var response = await _httpClient.PutAsJsonAsync(
                $"api/Categories/{id}",
                new { name }
            );

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var response = await _httpClient.DeleteAsync(
                $"api/Categories/{id}"
            );

            return response.IsSuccessStatusCode;
        }
    }
}