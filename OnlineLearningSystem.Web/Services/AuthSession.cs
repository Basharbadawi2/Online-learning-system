using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace OnlineLearningSystem.Web.Services
{
    public class AuthSession : IAuthSession
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private const string TokenCookie = "OLS_Token";

        public AuthSession(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        private HttpContext Context =>
            _httpContextAccessor.HttpContext!;

        public bool IsLoggedIn =>
            Context.Request.Cookies[TokenCookie] != null;

        public int UserId =>
            int.TryParse(Context.User.FindFirstValue(ClaimTypes.NameIdentifier), out var id)
                ? id
                : 0;

        public string FullName =>
            Context.User.FindFirstValue(ClaimTypes.Name) ?? string.Empty;

        public string Email =>
            Context.User.FindFirstValue(ClaimTypes.Email) ?? string.Empty;

        public string Role =>
            Context.User.FindFirstValue(ClaimTypes.Role) ?? string.Empty;

        public string Token =>
            Context.Request.Cookies[TokenCookie] ?? string.Empty;

        public async Task LoginAsync(
            int userId,
            string fullName,
            string email,
            string role,
            string token)
        {
            var identity = new ClaimsIdentity(
                new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                    new Claim(ClaimTypes.Name, fullName),
                    new Claim(ClaimTypes.Email, email),
                    new Claim(ClaimTypes.Role, role)
                },
                CookieAuthenticationDefaults.AuthenticationScheme);

            var principal = new ClaimsPrincipal(identity);

            await Context.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                principal,
                new AuthenticationProperties
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTimeOffset.UtcNow.AddHours(8)
                });

            Context.Response.Cookies.Append(
                TokenCookie,
                token,
                new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.Lax,
                    Expires = DateTimeOffset.UtcNow.AddHours(8)
                });
        }

        public Task LogoutAsync()
        {
            Context.Response.Cookies.Delete(TokenCookie);
            Context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Task.CompletedTask;
        }
    }
}