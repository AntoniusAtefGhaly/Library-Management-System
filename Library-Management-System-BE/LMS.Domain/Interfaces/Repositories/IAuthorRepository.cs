using LMS.Domain.Entities;
using LMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Domain.Interfaces.Repositories
{
    public interface IAuthorRepository:IGenericRepository<Author>
    {
        Task<IEnumerable<Author>> GetAllAuthors();
        Task<pagedResult<Author>> GetAllAuthors(int first, int rows,int sortOrder=1,string? sortField = null,string? search = null,bool? isActive=null);
        Task<bool> checkAuthorHasBook(int id);

    }
}
