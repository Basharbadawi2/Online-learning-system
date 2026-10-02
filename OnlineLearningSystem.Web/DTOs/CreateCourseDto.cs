namespace OnlineLearningSystem.Web.DTOs
{
    public class CreateCourseDto
    {
        public string Title { get; set; } = null!;

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public bool IsPublished { get; set; }

        public int InstructorId { get; set; }

        public int CategoryId { get; set; }
    }
}