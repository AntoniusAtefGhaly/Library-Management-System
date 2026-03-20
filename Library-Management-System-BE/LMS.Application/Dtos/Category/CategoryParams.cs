namespace LMS.Application.Dtos.Category
{
    public record CategoryParams(
        int first = 0,
        int rows = 10,
        int sortOrder = 1,
        string? sortField = null,
        string? Search = null,
        bool? isActive = null);
}
