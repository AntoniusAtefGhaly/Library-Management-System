using LMS.Domain.Interfaces;
using LMS.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS.Domain.Entities
{
    public class Author : AggregateRoot<int>, ISharedColumns
    {
        public string FullName { get; set; } = null!;
        public string? Description { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string? ImageUrl { get; set; }
        public ICollection<Book> Books { get; set; } = new HashSet<Book>();
        public DateTime? InsertedTime { get; set; }
        public string? InsertedUserId { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime? ActivationTime { get; set; }
        public string? ActivationUserId { get; set; }
        public DateTime? UpdateTime { get; set; }
        public string? UpdateUserId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedTime { get; set; }
        public string? DeletedUserId { get; set; }
    }
}
