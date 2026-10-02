using Online_learning_system.Models;

namespace Online_learning_system.Repositories
{
    public interface IQuizRepository
    {
        Task<List<Quiz>> GetAllAsync();
        Task<Quiz?> GetByIdAsync(int id);
        Task<Quiz?> GetByModuleIdAsync(int moduleId);

        Task AddAsync(Quiz quiz);
        Task DeleteAsync(Quiz quiz);

        Task SaveChangesAsync();
    }
}