using Online_learning_system.Models;

namespace Online_learning_system.Repositories
{
    public interface IQuizAttemptRepository
    {
        Task<List<QuizAttempt>> GetAllAsync();
        Task<QuizAttempt?> GetByIdAsync(int id);

        Task AddAsync(QuizAttempt attempt);
        Task DeleteAsync(QuizAttempt attempt);

        Task SaveChangesAsync();
    }
}