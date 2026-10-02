using Online_learning_system.DTOs;
using Online_learning_system.Models;

namespace Online_learning_system.Services
{
    public interface IEnrollmentService
    {
        Task<List<Enrollment>> GetAllEnrollmentsAsync();

        Task<Enrollment?> GetEnrollmentByIdAsync(int id);

        Task<List<Enrollment>> GetEnrollmentsByStudentAsync(
            int studentId);

        Task<string> CreateEnrollmentAsync(
            CreateEnrollmentDto dto);

        Task<bool> DeleteEnrollmentAsync(int id);
    }
}