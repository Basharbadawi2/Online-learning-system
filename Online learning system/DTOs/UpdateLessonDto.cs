namespace Online_learning_system.DTOs
{
    public class UpdateLessonDto
    {
        public int ModuleId { get; set; }

        public string Title { get; set; } = string.Empty;

        public string LessonType { get; set; } = string.Empty;

        public string? ContentUrl { get; set; }

        public int OrderNo { get; set; }
    }
}