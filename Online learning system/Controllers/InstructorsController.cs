using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Online_learning_system.Services;

namespace Online_learning_system.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class InstructorsController : ControllerBase
    {
        private readonly IInstructorService _instructorService;

        public InstructorsController(
            IInstructorService instructorService)
        {
            _instructorService = instructorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllInstructors()
        {
            var instructors =
                await _instructorService.GetAllInstructorsAsync();

            return Ok(instructors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetInstructorById(int id)
        {
            var instructor =
                await _instructorService.GetInstructorByIdAsync(id);

            if (instructor == null)
            {
                return NotFound("Instructor not found.");
            }

            return Ok(instructor);
        }

        [HttpGet("by-user/{userId}")]
        public async Task<IActionResult> GetInstructorByUserId(int userId)
        {
            var instructor =
                await _instructorService.GetInstructorByUserIdAsync(userId);

            if (instructor == null)
            {
                return NotFound("Instructor not found.");
            }

            return Ok(instructor);
        }

        [HttpPost]
        public async Task<IActionResult> CreateInstructor(
            int userId,
            string? bio,
            string? specialization)
        {
            var result =
                await _instructorService.CreateInstructorAsync(
                    userId,
                    bio,
                    specialization);

            if (result == "User not found.")
            {
                return NotFound(result);
            }

            if (result != "Instructor created successfully.")
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInstructor(int id)
        {
            var result =
                await _instructorService.DeleteInstructorAsync(id);

            if (!result)
            {
                return NotFound("Instructor not found.");
            }

            return Ok("Instructor deleted successfully.");
        }
    }
}