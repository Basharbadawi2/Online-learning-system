using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineLearningSystem.Web.DTOs;
using OnlineLearningSystem.Web.Services;

namespace OnlineLearningSystem.Web.Pages.Courses
{
    public class IndexModel : PageModel
    {
        private readonly ICourseService _courseService;

        public List<CourseDto> Courses { get; set; } = new();

        public IndexModel(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public async Task OnGetAsync()
        {
            Courses = await _courseService.GetCoursesAsync();
        }
        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var success = await _courseService.DeleteCourseAsync(id);

            if (!success)
            {
                return Page();
            }

            return RedirectToPage();
        }
    }
}