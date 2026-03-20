namespace LMS.Application.Dtos.Book
{
    public record BookParams(
        int first = 0,
        int rows = 10,
        int sortOrder = 1,
        string? sortField = null,
        string? Search = null,
        int? authorId = null,
        int? categoryId = null);
}
