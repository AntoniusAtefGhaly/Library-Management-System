namespace LMS.Application.Shared.Models;

public class ApiResult
{
    public string? Message { get; set; }
    public bool IsSuccess { get; set; }
    public int Code { get; set; }
    public object? Data { get; set; }
    public List<ApiError>? ErrorList { get; set; }
}
public class ApiResult<T> where T : class
{
    public string? Message { get; set; }
    public bool IsSuccess { get; set; }
    public int Code { get; set; }
    public T? Data { get; set; }
    public List<ApiError>? ErrorList { get; set; }

}
