using Microsoft.EntityFrameworkCore;
using Online_learning_system.Data;
using Online_learning_system.Models;

namespace Online_learning_system.Repositories
{
    public class QuizAttemptRepository : IQuizAttemptRepository
    {
        private readonly OnlineLearningDbContext _context;

        public QuizAttemptRepository(
            OnlineLearningDbContext context)
        {
            _context = context;
        }

        public async Task<List<QuizAttempt>> GetAllAsync()
        {
            return await _context.QuizAttempts
                .Include(a => a.Quiz)
                .Include(a => a.Student)
                .ToListAsync();
        }

        public async Task<QuizAttempt?> GetByIdAsync(int id)
        {
            return await _context.QuizAttempts
                .Include(a => a.Quiz)
                .Include(a => a.Student)
                .FirstOrDefaultAsync(
                    a => a.AttemptId == id);
        }

        public async Task AddAsync(QuizAttempt attempt)
        {
            await _context.QuizAttempts.AddAsync(attempt);
        }

        public async Task DeleteAsync(QuizAttempt attempt)
        {
            _context.QuizAttempts.Remove(attempt);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}