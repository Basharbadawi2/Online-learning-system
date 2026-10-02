using Online_learning_system.Models;

namespace Online_learning_system.Repositories
{
    public interface IQuestionRepository
    {
        Task<List<Question>> GetAllAsync();
        Task<Question?> GetByIdAsync(int id);
        Task AddAsync(Question question);
        Task DeleteAsync(Question question);
        Task SaveChangesAsync();
    }
}