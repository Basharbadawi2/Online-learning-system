using Microsoft.EntityFrameworkCore;
using Online_learning_system.Data;
using Online_learning_system.Models;

namespace Online_learning_system.Repositories
{
    public class ModuleRepository : IModuleRepository
    {
        private readonly OnlineLearningDbContext _context;

        public ModuleRepository(OnlineLearningDbContext context)
        {
            _context = context;
        }

        public async Task<List<Module>> GetAllAsync()
        {
            return await _context.Modules
                .Include(m => m.Course)
                .ToListAsync();
        }

        public async Task<Module?> GetByIdAsync(int id)
        {
            return await _context.Modules
                .Include(m => m.Course)
                .FirstOrDefaultAsync(m => m.ModuleId == id);
        }

        public async Task AddAsync(Module module)
        {
            await _context.Modules.AddAsync(module);
        }

        public async Task DeleteAsync(Module module)
        {
            _context.Modules.Remove(module);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}