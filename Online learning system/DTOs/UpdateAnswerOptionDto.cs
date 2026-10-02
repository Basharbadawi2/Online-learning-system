namespace Online_learning_system.DTOs
{
    public class UpdateAnswerOptionDto
    {
        public int QuestionId { get; set; }

        public string OptionText { get; set; } = string.Empty;

        public bool IsCorrect { get; set; }
    }
}