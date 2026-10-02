namespace Online_learning_system.DTOs
{
    public class CreateModuleDto
    {
        public int CourseId { get; set; }

        public string Title { get; set; } = string.Empty;

        public int OrderNo { get; set; }
    }
}