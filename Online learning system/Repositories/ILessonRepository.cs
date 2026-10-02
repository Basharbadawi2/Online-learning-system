using Online_learning_system.Models;

namespace Online_learning_system.Repositories
{
    public interface ILessonRepository
    {
        Task<List<Lesson>> GetAllAsync();
        Task<Lesson?> GetByIdAsync(int id);
        Task AddAsync(Lesson lesson);
        Task DeleteAsync(Lesson lesson);
        Task SaveChangesAsync();
    }
}