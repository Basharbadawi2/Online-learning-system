using Microsoft.EntityFrameworkCore;
using Online_learning_system.Data;
using Online_learning_system.Models;

namespace Online_learning_system.Repositories
{
    public class InstructorRepository : IInstructorRepository
    {
        private readonly OnlineLearningDbContext _context;

        public InstructorRepository(OnlineLearningDbContext context)
        {
            _context = context;
        }

        public async Task<List<Instructor>> GetAllAsync()
        {
            return await _context.Instructors
                .Include(i => i.User)
                .ToListAsync();
        }

        public async Task<Instructor?> GetByIdAsync(int id)
        {
            return await _context.Instructors
                .Include(i => i.User)
                .FirstOrDefaultAsync(i => i.InstructorId == id);
        }

        public async Task<Instructor?> GetByUserIdAsync(int userId)
        {
            return await _context.Instructors
                .Include(i => i.User)
                .FirstOrDefaultAsync(i => i.UserId == userId);
        }

        public async Task AddAsync(Instructor instructor)
        {
            await _context.Instructors.AddAsync(instructor);
        }

        public async Task DeleteAsync(Instructor instructor)
        {
            _context.Instructors.Remove(instructor);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}