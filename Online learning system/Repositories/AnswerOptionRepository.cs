using Microsoft.EntityFrameworkCore;
using Online_learning_system.Data;
using Online_learning_system.Models;

namespace Online_learning_system.Repositories
{
    public class AnswerOptionRepository : IAnswerOptionRepository
    {
        private readonly OnlineLearningDbContext _context;

        public AnswerOptionRepository(
            OnlineLearningDbContext context)
        {
            _context = context;
        }

        public async Task<List<AnswerOption>> GetAllAsync()
        {
            return await _context.AnswerOptions
                .Include(a => a.Question)
                .ToListAsync();
        }

        public async Task<AnswerOption?> GetByIdAsync(int id)
        {
            return await _context.AnswerOptions
                .Include(a => a.Question)
                .FirstOrDefaultAsync(
                    a => a.AnswerOptionId == id);
        }

        public async Task AddAsync(
            AnswerOption answerOption)
        {
            await _context.AnswerOptions
                .AddAsync(answerOption);
        }

        public async Task DeleteAsync(
            AnswerOption answerOption)
        {
            _context.AnswerOptions.Remove(answerOption);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}