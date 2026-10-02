using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineLearningSystem.Web.DTOs;
using OnlineLearningSystem.Web.Services;

namespace OnlineLearningSystem.Web.Pages.Courses
{
    public class CreateModel : PageModel
    {
        private readonly ICourseService _courseService;

        [BindProperty]
        public CreateCourseDto Course { get; set; } = new();

        public CreateModel(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var success = await _courseService.CreateCourseAsync(Course);

            if (!success)
            {
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}