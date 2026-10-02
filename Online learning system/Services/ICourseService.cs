using Online_learning_system.DTOs;
using Online_learning_system.Models;

namespace Online_learning_system.Services
{
    public interface ICourseService
    {
        Task<List<Course>> GetAllCoursesAsync();

    Task<Course?> GetCourseByIdAsync(int id);

        Task<string> CreateCourseAsync(CreateCourseDto dto);

        Task<bool> UpdateCourseAsync(
            int id,
            UpdateCourseDto dto);

        Task<bool> DeleteCourseAsync(int id);

        Task<List<Course>> GetCoursesByInstructorAsync(
            int instructorId);

        Task<List<Course>> GetCoursesByInstructorUserIdAsync(
            int userId);
    }


}
