using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Online_learning_system.DTOs;
using Online_learning_system.Services;

namespace Online_learning_system.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class QuizAttemptsController : ControllerBase
    {
        private readonly IQuizAttemptService
            _attemptService;

        public QuizAttemptsController(
            IQuizAttemptService attemptService)
        {
            _attemptService = attemptService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var attempts =
                await _attemptService
                .GetAllAttemptsAsync();

            return Ok(attempts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var attempt =
                await _attemptService
                .GetAttemptByIdAsync(id);

            if (attempt == null)
            {
                return NotFound("Quiz attempt not found.");
            }

            return Ok(attempt);
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            CreateQuizAttemptDto dto)
        {
            var result =
                await _attemptService
                .CreateAttemptAsync(dto);

            if (result == "Quiz not found.")
            {
                return NotFound(result);
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result =
                await _attemptService
                .DeleteAttemptAsync(id);

            if (!result)
            {
                return NotFound("Quiz attempt not found.");
            }

            return Ok(
                "Quiz attempt deleted successfully.");
        }
    }
}