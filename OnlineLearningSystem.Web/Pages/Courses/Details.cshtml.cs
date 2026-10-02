using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineLearningSystem.Web.DTOs;
using OnlineLearningSystem.Web.Services;

namespace OnlineLearningSystem.Web.Pages.Courses
{
    public class DetailsModel : PageModel
    {
        private readonly ICourseService _courseService;

        public CourseDto? Course { get; set; }

        public DetailsModel(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Course = await _courseService.GetCourseByIdAsync(id);

            if (Course == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}