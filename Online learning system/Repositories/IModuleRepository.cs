using Online_learning_system.Models;

namespace Online_learning_system.Repositories
{
    public interface IModuleRepository
    {
        Task<List<Module>> GetAllAsync();
        Task<Module?> GetByIdAsync(int id);
        Task AddAsync(Module module);
        Task DeleteAsync(Module module);
        Task SaveChangesAsync();
    }
}