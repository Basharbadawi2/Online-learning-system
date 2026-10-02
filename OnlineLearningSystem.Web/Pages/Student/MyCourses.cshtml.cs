using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineLearningSystem.Web.DTOs;
using OnlineLearningSystem.Web.Services;

namespace OnlineLearningSystem.Web.Pages.Student
{
    public class MyCoursesModel : PageModel
    {
        private readonly IEnrollmentService _enrollmentService;
        private readonly IAuthSession _authSession;

        public List<EnrollmentDto> Enrollments { get; set; } = new();

        public MyCoursesModel(
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