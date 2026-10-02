namespace OnlineLearningSystem.Web.DTOs
{
    public class InstructorDto
    {
        public int InstructorId { get; set; }

        public int UserId { get; set; }

        public string? Bio { get; set; }

        public string? Specialization { get; set; }
    }
}