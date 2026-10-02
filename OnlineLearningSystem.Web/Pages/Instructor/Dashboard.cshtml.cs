using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineLearningSystem.Web.DTOs;
using OnlineLearningSystem.Web.Services;

namespace OnlineLearningSystem.Web.Pages.Instructor
{
    public class DashboardModel : PageModel
    {
        private readonly ICourseService _courseService;
        private readonly IAuthSession _authSession;

        public List<CourseDto> Courses { get; set; } = new();

        public int TotalCourses => Courses.Count;

        public int TotalStudents { get; set; }

        public decimal AverageRating { get; set; }

        public DashboardModel(
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

            TotalStudents = 0;
            AverageRating = 0;
        }
    }
}
