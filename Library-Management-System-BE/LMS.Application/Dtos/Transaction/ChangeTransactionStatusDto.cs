namespace LMS.Application;

public class ChangeTransactionStatusDto
{
    public string TransactionId { get; set; } = null!;
    public string Status { get; set; } = null!;
    public DateTime? ReturnDate { get; set; }
} 