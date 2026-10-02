using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Online_learning_system.Services;

namespace Online_learning_system.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories =
                await _categoryService.GetAllCategoriesAsync();

            return Ok(categories);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var category =
                await _categoryService.GetCategoryByIdAsync(id);

            if (category == null)
            {
                return NotFound("Category not found.");
            }

            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(string name)
        {
            await _categoryService.CreateCategoryAsync(name);

            return Ok("Category created successfully.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(
            int id,
            string name)
        {
            var result =
                await _categoryService.UpdateCategoryAsync(id, name);

            if (!result)
            {
                return NotFound("Category not found.");
            }

            return Ok("Category updated successfully.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var result =
                await _categoryService.DeleteCategoryAsync(id);

            if (!result)
            {
                return NotFound("Category not found.");
            }

            return Ok("Category deleted successfully.");
        }
        [AllowAnonymous]
        [HttpGet("{id}/courses")]
        public async Task<IActionResult> GetCategoryCourses(int id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);

            if (category == null)
            {
                return NotFound("Category not found.");
            }

            var courses = await _categoryService.GetCoursesByCategoryAsync(id);

            return Ok(courses);
        }
    }
}