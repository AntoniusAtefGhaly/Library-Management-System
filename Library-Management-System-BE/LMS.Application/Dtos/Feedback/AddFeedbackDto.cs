namespace LMS.Application;

public class AddFeedbackDto
{
    public int BookId { get; set; }
    public int Rating { get; set; }
    public string Comment { get; set; } = null!;
}
