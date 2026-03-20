using LMS.Domain.Entities;
using LMS.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace LMS.Infrastructure.Repos.Services
{
    public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
    {
        #region Fileds & Properities

        private readonly LMSDbContext _context;

        #endregion

        #region Construcors

        public AuthorRepository(LMSDbContext context) : base(context)
        {
            _context = context;
        }
        #endregion

        #region Functions
        public async Task<bool> checkAuthorHasBook(int id)
        {
            var hasBooks = await _context.Book.FirstOrDefaultAsync(b => b.AuthorId == id);
            if (hasBooks != null)
                return true;
            return false;
        }
        public async Task<IEnumerable<Author>> GetAllAuthors()
        {
            return await _context.Authors.Where(a => a.IsActive).ToListAsync();
        }
        public async Task<pagedResult<Author>> GetAllAuthors(int pageNumber, int pageSize, int sortOrder = 1, string? sortField = null, string? search = null, bool? isActive = null)
        {
            pagedResult<Author> pagedResult = new pagedResult<Author>();
            var query = _context.Authors.AsQueryable();
            if (!search.IsNullOrEmpty())
            {
                query = query.Where(a => a.FullName.Contains(search) || (a.Description != null && a.Description.Contains(search)));
                pagedResult.TotalCount = query.Count();
            }
            if (!sortField.IsNullOrEmpty())
            {
                switch (sortField)
                {
                    case "FullName":
                        {
                            query = sortOrder == 1 ? query.OrderBy(a => a.FullName) : query.OrderByDescending(a => a.Description);
                            break;
                        }

                    case "InsertedTime":
                        {
                            query = sortOrder == 1 ? query.OrderBy(a => a.InsertedTime) : query.OrderByDescending(a => a.InsertedTime);
                            break;
                        }

                    case "DateOfBirth":
                        {
                            query = sortOrder == 1 ? query.OrderBy(a => a.DateOfBirth) : query.OrderByDescending(a => a.DateOfBirth);
                            break;
                        }
                }
            }
            if (sortOrder > 0 && sortField.IsNullOrEmpty())
            {
                query = sortOrder == 1 ? query.OrderBy(a => a.FullName) : query.OrderByDescending(a => a.FullName);
            }
            if (isActive != null)
            {
                query = query.Where(a => a.IsActive == isActive);
                pagedResult.TotalCount = _context.Authors.Count(a => a.IsActive == isActive);
            }
            if ((isActive == null) && search.IsNullOrEmpty())
            {
                pagedResult.TotalCount = _context.Authors.Count();
            }
            var skip = (pageNumber - 1) * pageSize;
            pagedResult.Result = await query.Skip(skip).Take(pageSize).ToListAsync();
            return pagedResult;
        }




        #endregion

    }
}
