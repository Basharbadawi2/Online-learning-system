using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineLearningSystem.Web.Services;

namespace OnlineLearningSystem.Web.Pages.Auth
{
    public class LogoutModel : PageModel
    {
        private readonly IAuthSession _authSession;

        public LogoutModel(IAuthSession authSession)
        {
            _authSession = authSession;
        }

        public IActionResult OnGet()
        {
            return RedirectToPage("/Index");
        }

        public async Task<IActionResult> OnPost()
        {
            await _authSession.LogoutAsync();
            return RedirectToPage("/Index");
        }
    }
}