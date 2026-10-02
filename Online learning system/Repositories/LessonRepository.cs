using Microsoft.EntityFrameworkCore;
using Online_learning_system.Data;
using Online_learning_system.Models;

namespace Online_learning_system.Repositories
{
    public class LessonRepository : ILessonRepository
    {
        private readonly OnlineLearningDbContext _context;

        public LessonRepository(OnlineLearningDbContext context)
        {
            _context = context;
        }

        public async Task<List<Lesson>> GetAllAsync()
        {
            return await _context.Lessons
                .Include(l => l.Module)
                .ToListAsync();
        }

        public async Task<Lesson?> GetByIdAsync(int id)
        {
            return await _context.Lessons
                .Include(l => l.Module)
                .FirstOrDefaultAsync(l => l.LessonId == id);
        }

        public async Task AddAsync(Lesson lesson)
        {
            await _context.Lessons.AddAsync(lesson);
        }

        public async Task DeleteAsync(Lesson lesson)
        {
            _context.Lessons.Remove(lesson);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}