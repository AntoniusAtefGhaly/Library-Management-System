namespace LMS.Application;

public class GetBookDto
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string? Description { get; set; } = null!;
    public string AuthorName { get; set; } = null!;
    public int authorId { get; set; }
    public string? ImageUrl { get; set; }
    public int PublicationYear { get; set; }
    public int AvailableCopies { get; set; }
    public int TotalCopies { get; set; }
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }
    public bool IsBorrowed { get; set; }
    public bool HasAvailableCopies { get; set; }
}
