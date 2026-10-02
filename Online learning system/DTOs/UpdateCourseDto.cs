namespace Online_learning_system.DTOs
{
    public class UpdateCourseDto
    {
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public bool IsPublished { get; set; }
        public int InstructorId { get; set; }
        public int CategoryId { get; set; }
    }
}