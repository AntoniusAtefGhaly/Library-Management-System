using Microsoft.AspNetCore.Http;

namespace LMS.Application;

public class UpdateUserDetailsDto
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public IFormFile? ProfileImage { get; set; }
} 