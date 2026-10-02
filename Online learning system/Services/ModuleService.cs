using Online_learning_system.DTOs;
using Online_learning_system.Models;
using Online_learning_system.Repositories;

namespace Online_learning_system.Services
{
    public class ModuleService : IModuleService
    {
        private readonly IModuleRepository _moduleRepository;

        public ModuleService(IModuleRepository moduleRepository)
        {
            _moduleRepository = moduleRepository;
        }

        public async Task<List<Module>> GetAllModulesAsync()
        {
            return await _moduleRepository.GetAllAsync();
        }

        public async Task<Module?> GetModuleByIdAsync(int id)
        {
            return await _moduleRepository.GetByIdAsync(id);
        }

        public async Task CreateModuleAsync(CreateModuleDto dto)
        {
            var module = new Module
            {
                CourseId = dto.CourseId,
                Title = dto.Title,
                OrderNo = dto.OrderNo
            };

            await _moduleRepository.AddAsync(module);

            await _moduleRepository.SaveChangesAsync();
        }

        public async Task<bool> UpdateModuleAsync(
            int id,
            UpdateModuleDto dto)
        {
            var module =
                await _moduleRepository.GetByIdAsync(id);

            if (module == null)
            {
                return false;
            }

            module.CourseId = dto.CourseId;
            module.Title = dto.Title;
            module.OrderNo = dto.OrderNo;

            await _moduleRepository.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteModuleAsync(int id)
        {
            var module =
                await _moduleRepository.GetByIdAsync(id);

            if (module == null)
            {
                return false;
            }

            await _moduleRepository.DeleteAsync(module);

            await _moduleRepository.SaveChangesAsync();

            return true;
        }
    }
}