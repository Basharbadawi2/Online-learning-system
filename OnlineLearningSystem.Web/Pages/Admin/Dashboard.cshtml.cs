using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineLearningSystem.Web.Services;

namespace OnlineLearningSystem.Web.Pages.Admin
{
    public class DashboardModel : PageModel
    {
        private readonly IUserService _userService;
        private readonly ICourseService _courseService;
        private readonly IEnrollmentService _enrollmentService;

        public int TotalUsers { get; set; }
        public int TotalStudents { get; set; }
        public int TotalInstructors { get; set; }
        public int TotalCourses { get; set; }
        public int TotalEnrollments { get; set; }
        public int PublishedCourses { get; set; }

        public DashboardModel(
            IUserService userService,
            ICourseService courseService,
            IEnrollmentService enrollmentService)
        {
            _userService = userService;
            _courseService = courseService;
            _enrollmentService = enrollmentService;
        }

        public async Task OnGetAsync()
        {
            var users = await _userService.GetUsersAsync();
            var courses = await _courseService.GetCoursesAsync();

            TotalUsers = users.Count;
            TotalStudents = users.Count(
                u => u.Role != null &&
                     u.Role.Equals("Student",
                         StringComparison.OrdinalIgnoreCase));
            TotalInstructors = users.Count(
                u => u.Role != null &&
                     u.Role.Equals("Instructor",
                         StringComparison.OrdinalIgnoreCase));
            TotalCourses = courses.Count;
            PublishedCourses = courses.Count(c => c.IsPublished);

            try
            {
                var enrollments = await _enrollmentService.GetAllEnrollmentsAsync();
                TotalEnrollments = enrollments.Count;
            }
            catch
            {
                TotalEnrollments = 0;
            }
        }
    }
}