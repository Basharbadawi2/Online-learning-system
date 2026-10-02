using OnlineLearningSystem.Web.DTOs;

namespace OnlineLearningSystem.Web.Services
{
    public interface IUserService
    {
        Task<List<UserDto>> GetUsersAsync();
    }
}