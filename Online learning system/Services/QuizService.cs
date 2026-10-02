using Online_learning_system.DTOs;
using Online_learning_system.Models;
using Online_learning_system.Repositories;

namespace Online_learning_system.Services
{
    public class QuizService : IQuizService
    {
        private readonly IQuizRepository _quizRepository;

        public QuizService(IQuizRepository quizRepository)
        {
            _quizRepository = quizRepository;
        }

        public async Task<List<Quiz>> GetAllQuizzesAsync()
        {
            return await _quizRepository.GetAllAsync();
        }

        public async Task<Quiz?> GetQuizByIdAsync(int id)
        {
            return await _quizRepository.GetByIdAsync(id);
        }

        public async Task<string> CreateQuizAsync(
            CreateQuizDto dto)
        {
            var existingQuiz =
                await _quizRepository.GetByModuleIdAsync(
                    dto.ModuleId);

            if (existingQuiz != null)
            {
                return "This module already has a quiz.";
            }

            var quiz = new Quiz
            {
                ModuleId = dto.ModuleId,
                Title = dto.Title,
                PassingScore = dto.PassingScore
            };

            await _quizRepository.AddAsync(quiz);

            await _quizRepository.SaveChangesAsync();

            return "Quiz created successfully.";
        }

        public async Task<bool> UpdateQuizAsync(
            int id,
            UpdateQuizDto dto)
        {
            var quiz =
                await _quizRepository.GetByIdAsync(id);

            if (quiz == null)
            {
                return false;
            }

            quiz.ModuleId = dto.ModuleId;
            quiz.Title = dto.Title;
            quiz.PassingScore = dto.PassingScore;

            await _quizRepository.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteQuizAsync(int id)
        {
            var quiz =
                await _quizRepository.GetByIdAsync(id);

            if (quiz == null)
            {
                return false;
            }

            await _quizRepository.DeleteAsync(quiz);

            await _quizRepository.SaveChangesAsync();

            return true;
        }
    }
}