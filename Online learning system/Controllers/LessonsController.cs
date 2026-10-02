using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Online_learning_system.DTOs;
using Online_learning_system.Services;

namespace Online_learning_system.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class LessonsController : ControllerBase
    {
        private readonly ILessonService _lessonService;

        public LessonsController(
            ILessonService lessonService)
        {
            _lessonService = lessonService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLessons()
        {
            var lessons =
                await _lessonService.GetAllLessonsAsync();

            return Ok(lessons);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLessonById(int id)
        {
            var lesson =
                await _lessonService.GetLessonByIdAsync(id);

            if (lesson == null)
            {
                return NotFound("Lesson not found.");
            }

            return Ok(lesson);
        }

        [HttpPost]
        public async Task<IActionResult> CreateLesson(
            CreateLessonDto dto)
        {
            await _lessonService.CreateLessonAsync(dto);

            return Ok("Lesson created successfully.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLesson(
            int id,
            UpdateLessonDto dto)
        {
            var result =
                await _lessonService.UpdateLessonAsync(
                    id,
                    dto);

            if (!result)
            {
                return NotFound("Lesson not found.");
            }

            return Ok("Lesson updated successfully.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLesson(int id)
        {
            var result =
                await _lessonService.DeleteLessonAsync(id);

            if (!result)
            {
                return NotFound("Lesson not found.");
            }

            return Ok("Lesson deleted successfully.");
        }
    }
}