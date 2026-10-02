namespace OnlineLearningSystem.Web.DTOs
{
    public class EnrollmentDto
    {
        public int EnrollmentId { get; set; }

        public int StudentId { get; set; }

        public int CourseId { get; set; }

        public DateTime EnrolledAt { get; set; }

        public decimal ProgressPercent { get; set; }

        public CourseDto? Course { get; set; }
    }
}