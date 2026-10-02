using Online_learning_system.Models;

namespace Online_learning_system.Services
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsersAsync();
        Task<User?> GetUserByIdAsync(int id);
        Task<bool> UpdateUserAsync(int id, string fullName, string email);
        Task<bool> DeleteUserAsync(int id);
    }
}