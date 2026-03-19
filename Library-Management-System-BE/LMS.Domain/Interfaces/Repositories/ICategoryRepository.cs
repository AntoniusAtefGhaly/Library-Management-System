using LMS.Domain.Entities;

namespace LMS.Domain.Interfaces.Repositories;

public interface ICategoryRepository : IGenericRepository<Category>
{
    Task<IEnumerable<Category>> GetAllCategoriesWithBooks();
    Task<pagedResult<Category>> GetAllCategoriesAsync(int first, int rows, int sortOrder = 1, string? sortField = null, string? search = null, bool? isActive = null);
}
