namespace OnlineLearningSystem.Web.DTOs
{
    public class CourseDto
    {
        public int CourseId { get; set; }

        public string Title { get; set; } = null!;

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public bool IsPublished { get; set; }

        public int InstructorId { get; set; }

        public int CategoryId { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}