using Online_learning_system.DTOs;
using Online_learning_system.Models;
using Online_learning_system.Repositories;

namespace Online_learning_system.Services
{
    public class AnswerOptionService : IAnswerOptionService
    {
        private readonly IAnswerOptionRepository
            _answerOptionRepository;

        public AnswerOptionService(
            IAnswerOptionRepository answerOptionRepository)
        {
            _answerOptionRepository =
                answerOptionRepository;
        }

        public async Task<List<AnswerOption>>
            GetAllAnswerOptionsAsync()
        {
            return await _answerOptionRepository
                .GetAllAsync();
        }

        public async Task<AnswerOption?>
            GetAnswerOptionByIdAsync(int id)
        {
            return await _answerOptionRepository
                .GetByIdAsync(id);
        }

        public async Task CreateAnswerOptionAsync(
            CreateAnswerOptionDto dto)
        {
            var answerOption = new AnswerOption
            {
                QuestionId = dto.QuestionId,
                OptionText = dto.OptionText,
                IsCorrect = dto.IsCorrect
            };

            await _answerOptionRepository
                .AddAsync(answerOption);

            await _answerOptionRepository
                .SaveChangesAsync();
        }

        public async Task<bool> UpdateAnswerOptionAsync(
            int id,
            UpdateAnswerOptionDto dto)
        {
            var answerOption =
                await _answerOptionRepository
                .GetByIdAsync(id);

            if (answerOption == null)
            {
                return false;
            }

            answerOption.QuestionId = dto.QuestionId;
            answerOption.OptionText = dto.OptionText;
            answerOption.IsCorrect = dto.IsCorrect;

            await _answerOptionRepository
                .SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAnswerOptionAsync(
            int id)
        {
            var answerOption =
                await _answerOptionRepository
                .GetByIdAsync(id);

            if (answerOption == null)
            {
                return false;
            }

            await _answerOptionRepository
                .DeleteAsync(answerOption);

            await _answerOptionRepository
                .SaveChangesAsync();

            return true;
        }
    }
}