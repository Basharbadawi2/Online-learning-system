using OnlineLearningSystem.Web.DTOs;

namespace OnlineLearningSystem.Web.Services
{
    public interface ICategoryService
    {
        Task<List<CategoryDto>> GetCategoriesAsync();
        Task<CategoryDto?> GetCategoryByIdAsync(int id);
        Task<List<CourseDto>> GetCoursesByCategoryAsync(int categoryId);
        Task<bool> CreateCategoryAsync(string name);
        Task<bool> UpdateCategoryAsync(int id, string name);
        Task<bool> DeleteCategoryAsync(int id);
    }
}