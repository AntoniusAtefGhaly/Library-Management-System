namespace LMS.Application;

public class GetTrendingBookDto
{
    public Guid Id { get; set; }
    public int BookId { get; set; }
    public int BorrowCount { get; set; }
}
