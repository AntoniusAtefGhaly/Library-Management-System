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



    #endregion
}
