namespace LMS.Application;
public class TransactionDetailsDto
{
    public Guid Id { get; set; }
    public int UserId { get; set; }  
    public int BookId { get; set; }
    public string UserFullName { get; set; } = null!;
    public string BookName { get; set; } = null!;

    public int BorrowDays { get; set; }
    public DateTime RequestDate { get; set; }

    public DateTime? IssueDate { get; set; }

    public string? IssuedByUser { get; set; }
    public DateTime? DueDate { get; set; }
    public DateTime? ReturnDate { get; set; }

    public string? ReturnedByUser { get; set; }

    public string? ReturnNotes { get; set; }
    public string Status { get; set; } = null!;
}
