namespace LMS.Application;

public class GetFeedbackDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string UserFirstName { get; set; }
    public string UserLastName { get; set; }
    public int BookId { get; set; }
    public int Rating { get; set; }
    public string Comment { get; set; }
}
