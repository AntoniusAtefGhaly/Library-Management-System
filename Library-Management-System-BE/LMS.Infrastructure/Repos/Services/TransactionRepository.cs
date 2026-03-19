using LMS.Domain.Entities;
using LMS.Domain.Interfaces.Repositories;
using LMS.Application;
using Microsoft.EntityFrameworkCore;

namespace LMS.Infrastructure;

public class TransactionRepository : GenericRepository<Transaction>, ITransactionRepository
{
    #region Fileds & Properities

    private readonly LMSDbContext _context;

    #endregion

    #region Construcors

    public TransactionRepository(LMSDbContext context) : base(context)
    {
        _context = context;
    }

    #endregion

    #region Functions

    public override async Task<IEnumerable<Transaction>> GetAllAsync()
    {
        return await _context.Transaction
            .Include(t => t.User)
            .Include(t => t.Book)
            .Include(t => t.IssuedByUser)
            .Include(t => t.ReturnedByUser)
            .ToListAsync();
    }

    public override async Task<Transaction?> GetByIdAsync(object id)
    {
        var idGuid = new Guid((string)id);

        return await _context.Transaction
            .Include(t => t.User)
            .Include(t => t.Book)
            .Include(t => t.IssuedByUser)
            .Include(t => t.ReturnedByUser)
            .FirstOrDefaultAsync(t => t.Id == idGuid);
    }

    public async Task<bool> HasUserBorrowedBookAsync(int userId, int bookId)
    {
        return await _context.Transaction
            .AnyAsync(t => t.UserId == userId &&
                          t.BookId == bookId &&
                          t.Status == TransactionStatus.Returned.ToString());
    }

    public async Task<List<int>> GetTopBorrowedBooksAsync(int count = 20)
    {
        return await _context.Transaction
            .GroupBy(t => t.BookId)
            .Select(g => new
            {
                BookId = g.Key,
                TransactionCount = g.Count()
            })
            .OrderByDescending(x => x.TransactionCount)
            .Take(count)
            .Select(x => x.BookId)
            .ToListAsync();
    }

    public IQueryable<Transaction> GetAll()
    {
        return _context.Transaction.AsQueryable();
    }

    public async Task<int> GetTransactionCountByStatusAsync(string? status = null)
    {
        if (status == null)
            return await _context.Transaction.CountAsync();

        return await _context.Transaction.CountAsync(t => t.Status == status);
    }

    public async Task<List<KeyValuePair<string, int>>> GetTopBorrowedBookNamesAsync(int count = 5)
    {
        return await _context.Transaction
            .Where(t => t.Status != TransactionStatus.Pending.ToString())
            .GroupBy(t => new { t.BookId, t.Book.Title })
            .Select(g => new KeyValuePair<string, int>(g.Key.Title, g.Count()))
            .OrderByDescending(x => x.Value)
            .Take(count)
            .ToListAsync();
    }

    public async Task<List<KeyValuePair<string, int>>> GetTopBorrowedAuthorNamesAsync(int count = 5)
    {
        return await _context.Transaction
            .Where(t => t.Status != TransactionStatus.Pending.ToString())
            .GroupBy(t => new { t.Book.AuthorId, t.Book.Author.FullName })
            .Select(g => new KeyValuePair<string, int>(g.Key.FullName, g.Count()))
            .OrderByDescending(x => x.Value)
            .Take(count)
            .ToListAsync();
    }

    public async Task<List<KeyValuePair<string, int>>> GetTopBorrowedCategoryNamesAsync(int count = 5)
    {
        return await _context.Transaction
            .Where(t => t.Status != TransactionStatus.Pending.ToString())
            .GroupBy(t => new { t.Book.CategoryId, t.Book.Category.Name })
            .Select(g => new KeyValuePair<string, int>(g.Key.Name, g.Count()))
            .OrderByDescending(x => x.Value)
            .Take(count)
            .ToListAsync();
    }

    public async Task<List<KeyValuePair<string, int>>> GetTopBorrowingUserNamesAsync(int count = 5)
    {
        return await _context.Transaction
            .Where(t => t.Status != TransactionStatus.Pending.ToString())
            .GroupBy(t => new { t.UserId, t.User.FirstName, t.User.LastName })
            .Select(g => new KeyValuePair<string, int>(
                $"{g.Key.FirstName} {g.Key.LastName}", g.Count()))
            .OrderByDescending(x => x.Value)
            .Take(count)
            .ToListAsync();
    }

    #endregion
}
