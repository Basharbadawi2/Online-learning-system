namespace Online_learning_system.DTOs
{
    public class CreateQuizAttemptDto
    {
        public int QuizId { get; set; }

        public int StudentId { get; set; }

        public decimal Score { get; set; }
    }
}