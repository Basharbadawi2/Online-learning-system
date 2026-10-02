using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Online_learning_system.DTOs;
using Online_learning_system.Services;

namespace Online_learning_system.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class QuizzesController : ControllerBase
    {
        private readonly IQuizService _quizService;

        public QuizzesController(
            IQuizService quizService)
        {
            _quizService = quizService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(
                await _quizService.GetAllQuizzesAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var quiz =
                await _quizService.GetQuizByIdAsync(id);

            if (quiz == null)
            {
                return NotFound();
            }

            return Ok(quiz);
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            CreateQuizDto dto)
        {
            var result =
                await _quizService.CreateQuizAsync(dto);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            int id,
            UpdateQuizDto dto)
        {
            var result =
                await _quizService.UpdateQuizAsync(
                    id,
                    dto);

            if (!result)
            {
                return NotFound();
            }

            return Ok("Quiz updated successfully.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result =
                await _quizService.DeleteQuizAsync(id);

            if (!result)
            {
                return NotFound();
            }

            return Ok("Quiz deleted successfully.");
        }
    }
}