using LMS.Infrastructure;
using LMS.Domain.Interfaces.Repositories;

namespace LMS.Infrastructure.Repos.Services;

public class UnitOfWork : IUnitOfWork
{
    #region Fields & Propereties

    private readonly LMSDbContext _context;

    public IBookRepository BookRepository { get; }
    public ICategoryRepository CategoryRepository { get; }
    public IFeedbackRepository FeedbackRepository { get; }
    public ITransactionRepository TransactionRepository { get; }
    public IUserRepository UserRepository { get; }
    public IAuthorRepository AuthorRepository { get; }
    #endregion



    #region Constructors

    public UnitOfWork(
          LMSDbContext context
        , IBookRepository bookRepository
        , ICategoryRepository categoryRepository
        , IFeedbackRepository feedbackRepository
        , ITransactionRepository transactionRepository
        , IUserRepository userRepository
        , IAuthorRepository authorRepository
                )
    {
        _context = context;
        BookRepository = bookRepository;
        CategoryRepository = categoryRepository;
        FeedbackRepository = feedbackRepository;
        TransactionRepository = transactionRepository;
        UserRepository = userRepository;
        AuthorRepository = authorRepository;
    }
    #endregion

    #region Functions

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    #endregion

}
