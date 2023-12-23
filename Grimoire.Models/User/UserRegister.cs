namespace Grimoire.Models.User;

public class UserRegister
{
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public string Password { get; set; } = string.Empty;
    public string ConfirmPassword { get; set; } = string.Empty;
}
