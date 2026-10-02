using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineLearningSystem.Web.DTOs;
using OnlineLearningSystem.Web.Services;

namespace OnlineLearningSystem.Web.Pages.Instructor
{
    public class CoursesModel : PageModel
    {
        private readonly ICourseService _courseService;
        private readonly IAuthSession _authSession;

        public List<CourseDto> Courses { get; set; } = new();

        public CoursesModel(
            ICourseService courseService,
            IAuthSession authSession)
        {
            _courseService = courseService;
            _authSession = authSession;
        }

        public async Task OnGetAsync()
        {
            if (!_authSession.IsLoggedIn)
            {
                return;
            }

            Courses = await _courseService
                .GetCoursesByInstructorUserAsync(_authSession.UserId);
        }
    }
}
