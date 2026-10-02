using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineLearningSystem.Web.DTOs;
using OnlineLearningSystem.Web.Services;

namespace OnlineLearningSystem.Web.Pages.Categories
{
    public class DetailsModel : PageModel
    {
        private readonly ICategoryService _categoryService;

        public CategoryDto? Category { get; set; }

        public List<CourseDto> Courses { get; set; } = new();

        public DetailsModel(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Category = await _categoryService.GetCategoryByIdAsync(id);

            if (Category == null)
            {
                return NotFound();
            }

            Courses = await _categoryService.GetCoursesByCategoryAsync(id);

            return Page();
        }
    }
}