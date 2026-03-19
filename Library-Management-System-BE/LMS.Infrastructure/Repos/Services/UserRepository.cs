using LMS.Domain.Entities;
using LMS.Domain.Interfaces.Repositories;
namespace LMS.Infrastructure;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    #region Fileds & Properities

    private readonly LMSDbContext _context;

    #endregion

    #region Construcors

    public UserRepository(LMSDbContext context) : base(context)
    {
        _context = context;
    }

    #endregion

    #region Functions

    #endregion
}
