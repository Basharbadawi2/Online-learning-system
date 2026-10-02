namespace Online_learning_system.DTOs
{
    public class CreateAnswerOptionDto
    {
        public int QuestionId { get; set; }

        public string OptionText { get; set; } = string.Empty;

        public bool IsCorrect { get; set; }
    }
}