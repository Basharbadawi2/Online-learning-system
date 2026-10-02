using Microsoft.EntityFrameworkCore;
using Online_learning_system.Data;
using Online_learning_system.Models;

namespace Online_learning_system.Repositories
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        private readonly OnlineLearningDbContext _context;

        public EnrollmentRepository(
            OnlineLearningDbContext context)
        {
            _context = context;
        }

        public async Task<List<Enrollment>> GetAllAsync()
        {
            return await _context.Enrollments
                .Include(e => e.Student)
                .Include(e => e.Course)
                .ToListAsync();
        }

        public async Task<Enrollment?> GetByIdAsync(int id)
        {
            return await _context.Enrollments
                .Include(e => e.Student)
                .Include(e => e.Course)
                .FirstOrDefaultAsync(
                    e => e.EnrollmentId == id);
        }

        public async Task<List<Enrollment>> GetByStudentAsync(
            int studentId)
        {
            return await _context.Enrollments
                .Include(e => e.Student)
                .Include(e => e.Course)
                .Where(e => e.StudentId == studentId)
                .ToListAsync();
        }

        public async Task<Enrollment?> GetByStudentAndCourseAsync(
            int studentId,
            int courseId)
        {
            return await _context.Enrollments
                .FirstOrDefaultAsync(
                    e => e.StudentId == studentId
                      && e.CourseId == courseId);
        }

        public async Task AddAsync(
            Enrollment enrollment)
        {
            await _context.Enrollments
                .AddAsync(enrollment);
        }

        public async Task DeleteAsync(
            Enrollment enrollment)
        {
            _context.Enrollments.Remove(enrollment);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
