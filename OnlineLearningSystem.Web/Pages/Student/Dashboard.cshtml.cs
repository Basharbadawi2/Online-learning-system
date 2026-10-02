using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineLearningSystem.Web.DTOs;
using OnlineLearningSystem.Web.Services;

namespace OnlineLearningSystem.Web.Pages.Student
{
    public class DashboardModel : PageModel
    {
        private readonly IEnrollmentService _enrollmentService;
        private readonly IAuthSession _authSession;

        public List<EnrollmentDto> Enrollments { get; set; } = new();

        public int TotalCourses => Enrollments.Count;

        public decimal AverageProgress =>
            Enrollments.Count == 0
                ? 0
                : Enrollments.Average(
                    e => e.ProgressPercent);

        public DashboardModel(
            IEnrollmentService enrollmentService,
            IAuthSession authSession)
        {
            _enrollmentService = enrollmentService;
            _authSession = authSession;
        }

        public async Task OnGetAsync()
        {
            if (!_authSession.IsLoggedIn)
            {
                return;
            }

            Enrollments =
                await _enrollmentService
                    .GetStudentEnrollmentsAsync(_authSession.UserId);
        }
    }
}