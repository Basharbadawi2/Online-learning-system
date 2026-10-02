using Online_learning_system.Models;

namespace Online_learning_system.Repositories
{
    public interface IRoleRepository
    {
        Task<List<Role>> GetAllAsync();
        Task<Role?> GetByIdAsync(int id);
    }
}