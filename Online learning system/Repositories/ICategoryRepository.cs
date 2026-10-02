using Online_learning_system.Models;

namespace Online_learning_system.Repositories
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllAsync();
        Task<Category?> GetByIdAsync(int id);
        Task<List<Course>> GetCoursesAsync(int categoryId);
        Task AddAsync(Category category);
        Task DeleteAsync(Category category);
        Task SaveChangesAsync();
    }
}