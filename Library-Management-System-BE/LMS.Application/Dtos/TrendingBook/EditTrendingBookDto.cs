namespace LMS.Application;

public class EditTrendingBookDto
{
    public string Id { get; set; } = null!;
    public string BookId { get; set; } = null!;
    public int BorrowCount { get; set; }
}
