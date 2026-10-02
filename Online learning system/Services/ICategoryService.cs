using Online_learning_system.Models;

namespace Online_learning_system.Services
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllCategoriesAsync();
        Task<Category?> GetCategoryByIdAsync(int id);
        Task<List<Course>> GetCoursesByCategoryAsync(int categoryId);
        Task<bool> CreateCategoryAsync(string name);
        Task<bool> UpdateCategoryAsync(int id, string name);
        Task<bool> DeleteCategoryAsync(int id);
    }
}