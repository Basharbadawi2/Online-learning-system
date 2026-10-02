using Online_learning_system.Models;

namespace Online_learning_system.Repositories
{
    public interface IAnswerOptionRepository
    {
        Task<List<AnswerOption>> GetAllAsync();
        Task<AnswerOption?> GetByIdAsync(int id);
        Task AddAsync(AnswerOption answerOption);
        Task DeleteAsync(AnswerOption answerOption);
        Task SaveChangesAsync();
    }
}