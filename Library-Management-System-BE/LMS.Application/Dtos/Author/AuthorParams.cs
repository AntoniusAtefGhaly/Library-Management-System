namespace LMS.Application.Dtos.Author
{
    public record AuthorParams(

        int first = 0,
        int rows = 10,
        int sortOrder = 1,
        string? sortField = null,
        string? Search = null);
}
