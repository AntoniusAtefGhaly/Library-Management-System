using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.Dtos.Category
{
   
      public record CategoryParams(int sortOrder = 1, string? sortField = null, string? Search = null, bool? isActive = null);

}
