using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Online_learning_system.DTOs;
using Online_learning_system.Services;

namespace Online_learning_system.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AnswerOptionsController : ControllerBase
    {
        private readonly IAnswerOptionService
            _answerOptionService;

        public AnswerOptionsController(
            IAnswerOptionService answerOptionService)
        {
            _answerOptionService =
                answerOptionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(
                await _answerOptionService
                .GetAllAnswerOptionsAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var answerOption =
                await _answerOptionService
                .GetAnswerOptionByIdAsync(id);

            if (answerOption == null)
            {
                return NotFound();
            }

            return Ok(answerOption);
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            CreateAnswerOptionDto dto)
        {
            await _answerOptionService
                .CreateAnswerOptionAsync(dto);

            return Ok(
                "Answer option created successfully.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            int id,
            UpdateAnswerOptionDto dto)
        {
            var result =
                await _answerOptionService
                .UpdateAnswerOptionAsync(id, dto);

            if (!result)
            {
                return NotFound();
            }

            return Ok(
                "Answer option updated successfully.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result =
                await _answerOptionService
                .DeleteAnswerOptionAsync(id);

            if (!result)
            {
                return NotFound();
            }

            return Ok(
                "Answer option deleted successfully.");
        }
    }
}