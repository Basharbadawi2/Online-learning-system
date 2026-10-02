using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Json;
using System.ComponentModel.DataAnnotations;

namespace OnlineLearningSystem.Web.Pages.Auth
{
    public class RegisterModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;

        [BindProperty]
        public RegisterDto Register { get; set; } = new();

        public string? SuccessMessage { get; set; }
        public string? ErrorMessage { get; set; }

        public RegisterModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
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

            var client = _httpClientFactory.CreateClient("ApiClient");

            var response = await client.PostAsJsonAsync(
                "api/Auth/register",
                Register);

            if (response.IsSuccessStatusCode)
            {
                SuccessMessage = "Account created successfully.";
                ModelState.Clear();
                Register = new RegisterDto();
                return Page();
            }

            ErrorMessage = await response.Content.ReadAsStringAsync();
            return Page();
        }

        public class RegisterDto
        {
            [Required]
            public string FullName { get; set; } = string.Empty;

            [Required]
            [EmailAddress]
            public string Email { get; set; } = string.Empty;

            [Required]
            [MinLength(6)]
            public string Password { get; set; } = string.Empty;
        }
    }
}