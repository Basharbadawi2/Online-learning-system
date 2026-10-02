using OnlineLearningSystem.Web.DTOs;

namespace OnlineLearningSystem.Web.Services
{
    public interface IAuthService
    {
        Task<LoginResponseDto?> LoginAsync(LoginDto login);
    }
}