namespace Online_learning_system.DTOs
{
    public class UpdateQuestionDto
    {
        public int QuizId { get; set; }

        public string QuestionText { get; set; }
            = string.Empty;
    }
}