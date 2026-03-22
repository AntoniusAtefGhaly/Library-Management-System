using LMS.Domain.Entities;

namespace LMS.Domain.Interfaces.Repositories
{
    public interface IAuthorRepository : IGenericRepository<Author>
    {
        Task<IEnumerable<Author>> GetAllAuthors();
        Task<pagedResult<Author>> GetAllAuthors(int pageNumber, int pageSize, int sortOrder = 1, string? sortField = null, string? search = null, bool? isActive = null);
        Task<bool> checkAuthorHasBook(int id);

    }
}
