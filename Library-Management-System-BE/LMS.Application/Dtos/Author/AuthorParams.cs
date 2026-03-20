namespace LMS.Application.Dtos.Author
{
    public record AuthorParams(

        int pageNumber = 1,
        int pageSize = 10,
        int sortOrder = 1,
        string? sortField = null,
        string? Search = null);
}
