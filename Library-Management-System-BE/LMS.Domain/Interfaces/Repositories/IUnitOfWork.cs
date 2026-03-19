namespace LMS.Domain.Interfaces.Repositories;

public interface IUnitOfWork
{
    IBookRepository BookRepository { get; }
    IUserRepository UserRepository { get; }
    ICategoryRepository CategoryRepository { get; }
    IFeedbackRepository FeedbackRepository { get; }
    ITransactionRepository TransactionRepository { get; }
    IAuthorRepository AuthorRepository { get; }
    Task<int> SaveChangesAsync();

}
