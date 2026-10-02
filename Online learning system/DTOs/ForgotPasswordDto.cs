using System.ComponentModel.DataAnnotations;

namespace Online_learning_system.DTOs
{
    public class ForgotPasswordDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
    }
}