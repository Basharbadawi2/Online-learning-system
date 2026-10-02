using Online_learning_system.DTOs;

namespace Online_learning_system.Services
{
    public interface IAuthService
    {
        Task<string> RegisterAsync(RegisterDto dto);

        Task<object?> LoginAsync(LoginDto dto);

        Task<string> ForgotPasswordAsync(
            ForgotPasswordDto dto);

        Task<string> ResetPasswordAsync(
            ResetPasswordDto dto);
    }
}