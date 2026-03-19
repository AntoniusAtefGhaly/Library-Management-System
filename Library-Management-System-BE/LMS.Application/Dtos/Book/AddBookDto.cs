using Microsoft.AspNetCore.Http;

namespace LMS.Application;

public class AddBookDto
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;

    public int AuthorId { get; set; } 
    public int CategoryId { get; set; }
    public int PublicationYear { get; set; }
    public int AvailableCopies { get; set; }
    public int TotalCopies { get; set; }
    public IFormFile? ImageUrl { get; set; }

}