using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using LMS.Domain.Interfaces;
using LMS.Domain.Common;
using LMS.Domain.ValueObjects;

namespace LMS.Domain.Entities
{
    public class User : IdentityUser<int>, ISharedColumns, IAggregateRoot
    {

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; } = null!;
        public string? Address { get; set; }
        public DateTime? DateOfBirth { get; set; }

        [Url]
        public string? ProfileImageUrl { get; set; }

        [Required]
        [MaxLength(50)]
        public string Role { get; set; } = null!; // Admin, Librarian, Member

        public ICollection<Transaction> RequestedTransactions { get; set; } = new HashSet<Transaction>();
        public ICollection<Transaction> IssuedTransactions { get; set; } = new HashSet<Transaction>();
        public ICollection<Transaction> ReturnedTransactions { get; set; } = new HashSet<Transaction>();
        public ICollection<Feedback> Feedbacks { get; set; } = new HashSet<Feedback>();

        #region Shared Columns

        public DateTime? InsertedTime { get; set; }
        public string? InsertedUserId { get; set; }

        public DateTime? UpdateTime { get; set; }
        public string? UpdateUserId { get; set; }

        public bool IsActive { get; set; } = true;
        public string? ActivationUserId { get; set; }
        public DateTime? ActivationTime { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime? DeletedTime { get; set; }
        public string? DeletedUserId { get; set; }

        #endregion
    }
}
