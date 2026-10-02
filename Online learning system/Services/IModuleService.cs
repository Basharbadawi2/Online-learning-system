using Online_learning_system.DTOs;
using Online_learning_system.Models;

namespace Online_learning_system.Services
{
    public interface IModuleService
    {
        Task<List<Module>> GetAllModulesAsync();

        Task<Module?> GetModuleByIdAsync(int id);

        Task CreateModuleAsync(CreateModuleDto dto);

        Task<bool> UpdateModuleAsync(
            int id,
            UpdateModuleDto dto);

        Task<bool> DeleteModuleAsync(int id);
    }
}