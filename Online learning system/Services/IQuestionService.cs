using Online_learning_system.DTOs;
using Online_learning_system.Models;

namespace Online_learning_system.Services
{
    public interface IQuestionService
    {
        Task<List<Question>> GetAllQuestionsAsync();

        Task<Question?> GetQuestionByIdAsync(int id);

        Task CreateQuestionAsync(
            CreateQuestionDto dto);

        Task<bool> UpdateQuestionAsync(
            int id,
            UpdateQuestionDto dto);

        Task<bool> DeleteQuestionAsync(int id);
    }
}