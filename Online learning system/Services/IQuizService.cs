using Online_learning_system.DTOs;
using Online_learning_system.Models;

namespace Online_learning_system.Services
{
    public interface IQuizService
    {
        Task<List<Quiz>> GetAllQuizzesAsync();

        Task<Quiz?> GetQuizByIdAsync(int id);

        Task<string> CreateQuizAsync(CreateQuizDto dto);

        Task<bool> UpdateQuizAsync(
            int id,
            UpdateQuizDto dto);

        Task<bool> DeleteQuizAsync(int id);
    }
}