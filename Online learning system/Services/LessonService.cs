using Online_learning_system.DTOs;
using Online_learning_system.Models;
using Online_learning_system.Repositories;

namespace Online_learning_system.Services
{
    public class LessonService : ILessonService
    {
        private readonly ILessonRepository _lessonRepository;

        public LessonService(ILessonRepository lessonRepository)
        {
            _lessonRepository = lessonRepository;
        }

        public async Task<List<Lesson>> GetAllLessonsAsync()
        {
            return await _lessonRepository.GetAllAsync();
        }

        public async Task<Lesson?> GetLessonByIdAsync(int id)
        {
            return await _lessonRepository.GetByIdAsync(id);
        }

        public async Task CreateLessonAsync(CreateLessonDto dto)
        {
            var lesson = new Lesson
            {
                ModuleId = dto.ModuleId,
                Title = dto.Title,
                LessonType = dto.LessonType,
                ContentUrl = dto.ContentUrl,
                OrderNo = dto.OrderNo
            };

            await _lessonRepository.AddAsync(lesson);

            await _lessonRepository.SaveChangesAsync();
        }

        public async Task<bool> UpdateLessonAsync(
            int id,
            UpdateLessonDto dto)
        {
            var lesson =
                await _lessonRepository.GetByIdAsync(id);

            if (lesson == null)
            {
                return false;
            }

            lesson.ModuleId = dto.ModuleId;
            lesson.Title = dto.Title;
            lesson.LessonType = dto.LessonType;
            lesson.ContentUrl = dto.ContentUrl;
            lesson.OrderNo = dto.OrderNo;

            await _lessonRepository.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteLessonAsync(int id)
        {
            var lesson =
                await _lessonRepository.GetByIdAsync(id);

            if (lesson == null)
            {
                return false;
            }

            await _lessonRepository.DeleteAsync(lesson);

            await _lessonRepository.SaveChangesAsync();

            return true;
        }
    }
}