namespace LMS.Application;

public class UserReportDto
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }
    public int BooksBorrowed { get; set; }
    public DateTime JoinedDate { get; set; }
} 