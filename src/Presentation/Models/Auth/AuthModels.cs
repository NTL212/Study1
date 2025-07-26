namespace TaskProjectManagementPlatform.Presentation.Models.Auth
{
    public class RegisterModel
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string ConfirmPassword { get; set; } = string.Empty;
    }

    public class LoginModel
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

    public class AuthResponse
    {
        public bool Succeeded { get; set; }
        public string? Token { get; set; }
        public string? Message { get; set; }
    }
}
