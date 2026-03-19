using LMS.Domain.Entities;
namespace LMS.Domain.Interfaces.Repositories;

public interface ITransactionRepository : IGenericRepository<Transaction>
{
    Task<bool> HasUserBorrowedBookAsync(int userId, int bookId);
    Task<List<int>> GetTopBorrowedBooksAsync(int count = 20);
    IQueryable<Transaction> GetAll();
}
