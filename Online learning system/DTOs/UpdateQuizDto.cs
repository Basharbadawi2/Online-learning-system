namespace Online_learning_system.DTOs
{
    public class UpdateQuizDto
    {
        public int ModuleId { get; set; }

        public string Title { get; set; } = string.Empty;

        public decimal PassingScore { get; set; }
    }
}