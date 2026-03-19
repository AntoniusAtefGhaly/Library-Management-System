namespace LMS.Application;

public class GetCategoryDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int BooksCount { get; set; }

    public string Description { get; set; } = null!;
    public string? ImageUrl { get; set; }

}
