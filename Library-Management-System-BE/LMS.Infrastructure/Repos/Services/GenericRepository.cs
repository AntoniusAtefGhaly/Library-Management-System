using LMS.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LMS.Infrastructure;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    #region Fields & Properties

    private readonly LMSDbContext _context;

    #endregion

    #region Constructors

    public GenericRepository(LMSDbContext context)
    {
        _context = context;
    }

    #endregion

    #region Functions

    public virtual async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _context.Set<T>()
                             .AsNoTracking()
                             .ToListAsync();
    }
    public virtual async Task<T?> GetByIdAsync(object id)
    {
        return await _context.Set<T>()
                             .FindAsync(id);
    }
    public async Task AddAsync(T entity) => await _context.Set<T>().AddAsync(entity);
    public void Update(T entity) => _context.Set<T>().Update(entity);
    public async Task AddRangeAsync(IEnumerable<T> entities) => await _context.Set<T>().AddRangeAsync(entities);

    public async Task DeleteAsync(T entity, string userId)
    {
        var type = typeof(T);
        var isDeletedProp = type.GetProperty("IsDeleted");
        var deletedTimeProp = type.GetProperty("DeletedTime");
        var deletedUserIdProp = type.GetProperty("DeletedUserId");

        if (isDeletedProp != null)
        {
            isDeletedProp.SetValue(entity, true);
        }

        if (deletedTimeProp != null)
        {
            deletedTimeProp.SetValue(entity, DateTime.Now);
        }

        if (userId == null) { userId = "UnKnown"; };
        if (deletedUserIdProp != null)
        {
            deletedUserIdProp.SetValue(entity, userId);
        }

        _context.Set<T>().Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<T>> GetWhereAsync(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
    {
        return await _context.Set<T>().Where(predicate).ToListAsync();
    }

    public async Task<IEnumerable<T>> GetWhereIncludeAsync(System.Linq.Expressions.Expression<Func<T, bool>> predicate, params string[] includes)
    {
        IQueryable<T> query = _context.Set<T>();
        foreach (var include in includes)
        {
            query = query.Include(include);
        }
        return await query.Where(predicate).ToListAsync();
    }

    public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
    {
        return await _context.Set<T>().AnyAsync(predicate);
    }
    public async Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null)
    {
        if (predicate != null)
            return await _context.Set<T>().CountAsync(predicate);
        else
            return await _context.Set<T>().CountAsync();
    }
    #endregion
}