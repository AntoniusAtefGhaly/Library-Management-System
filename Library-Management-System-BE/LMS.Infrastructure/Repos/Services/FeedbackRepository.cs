using LMS.Domain.Entities;
using LMS.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LMS.Infrastructure;

public class FeedbackRepository : GenericRepository<Feedback>, IFeedbackRepository
{
    #region Fileds & Properities

    private readonly LMSDbContext _context;

    #endregion

    #region Construcors

    public FeedbackRepository(LMSDbContext context) : base(context)
    {
        _context = context;
    }

    #endregion

    #region Functions
    public async Task<IEnumerable<Feedback>> GetAllFeedbacksByBookIdAsync(int bookId)
    {
        return await _context.Feedback
            .Include(f => f.User)
            .Where(f => f.BookId == bookId)
            .ToListAsync();
    }
    #endregion
}
