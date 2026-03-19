using Microsoft.AspNetCore.Http;
using System.Security.Claims;
namespace LMS.Application;

public class CurrentUserService : ICurrentUserService
{
    public string? UserId { get; }

    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        UserId = httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    }
}
