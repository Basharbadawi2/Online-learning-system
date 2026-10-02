using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Online_learning_system.DTOs;
using Online_learning_system.Services;

namespace Online_learning_system.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAllCourses()
        {
            var courses = await _courseService.GetAllCoursesAsync();

            return Ok(courses);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourseById(int id)
        {
            var course = await _courseService.GetCourseByIdAsync(id);

            if (course == null)
            {
                return NotFound("Course not found.");
            }

            return Ok(course);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCourse(
            CreateCourseDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _courseService.CreateCourseAsync(dto);

            return Ok("Course created successfully.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourse(
            int id,
            UpdateCourseDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result =
                await _courseService.UpdateCourseAsync(id, dto);

            if (!result)
            {
                return NotFound("Course not found.");
            }

            return Ok("Course updated successfully.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var result =
                await _courseService.DeleteCourseAsync(id);

            if (!result)
            {
                return NotFound("Course not found.");
            }

            return Ok("Course deleted successfully.");
        }
        [HttpGet("instructor/{instructorId}")]
        public async Task<IActionResult> GetCoursesByInstructor(int instructorId)
        {
            var courses =
            await _courseService
            .GetCoursesByInstructorAsync(instructorId);

            return Ok(courses);

        }

        [HttpGet("by-user/{userId}")]
        public async Task<IActionResult> GetCoursesByUser(int userId)
        {
            var courses =
                await _courseService
                    .GetCoursesByInstructorUserIdAsync(userId);

            return Ok(courses);
        }
    }
}