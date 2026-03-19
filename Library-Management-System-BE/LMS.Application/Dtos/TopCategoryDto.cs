using System;

namespace LMS.Application.Dtos
{
    public class TopCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BorrowCount { get; set; }
        public string ImageUrl { get; set; }
    }
} 