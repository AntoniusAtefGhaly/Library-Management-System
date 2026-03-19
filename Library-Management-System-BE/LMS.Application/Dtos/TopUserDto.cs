using System;

namespace LMS.Application.Dtos
{
    public class TopUserDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int BooksBorrowedCount { get; set; }
    }
} 