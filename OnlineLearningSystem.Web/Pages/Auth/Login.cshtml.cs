using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineLearningSystem.Web.DTOs;
using OnlineLearningSystem.Web.Services;

namespace OnlineLearningSystem.Web.Pages.Auth
{
    public class LoginModel : PageModel
    {
        private readonly IAuthService _authService;
        private readonly IAuthSession _authSession;


    [BindProperty]
        public LoginDto Login { get; set; } = new();

        public string? ErrorMessage { get; set; }

        public LoginModel(
            IAuthService authService,
            IAuthSession authSession)
        {
            _authService = authService;
            _authSession = authSession;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var result = await _authService.LoginAsync(Login);

            if (result == null)
            {
                ErrorMessage = "Invalid email or password.";
                return Page();
            }

            await _authSession.LoginAsync(
                result.User.UserId,
                result.User.FullName,
                result.User.Email,
                result.User.Role,
                result.Token
            );

            if (result.User.Role.Equals(
                "Student",
                StringComparison.OrdinalIgnoreCase))
            {
                return RedirectToPage("/Student/Dashboard");
            }

            if (result.User.Role.Equals(
                "Instructor",
                StringComparison.OrdinalIgnoreCase))
            {
                return RedirectToPage("/Instructor/Dashboard");
            }

            if (result.User.Role.Equals(
                "Admin",
                StringComparison.OrdinalIgnoreCase))
            {
                return RedirectToPage("/Admin/Dashboard");
            }

            return RedirectToPage("/Index");
        }
    }


}
