using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.Dtos.User
{
    public class UserDetailsDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime? DateofBirth { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }

        public string? ProfileImageUrl { get; set; }
    }
}
