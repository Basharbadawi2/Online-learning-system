using OnlineLearningSystem.Web.DTOs;

namespace OnlineLearningSystem.Web.Services
{
    public interface IInstructorService
    {
        Task<InstructorDto?> GetInstructorByUserAsync(int userId);
    }
}