using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.Dtos.Author
{
    public class UpdateAuthorDto
    {
        public int id { get; set; }
        public string fullName { get; set; } = null!;
        public string? description { get; set; }
        public DateOnly dateOfBirth { get; set; }
        public IFormFile? imageUrl { get; set; }
    }
}
