using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.Dtos.Book
{
    public class BookWithDetailsDto
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int? PublicationYear { get; set; }
        public int? AvailableCopies { get; set; }
        public int? TotalCopies { get; set; }
        public string? InsertedTime { get; set; }
        public string? Category { get; set; }
        public string? Author { get; set; }
        public bool HasAvailableCopies { get; set; }

    }
}
