namespace LMS.Application;

public class UserTransactionHistoryDto
{
    public Guid Id { get; set; }
    public int BookId { get; set; }
    public string BookName { get; set; } = null!;
    public string BookImageUrl { get; set; } = null!;

    public DateTime RequestDate { get; set; }
    public DateTime? IssueDate { get; set; }
    public DateTime? DueDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    public string Status { get; set; } = null!;
    public bool IsOverdue => Status == "Overdue";
    public int DaysRemaining => DueDate.HasValue? (int)(DueDate.Value - DateTime.Now).TotalDays : 0;
} 