namespace LMS.Application.Dtos.Book
{
    public record BookParams(
        int pageNumber = 1,
        int pageSize = 10,
        int sortOrder = 1,
        string? sortField = null,
        string? Search = null,
        int? authorId = null,
        int? categoryId = null);
}
