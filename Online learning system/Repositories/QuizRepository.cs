using Microsoft.EntityFrameworkCore;
using Online_learning_system.Data;
using Online_learning_system.Models;

namespace Online_learning_system.Repositories
{
    public class QuizRepository : IQuizRepository
    {
        private readonly OnlineLearningDbContext _context;

        public QuizRepository(OnlineLearningDbContext context)
        {
            _context = context;
        }

        public async Task<List<Quiz>> GetAllAsync()
        {
            return await _context.Quizzes
                .Include(q => q.Module)
                .ToListAsync();
        }

        public async Task<Quiz?> GetByIdAsync(int id)
        {
            return await _context.Quizzes
                .Include(q => q.Module)
                .FirstOrDefaultAsync(q => q.QuizId == id);
        }

        public async Task<Quiz?> GetByModuleIdAsync(int moduleId)
        {
            return await _context.Quizzes
                .FirstOrDefaultAsync(q => q.ModuleId == moduleId);
        }

        public async Task AddAsync(Quiz quiz)
        {
            await _context.Quizzes.AddAsync(quiz);
        }

        public async Task DeleteAsync(Quiz quiz)
        {
            _context.Quizzes.Remove(quiz);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}