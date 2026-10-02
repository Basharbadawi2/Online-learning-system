using Online_learning_system.DTOs;
using Online_learning_system.Models;
using Online_learning_system.Repositories;

namespace Online_learning_system.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;

    public CourseService(
        ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<List<Course>> GetAllCoursesAsync()
        {
            return await _courseRepository.GetAllAsync();
        }

        public async Task<Course?> GetCourseByIdAsync(int id)
        {
            return await _courseRepository.GetByIdAsync(id);
        }

        public async Task<string> CreateCourseAsync(
            CreateCourseDto dto)
        {
            var course = new Course
            {
                Title = dto.Title,
                Description = dto.Description,
                Price = dto.Price,
                IsPublished = dto.IsPublished,
                InstructorId = dto.InstructorId,
                CategoryId = dto.CategoryId
            };

            await _courseRepository.AddAsync(course);
            await _courseRepository.SaveChangesAsync();

            return "Course created successfully.";
        }

        public async Task<bool> UpdateCourseAsync(
            int id,
            UpdateCourseDto dto)
        {
            var course =
                await _courseRepository.GetByIdAsync(id);

            if (course == null)
            {
                return false;
            }

            course.Title = dto.Title;
            course.Description = dto.Description;
            course.Price = dto.Price;
            course.IsPublished = dto.IsPublished;
            course.InstructorId = dto.InstructorId;
            course.CategoryId = dto.CategoryId;

            await _courseRepository.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteCourseAsync(int id)
        {
            var course =
                await _courseRepository.GetByIdAsync(id);

            if (course == null)
            {
                return false;
            }

            await _courseRepository.DeleteAsync(course);
            await _courseRepository.SaveChangesAsync();

            return true;
        }

        public async Task<List<Course>>
            GetCoursesByInstructorAsync(int instructorId)
        {
            return await _courseRepository
                .GetCoursesByInstructorAsync(instructorId);
        }

        public async Task<List<Course>>
            GetCoursesByInstructorUserIdAsync(int userId)
        {
            return await _courseRepository
                .GetCoursesByInstructorUserIdAsync(userId);
        }
    }

}
