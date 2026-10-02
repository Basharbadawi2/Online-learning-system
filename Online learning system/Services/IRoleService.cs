using Online_learning_system.Models;

namespace Online_learning_system.Services
{
    public interface IRoleService
    {
        Task<List<Role>> GetAllRolesAsync();
        Task<Role?> GetRoleByIdAsync(int id);
    }
}