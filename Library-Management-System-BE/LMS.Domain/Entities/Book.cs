using LMS.Domain.Common;
using LMS.Domain.Interfaces;
using LMS.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS.Domain.Entities
{
    public class Book : AggregateRoot<int>, ISharedColumns, IAggregateRoot
    {

        [Required]
        [MaxLength(500)]
        public string Title { get; set; } = null!;

        public ISBN ISBN { get; set; } = null!;


        [Required]
        public int AuthorId { get; set; }
        [Url]
        public string? ImageUrl { get; set; }
        [MaxLength(5000)]
        public string? Description { get; set; }

        //public string? LongDescription { get; set; }

        [Required]
        public int PublicationYear { get; set; }

        [Required]
        public int AvailableCopies { get; set; }

        [Required]
        public int TotalCopies { get; set; }

        [Required]
        public int CategoryId { get; set; } // Changed to match the schema (Guid)

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }
        public Author Author { get; set; }
        public bool IsTrending { get; set; }

        public ICollection<Transaction> Transactions { get; set; } = new HashSet<Transaction>();
        public ICollection<Feedback> Feedbacks { get; set; } = new HashSet<Feedback>();

        #region Shared Columns

        public DateTime? InsertedTime { get; set; }

        [MaxLength(50)]
        public string? InsertedUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        [MaxLength(50)]
        public string? UpdateUserId { get; set; }

        public bool IsActive { get; set; } = true;

        [MaxLength(50)]
        public string? ActivationUserId { get; set; }

        public DateTime? ActivationTime { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedTime { get; set; }

        [MaxLength(50)]
        public string? DeletedUserId { get; set; }

        #endregion
    }
}
