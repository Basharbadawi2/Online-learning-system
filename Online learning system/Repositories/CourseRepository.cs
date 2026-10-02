using Microsoft.EntityFrameworkCore;
using Online_learning_system.Data;
using Online_learning_system.Models;

namespace Online_learning_system.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly OnlineLearningDbContext _context;

        public CourseRepository(OnlineLearningDbContext context)
        {
            _context = context;
        }

        public async Task<List<Course>> GetAllAsync()
        {
            return await _context.Courses
                .Include(c => c.Category)
                .Include(c => c.Instructor)
                .ToListAsync();
        }

        public async Task<Course?> GetByIdAsync(int id)
        {
            return await _context.Courses
                .Include(c => c.Category)
                .Include(c => c.Instructor)
                .FirstOrDefaultAsync(c => c.CourseId == id);
        }

        public async Task AddAsync(Course course)
        {
            await _context.Courses.AddAsync(course);
        }

        public async Task DeleteAsync(Course course)
        {
            _context.Courses.Remove(course);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
        public async Task<bool> HasEnrollmentsAsync(int courseId)
        {
            return await _context.Enrollments
                .AnyAsync(e => e.CourseId == courseId);
        }
        public async Task<List<Course>> GetCoursesByInstructorAsync(int instructorId)
        {
            return await _context.Courses
                .Where(c => c.InstructorId == instructorId)
                .ToListAsync();
        }

        public async Task<List<Course>> GetCoursesByInstructorUserIdAsync(int userId)
        {
            return await _context.Courses
                .Where(c => c.Instructor.UserId == userId)
                .ToListAsync();
        }


    }
}