namespace Online_learning_system.DTOs
{
    public class CreatePaymentDto
    {
        public int StudentId { get; set; }

        public int CourseId { get; set; }

        public decimal Amount { get; set; }

        public string PaymentStatus { get; set; }
            = "Completed";

        public string? TransactionReference { get; set; }
    }
}