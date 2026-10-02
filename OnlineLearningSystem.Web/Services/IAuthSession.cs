namespace OnlineLearningSystem.Web.Services
{
    public interface IAuthSession
    {
        bool IsLoggedIn { get; }

        int UserId { get; }

        string FullName { get; }

        string Email { get; }

        string Role { get; }

        string Token { get; }

        Task LoginAsync(
            int userId,
            string fullName,
            string email,
            string role,
            string token);

        Task LogoutAsync();
    }
}