namespace LMS.Application;

public class AddTrendingBookDto
{
    public string BookId { get; set; } = null!;
    public int BorrowCount { get; set; }
}
