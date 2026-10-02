namespace Online_learning_system.DTOs
{
    public class CreateQuizDto
    {
        public int ModuleId { get; set; }

        public string Title { get; set; } = string.Empty;

        public decimal PassingScore { get; set; }
    }
}