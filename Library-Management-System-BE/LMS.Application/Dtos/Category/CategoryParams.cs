namespace LMS.Application.Dtos.Category
{
    public record CategoryParams(
        int pageNumber = 1,
        int pageSize = 10,
        int sortOrder = 1,
        string? sortField = null,
        string? Search = null,
        bool? isActive = null);
}
