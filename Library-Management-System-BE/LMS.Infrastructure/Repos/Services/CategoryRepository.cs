using LMS.Domain.Interfaces.Repositories;
using LMS.Domain.Entities;
using LMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace LMS.Infrastructure;

public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
    #region Fileds & Properities

    private readonly LMSDbContext _context;

    #endregion

    #region Construcors

    public CategoryRepository(LMSDbContext context) : base(context)
    {
        _context = context;
    }

    #endregion

    #region Functions

    public async Task<IEnumerable<Category>> GetAllCategoriesWithBooks()
    {
        return await _context.Category
                                .Include(x => x.Books)
                                .ToListAsync();

    }
    public async Task<pagedResult<Category>> GetAllCategoriesAsync(int first, int rows, int sortOrder = 1, string? sortField = null, string? search = null, bool? isActive = null)
    {
        pagedResult<Category> pagedResult = new pagedResult<Category>();
        var query = _context.Category.AsQueryable();
        if (!search.IsNullOrEmpty())
        {
            query = query.Where(a =>  (!string.IsNullOrEmpty(search) &&a.Name.Contains(search)) || (!string.IsNullOrEmpty(search) && a.Description.Contains(search)));
            pagedResult.TotalCount = query.Count();
        }
        if (!sortField.IsNullOrEmpty())
        {
            switch (sortField)
            {
                case "Name":
                    {
                        query = sortOrder == 1 ? query.OrderBy(a => a.Name) : query.OrderByDescending(a => a.Name);
                        break;
                    }
            }
        }
        if (sortOrder > 0 && sortField.IsNullOrEmpty())
        {
            query = sortOrder == 1 ? query.OrderBy(a => a.Name) : query.OrderByDescending(a => a.Name);
        }
        if (isActive != null)
        {
            query = query.Where(a => a.IsActive == isActive);
            pagedResult.TotalCount = _context.Category.Count(a => a.IsActive == isActive);
        }
        if ((isActive == null) && search.IsNullOrEmpty())
        {
            pagedResult.TotalCount = _context.Category.Count();
        }
        pagedResult.Result = await query.Skip(first).Take(rows).ToListAsync();
        return pagedResult;
    }
    #endregion


}
