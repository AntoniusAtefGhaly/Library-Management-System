namespace LMS.Application.Shared.Models;

public class ApiPagedResult<T> : ApiResult<List<T>> where T : class
{
    public int TotalCount { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalPages => PageSize > 0 ? (int)Math.Ceiling(TotalCount / (double)PageSize) : 0;
}
