using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.Dtos.Author
{
    public record AuthorParams(int sortOrder=1,string? sortField=null, string? Search = null,bool? isActive=null);
}
