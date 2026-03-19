namespace LMS.Application;

public class TokenDto
{
    public int UserId { get; set; }
    public string Email { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string? UserImageUrl { get; set; }
    public string Token { get; set; } = null!;
    public long ExpiresIn { get; set; }

    public string Role { get; set; } = null!;
}