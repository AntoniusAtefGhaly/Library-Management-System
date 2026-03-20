using LMS.Domain.Entities;

namespace LMS.Domain.Interfaces.Repositories;

public interface IBookRepository : IGenericRepository<Book>
{
    Task<pagedResult<Book>> GetBooksPaged(int pageNumber, int pageSize, int sortOrder = 1, string? sortField = null, string? Search = null, int? categoryI = null, int? authorId = null);
    Task<Book?> getBookDetailsById(int id);
    Task<IEnumerable<Book>> getAllBooksWithAuthor();
    Task<List<Book>> getAllBooksWithAuthorandCategory();
    Task<Book?> GetBookWithAuthorByIdAsync(int id);
    Task<IEnumerable<Book>> GetBooksByCategoryExceptBookAsync(int bookId);
    Task<List<Book>> GetBooksByAuthorIds(List<int> authorIds);
}
