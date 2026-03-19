using Microsoft.AspNetCore.Http;

namespace LMS.Application;

public class UpdateBookDto
{
    public int Id { get; set; } 
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int CategoryId { get; set; }
    public int AuthorId { get; set; }
    public int PublicationYear { get; set; }
    public int AvailableCopies { get; set; }
    public int TotalCopies { get; set; }
    public IFormFile? ImageUrl { get; set; }

}