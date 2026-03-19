using Microsoft.AspNetCore.Http;

namespace LMS.Application;

public class UpdateUserDto
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Role { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? PhoneNumber { get; set; }
    public IFormFile? ProfileImageUrl { get; set; }

}
