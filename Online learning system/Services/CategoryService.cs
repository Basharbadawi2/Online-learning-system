using Online_learning_system.Models;
using Online_learning_system.Repositories;

namespace Online_learning_system.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            return await _categoryRepository.GetAllAsync();
        }

        public async Task<Category?> GetCategoryByIdAsync(int id)
        {
            return await _categoryRepository.GetByIdAsync(id);
        }

        public async Task<List<Course>> GetCoursesByCategoryAsync(int categoryId)
        {
            return await _categoryRepository.GetCoursesAsync(categoryId);
        }

        public async Task<bool> CreateCategoryAsync(string name)
        {
            var category = new Category
            {
                Name = name
            };

            await _categoryRepository.AddAsync(category);
            await _categoryRepository.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateCategoryAsync(int id, string name)
        {
            var category = await _categoryRepository.GetByIdAsync(id);

            if (category == null)
            {
                return false;
            }

            category.Name = name;

            await _categoryRepository.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);

            if (category == null)
            {
                return false;
            }

            await _categoryRepository.DeleteAsync(category);
            await _categoryRepository.SaveChangesAsync();

            return true;
        }
    }
}