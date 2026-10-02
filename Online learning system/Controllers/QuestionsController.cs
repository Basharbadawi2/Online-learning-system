using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Online_learning_system.DTOs;
using Online_learning_system.Services;

namespace Online_learning_system.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionService
            _questionService;

        public QuestionsController(
            IQuestionService questionService)
        {
            _questionService =
                questionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(
                await _questionService
                .GetAllQuestionsAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult>
            GetById(int id)
        {
            var question =
                await _questionService
                .GetQuestionByIdAsync(id);

            if (question == null)
            {
                return NotFound();
            }

            return Ok(question);
        }

        [HttpPost]
        public async Task<IActionResult>
            Create(CreateQuestionDto dto)
        {
            await _questionService
                .CreateQuestionAsync(dto);

            return Ok(
                "Question created successfully.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult>
            Update(
            int id,
            UpdateQuestionDto dto)
        {
            var result =
                await _questionService
                .UpdateQuestionAsync(id, dto);

            if (!result)
            {
                return NotFound();
            }

            return Ok(
                "Question updated successfully.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult>
            Delete(int id)
        {
            var result =
                await _questionService
                .DeleteQuestionAsync(id);

            if (!result)
            {
                return NotFound();
            }

            return Ok(
                "Question deleted successfully.");
        }
    }
}