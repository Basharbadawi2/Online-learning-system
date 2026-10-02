using OnlineLearningSystem.Web.DTOs;

namespace OnlineLearningSystem.Web.Services
{
    public interface IEnrollmentService
    {
        Task<List<EnrollmentDto>> GetStudentEnrollmentsAsync(
            int studentId);

        Task<List<EnrollmentDto>> GetAllEnrollmentsAsync();
    }
}