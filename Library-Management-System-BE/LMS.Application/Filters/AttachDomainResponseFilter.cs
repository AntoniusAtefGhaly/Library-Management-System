using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text.Json;

namespace LMS.Application;
public class AttachDomainResponseFilter : IActionFilter
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AttachDomainResponseFilter(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public void OnActionExecuting(ActionExecutingContext context) { }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        if (context.Result is ObjectResult objectResult && objectResult.Value != null)
        {
            var httpContext = _httpContextAccessor.HttpContext;
            if (httpContext == null) return;

            var baseUrl = $"{httpContext.Request.Scheme}://{httpContext.Request.Host}";

            var jsonOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = false
            };

            var jsonResponse = JsonSerializer.Serialize(objectResult.Value, jsonOptions);
            if (!string.IsNullOrEmpty(jsonResponse) && jsonResponse.Contains("Uploads/"))
            {
                var modifiedResponse = jsonResponse.Replace("Uploads/", $"{baseUrl}/Uploads/");

                var modifiedObject = JsonSerializer.Deserialize<object>(modifiedResponse, jsonOptions);
                context.Result = new ObjectResult(modifiedObject);
            }
        }
    }
}