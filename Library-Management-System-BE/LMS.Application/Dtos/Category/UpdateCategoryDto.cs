using Microsoft.AspNetCore.Http;

namespace LMS.Application;

public class UpdateCategoryDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public IFormFile? ImageUrl { get; set; }

}
