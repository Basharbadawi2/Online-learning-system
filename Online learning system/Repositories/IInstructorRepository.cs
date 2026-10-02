using Online_learning_system.Models;

namespace Online_learning_system.Repositories
{
    public interface IInstructorRepository
    {
        Task<List<Instructor>> GetAllAsync();
        Task<Instructor?> GetByIdAsync(int id);
        Task<Instructor?> GetByUserIdAsync(int userId);
        Task AddAsync(Instructor instructor);
        Task DeleteAsync(Instructor instructor);
        Task SaveChangesAsync();
    }
}