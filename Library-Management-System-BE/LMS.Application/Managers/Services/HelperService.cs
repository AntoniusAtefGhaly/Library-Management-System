using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
namespace LMS.Application;

public class HelperService : IHelperService
{
    #region Fields & Properties

    private readonly IWebHostEnvironment _webHostEnvironment;

    public HelperService(IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
    }

    #endregion

    #region Functions

    public async Task<string> SaveFileAsync(IFormFile file, string folderName, HttpContext httpContext)
    {
        if (file == null || file.Length == 0)
            throw new ArgumentException("File cannot be empty");

        var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", folderName);
        if (!Directory.Exists(uploadsFolder))
            Directory.CreateDirectory(uploadsFolder);

        var timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
        var uniqueFileName = $"{Guid.NewGuid()}_{timestamp}{Path.GetExtension(file.FileName)}";
        var filePath = Path.Combine(uploadsFolder, uniqueFileName);

        using (var fileStream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(fileStream);
        }

        // Return only the relative path
        var relativePath = Path.Combine("Uploads", folderName, uniqueFileName).Replace('\\', '/');
        return relativePath;
    }


    #endregion
}
