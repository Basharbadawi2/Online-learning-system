using Microsoft.EntityFrameworkCore;
using Online_learning_system.Data;
using Online_learning_system.Models;

namespace Online_learning_system.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly OnlineLearningDbContext _context;

        public QuestionRepository(
            OnlineLearningDbContext context)
        {
            _context = context;
        }

        public async Task<List<Question>> GetAllAsync()
        {
            return await _context.Questions
                .Include(q => q.Quiz)
                .ToListAsync();
        }

        public async Task<Question?> GetByIdAsync(int id)
        {
            return await _context.Questions
                .Include(q => q.Quiz)
                .FirstOrDefaultAsync(
                    q => q.QuestionId == id);
        }

        public async Task AddAsync(Question question)
        {
            await _context.Questions.AddAsync(question);
        }

        public async Task DeleteAsync(Question question)
        {
            _context.Questions.Remove(question);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}