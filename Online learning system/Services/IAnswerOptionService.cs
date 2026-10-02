using Online_learning_system.DTOs;
using Online_learning_system.Models;

namespace Online_learning_system.Services
{
    public interface IAnswerOptionService
    {
        Task<List<AnswerOption>> GetAllAnswerOptionsAsync();

        Task<AnswerOption?> GetAnswerOptionByIdAsync(int id);

        Task CreateAnswerOptionAsync(
            CreateAnswerOptionDto dto);

        Task<bool> UpdateAnswerOptionAsync(
            int id,
            UpdateAnswerOptionDto dto);

        Task<bool> DeleteAnswerOptionAsync(int id);
    }
}