using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineLearningSystem.Web.DTOs;
using OnlineLearningSystem.Web.Services;

namespace OnlineLearningSystem.Web.Pages.Admin
{
    public class CoursesModel : PageModel
    {
        private readonly ICourseService _courseService;

        public List<CourseDto> Courses { get; set; } = new();

        public CoursesModel(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public async Task OnGetAsync()
        {
            Courses = await _courseService.GetCoursesAsync();
        }
    }
}