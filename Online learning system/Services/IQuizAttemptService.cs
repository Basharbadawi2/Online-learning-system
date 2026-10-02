using Online_learning_system.DTOs;
using Online_learning_system.Models;

namespace Online_learning_system.Services
{
    public interface IQuizAttemptService
    {
        Task<List<QuizAttempt>> GetAllAttemptsAsync();

        Task<QuizAttempt?> GetAttemptByIdAsync(int id);

        Task<string> CreateAttemptAsync(
            CreateQuizAttemptDto dto);

        Task<bool> DeleteAttemptAsync(int id);
    }
}