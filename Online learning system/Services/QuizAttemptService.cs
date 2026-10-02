using Online_learning_system.DTOs;
using Online_learning_system.Models;
using Online_learning_system.Repositories;

namespace Online_learning_system.Services
{
    public class QuizAttemptService : IQuizAttemptService
    {
        private readonly IQuizAttemptRepository
            _attemptRepository;

        private readonly IQuizRepository
            _quizRepository;

        public QuizAttemptService(
            IQuizAttemptRepository attemptRepository,
            IQuizRepository quizRepository)
        {
            _attemptRepository = attemptRepository;
            _quizRepository = quizRepository;
        }

        public async Task<List<QuizAttempt>>
            GetAllAttemptsAsync()
        {
            return await _attemptRepository
                .GetAllAsync();
        }

        public async Task<QuizAttempt?>
            GetAttemptByIdAsync(int id)
        {
            return await _attemptRepository
                .GetByIdAsync(id);
        }

        public async Task<string> CreateAttemptAsync(
            CreateQuizAttemptDto dto)
        {
            var quiz =
                await _quizRepository
                .GetByIdAsync(dto.QuizId);

            if (quiz == null)
            {
                return "Quiz not found.";
            }

            bool passed =
                dto.Score >= quiz.PassingScore;

            var attempt = new QuizAttempt
            {
                QuizId = dto.QuizId,
                StudentId = dto.StudentId,
                Score = dto.Score,
                Passed = passed,
                AttemptedAt = DateTime.Now
            };

            await _attemptRepository
                .AddAsync(attempt);

            await _attemptRepository
                .SaveChangesAsync();

            return passed
                ? "Quiz attempt submitted. Student passed."
                : "Quiz attempt submitted. Student failed.";
        }

        public async Task<bool>
            DeleteAttemptAsync(int id)
        {
            var attempt =
                await _attemptRepository
                .GetByIdAsync(id);

            if (attempt == null)
            {
                return false;
            }

            await _attemptRepository
                .DeleteAsync(attempt);

            await _attemptRepository
                .SaveChangesAsync();

            return true;
        }
    }
}