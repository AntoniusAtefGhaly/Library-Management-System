using Microsoft.AspNetCore.Http;

namespace LMS.Application;

public class AddCategoryDto
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public IFormFile? ImageUrl { get; set; }

}
