using LMS.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS.Domain.Entities
{
    public class Category : ISharedColumns
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } // Auto-incremented primary key

        [Required]
        [MaxLength(500)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(5000)]
        public string Description { get; set; } = string.Empty;

        public string? ImageUrl { get; set; }

        public ICollection<Book> Books { get; set; } = new HashSet<Book>();

        #region Shared Columns

        public DateTime? InsertedTime { get; set; }
        public string? InsertedUserId { get; set; }

        public DateTime? UpdateTime { get; set; }
        public string? UpdateUserId { get; set; }

        public bool IsActive { get; set; } = true;
        public string? ActivationUserId { get; set; }
        public DateTime? ActivationTime { get; set; }

        public bool IsDeleted { get; set; } = false;
        public DateTime? DeletedTime { get; set; }
        public string? DeletedUserId { get; set; }

        #endregion
    }
}
