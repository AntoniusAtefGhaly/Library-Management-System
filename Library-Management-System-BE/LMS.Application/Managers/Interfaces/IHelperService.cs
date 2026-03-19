using Microsoft.AspNetCore.Http;

namespace LMS.Application;

public interface IHelperService
{
    Task<string> SaveFileAsync(IFormFile file, string folderName, HttpContext httpContext);

}
