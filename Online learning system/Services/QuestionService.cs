using Online_learning_system.DTOs;
using Online_learning_system.Models;
using Online_learning_system.Repositories;

namespace Online_learning_system.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository
            _questionRepository;

        public QuestionService(
            IQuestionRepository questionRepository)
        {
            _questionRepository =
                questionRepository;
        }

        public async Task<List<Question>>
            GetAllQuestionsAsync()
        {
            return await _questionRepository
                .GetAllAsync();
        }

        public async Task<Question?>
            GetQuestionByIdAsync(int id)
        {
            return await _questionRepository
                .GetByIdAsync(id);
        }

        public async Task CreateQuestionAsync(
            CreateQuestionDto dto)
        {
            var question = new Question
            {
                QuizId = dto.QuizId,
                QuestionText = dto.QuestionText
            };

            await _questionRepository
                .AddAsync(question);

            await _questionRepository
                .SaveChangesAsync();
        }

        public async Task<bool>
            UpdateQuestionAsync(
            int id,
            UpdateQuestionDto dto)
        {
            var question =
                await _questionRepository
                .GetByIdAsync(id);

            if (question == null)
            {
                return false;
            }

            question.QuizId = dto.QuizId;
            question.QuestionText =
                dto.QuestionText;

            await _questionRepository
                .SaveChangesAsync();

            return true;
        }

        public async Task<bool>
            DeleteQuestionAsync(int id)
        {
            var question =
                await _questionRepository
                .GetByIdAsync(id);

            if (question == null)
            {
                return false;
            }

            await _questionRepository
                .DeleteAsync(question);

            await _questionRepository
                .SaveChangesAsync();

            return true;
        }
    }
}