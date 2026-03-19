namespace LMS.Application;

public class UserBorrowingHistoryRequest
{
    public int? UserId { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
} 