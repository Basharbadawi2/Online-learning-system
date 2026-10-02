using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineLearningSystem.Web.DTOs;
using OnlineLearningSystem.Web.Services;

namespace OnlineLearningSystem.Web.Pages.Admin
{
    public class EnrollmentsModel : PageModel
    {
        private readonly IEnrollmentService _enrollmentService;

        public List<EnrollmentDto> Enrollments { get; set; } = new();

        public EnrollmentsModel(IEnrollmentService enrollmentService)
        {
            _enrollmentService = enrollmentService;
        }

        public async Task OnGetAsync()
        {
            Enrollments = await _enrollmentService.GetAllEnrollmentsAsync();
        }
    }
}