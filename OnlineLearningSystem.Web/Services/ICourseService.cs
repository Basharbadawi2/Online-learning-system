using OnlineLearningSystem.Web.DTOs;

namespace OnlineLearningSystem.Web.Services
{
    public interface ICourseService
    {
        Task<List<CourseDto>> GetCoursesAsync();

    Task<CourseDto?> GetCourseByIdAsync(int id);

        Task<bool> CreateCourseAsync(
            CreateCourseDto course);

        Task<bool> UpdateCourseAsync(
            int id,
            UpdateCourseDto course);

        Task<bool> DeleteCourseAsync(int id);

        Task<List<CourseDto>> GetCoursesByInstructorAsync(
            int instructorId);

        Task<List<CourseDto>> GetCoursesByInstructorUserAsync(
            int userId);
    }

}
