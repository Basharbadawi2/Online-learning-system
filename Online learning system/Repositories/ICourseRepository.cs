using Online_learning_system.Models;

namespace Online_learning_system.Repositories
{
    public interface ICourseRepository
    {
        Task<List<Course>> GetAllAsync();
        Task<Course?> GetByIdAsync(int id);
        Task AddAsync(Course course);
        Task DeleteAsync(Course course);
        Task<bool> HasEnrollmentsAsync(int courseId);
        Task SaveChangesAsync();
        Task<List<Course>> GetCoursesByInstructorAsync(int instructorId);
        Task<List<Course>> GetCoursesByInstructorUserIdAsync(int userId);

    }
}