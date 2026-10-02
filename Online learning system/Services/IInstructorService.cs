using Online_learning_system.Models;

namespace Online_learning_system.Services
{
    public interface IInstructorService
    {
        Task<List<Instructor>> GetAllInstructorsAsync();
        Task<Instructor?> GetInstructorByIdAsync(int id);
        Task<Instructor?> GetInstructorByUserIdAsync(int userId);
        Task<string> CreateInstructorAsync(
            int userId,
            string? bio,
            string? specialization);
        Task<bool> DeleteInstructorAsync(int id);
    }
}