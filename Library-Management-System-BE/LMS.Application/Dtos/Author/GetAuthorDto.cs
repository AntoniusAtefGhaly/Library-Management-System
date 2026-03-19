using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.Dtos.Author
{
    public class GetAuthorDto
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public string? Description { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public bool IsActive { get; set; }
        public string? ImageURL { get; set; }
        public int BookCount { get; set; }
    }
}
