namespace LMS.Application;

public class AddTransactionDto
{
    public int UserId { get; set; } 
    public int BookId { get; set; }
    public DateTime IssueDate { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    public string Status { get; set; } = null!;
}
