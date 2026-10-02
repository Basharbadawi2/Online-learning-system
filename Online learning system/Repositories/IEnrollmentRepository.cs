using Online_learning_system.Models;

namespace Online_learning_system.Repositories
{
    public interface IEnrollmentRepository
    {
        Task<List<Enrollment>> GetAllAsync();

        Task<Enrollment?> GetByIdAsync(int id);

        Task<List<Enrollment>> GetByStudentAsync(
            int studentId);

        Task<Enrollment?> GetByStudentAndCourseAsync(
            int studentId,
            int courseId);

        Task AddAsync(Enrollment enrollment);

        Task DeleteAsync(Enrollment enrollment);

        Task SaveChangesAsync();
    }
}
