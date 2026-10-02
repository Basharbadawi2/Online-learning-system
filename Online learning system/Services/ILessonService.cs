using Online_learning_system.DTOs;
using Online_learning_system.Models;

namespace Online_learning_system.Services
{
    public interface ILessonService
    {
        Task<List<Lesson>> GetAllLessonsAsync();

        Task<Lesson?> GetLessonByIdAsync(int id);

        Task CreateLessonAsync(CreateLessonDto dto);

        Task<bool> UpdateLessonAsync(
            int id,
            UpdateLessonDto dto);

        Task<bool> DeleteLessonAsync(int id);
    }
}