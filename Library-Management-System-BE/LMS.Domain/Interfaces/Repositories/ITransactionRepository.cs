using LMS.Domain.Entities;

namespace LMS.Domain.Interfaces.Repositories;

public interface ITransactionRepository : IGenericRepository<Transaction>
{
    Task<bool> HasUserBorrowedBookAsync(int userId, int bookId);
    Task<List<int>> GetTopBorrowedBooksAsync(int count = 20);
    IQueryable<Transaction> GetAll();

    // Dashboard queries
    Task<int> GetTransactionCountByStatusAsync(string? status = null);
    Task<List<KeyValuePair<string, int>>> GetTopBorrowedBookNamesAsync(int count = 5);
    Task<List<KeyValuePair<string, int>>> GetTopBorrowedAuthorNamesAsync(int count = 5);
    Task<List<KeyValuePair<string, int>>> GetTopBorrowedCategoryNamesAsync(int count = 5);
    Task<List<KeyValuePair<string, int>>> GetTopBorrowingUserNamesAsync(int count = 5);
}
