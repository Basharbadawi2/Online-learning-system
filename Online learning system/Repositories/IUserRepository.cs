using Online_learning_system.Models;
using Online_learning_system.DTOs;
    
namespace Online_learning_system.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetUserByEmailAsync(string email);

        Task AddUserAsync(User user);

        Task SaveChangesAsync();

        // Users CRUD
        Task<List<User>> GetAllAsync();
        Task<User?> GetByIdAsync(int id);
        Task DeleteAsync(User user);
    }
}