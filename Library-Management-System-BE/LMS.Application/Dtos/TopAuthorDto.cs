using System;

namespace LMS.Application.Dtos
{
    public class TopAuthorDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int BorrowCount { get; set; }
        public string ImageUrl { get; set; }
    }
} 