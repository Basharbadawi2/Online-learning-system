using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineLearningSystem.Web.Services;

namespace OnlineLearningSystem.Web.Pages.Instructor
{
    public class ProfileModel : PageModel
    {
        private readonly IAuthSession _authSession;

        public string FullName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Bio { get; set; } = string.Empty;

        public string Specialization { get; set; } = string.Empty;

        public int CoursesCount { get; set; }

        public ProfileModel(IAuthSession authSession)
        {
            _authSession = authSession;
        }

        public void OnGet()
        {
            FullName = _authSession.FullName;
            Email = _authSession.Email;

            if (!string.IsNullOrEmpty(_authSession.Role))
            {
                Bio = "Instructor on LearnHub.";
                Specialization = "Online Teaching";
            }
        }
    }
}
