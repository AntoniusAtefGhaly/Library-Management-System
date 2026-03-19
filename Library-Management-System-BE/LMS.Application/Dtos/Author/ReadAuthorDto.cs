using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.Dtos.Author
{
    public class ReadAuthorDto
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
    }
}
