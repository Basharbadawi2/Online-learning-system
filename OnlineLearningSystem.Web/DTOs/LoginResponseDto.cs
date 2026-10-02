namespace OnlineLearningSystem.Web.DTOs
{
    public class LoginResponseDto
    {
        public string Message { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
        public UserDto User { get; set; } = new();
    }

    public class UserDto
    {
        public int UserId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int RoleId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Role { get; set; } = string.Empty;
    }

    public class RoleDto
    {
        public int RoleId { get; set; }

        public string Name { get; set; } = string.Empty;
    }
}