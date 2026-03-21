using LMS.Domain.Entities;
using LMS.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace LMS.Infrastructure;

public class BookRepository : GenericRepository<Book>, IBookRepository
{
    #region Fileds & Properities

    private readonly LMSDbContext _context;

    #endregion

    #region Construcors

    public BookRepository(LMSDbContext context) : base(context)
    {
        _context = context;
    }

    #endregion

    #region Functions
    public async Task<pagedResult<Book>> GetBooksPaged(int pageNumber, int pageSize, int sortOrder = 1, string? sortField = null, string? Search = null, int? categoryId = null, int? authorId = null)
    {
        pagedResult<Book> pagedResult = new pagedResult<Book>();
        var query = _context.Book.Include(b => b.Author).Include(b => b.Category).AsQueryable();
        if (!Search.IsNullOrEmpty())
        {
            query = query.Where(b => b.Title.Contains(Search) || b.Description != null && b.Description.Contains(Search));
        }
        if (!sortField.IsNullOrEmpty())
        {
            switch (sortField)
            {
                case "publicationYear":
                    {
                        if (sortOrder == 1)
                        {
                            query = query.OrderBy(B => B.PublicationYear);
                        }
                        else query = query.OrderByDescending(B => B.PublicationYear);
                        break;
                    }
            }
        }
        if (categoryId != null)
        {
            query = query.Where(b => b.CategoryId == categoryId);
        }
        if (authorId != null)
        {
            query = query.Where(b => b.AuthorId == authorId);
        }
        pagedResult.TotalCount = await query.CountAsync();
        if (sortOrder == 1 && sortField.IsNullOrEmpty()) query = query.OrderBy(b => b.Title);
        else if (sortField.IsNullOrEmpty() && sortOrder == -1) query = query.OrderByDescending(b => b.Title);
        var skip = (pageNumber - 1) * pageSize;
        pagedResult.Result = await query.Skip(skip).Take(pageSize).ToListAsync();
        return pagedResult;
    }
    public async Task<Book?> getBookDetailsById(int id)
    {
        return await _context.Book.Include(b => b.Author).Include(b => b.Category).FirstOrDefaultAsync(b => b.Id == id);
    }
    public async Task<IEnumerable<Book>> getAllBooksWithAuthor()
    {
        return await _context.Book.Include(b => b.Author).AsNoTracking().ToListAsync();
    }

    public async Task<Book?> GetBookWithAuthorByIdAsync(int id)
    {
        return await _context.Book.Include(b => b.Author).FirstOrDefaultAsync(b => b.Id == id);
    }

    public async Task<IEnumerable<Book>> GetBooksByCategoryExceptBookAsync(int bookId)
    {
        return await _context.Book
            .Where(b => b.CategoryId == _context.Book
                .Where(i => i.Id == bookId)
                .Select(i => i.CategoryId)
                .FirstOrDefault()
                && b.Id != bookId)
            .AsNoTracking()
            .ToListAsync();
    }
    public async Task<List<Book>> getAllBooksWithAuthorandCategory()
    {
        return await _context.Book.Include(b => b.Author).Include(b => b.Category).AsNoTracking().ToListAsync();
    }

    public async Task<List<Book>> GetBooksByAuthorIds(List<int> authorIds)
    {
        return await _context.Book.Where(b => authorIds.Contains(b.AuthorId)).ToListAsync();
    }

    #endregion
}
