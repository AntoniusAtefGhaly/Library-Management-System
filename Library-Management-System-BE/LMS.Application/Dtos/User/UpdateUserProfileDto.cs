using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.Dtos.User
{
    public class UpdateUserProfileDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public DateTime? DateOfBirth { get; set; } = null;

        public IFormFile? ProfileImageUrl { get; set; }

        public string? Role { get; set; } // Optional: if provided, update user role
    }
}
