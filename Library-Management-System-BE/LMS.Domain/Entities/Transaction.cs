using LMS.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS.Domain.Entities
{
    public class Transaction : ISharedColumns
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public int UserId { get; set; }

        public User? User { get; set; }

        [Required]
        public int BookId { get; set; }

        public Book? Book { get; set; }

        public int BorrowDays { get; set; }

        public DateTime RequestDate { get; set; }

        #region Issuing
        public DateTime? IssueDate { get; set; }

        public int? IssuedByUserId { get; set; }

        public User? IssuedByUser { get; set; }

        #endregion


        public DateTime? DueDate { get; set; } // Calculated based on the number of borrow days.

        public DateTime? ReturnDate { get; set; } // Actual return date.

        public int? ReturnedByUserId { get; set; }
        public User? ReturnedByUser { get; set; }

        public string? ReturnNotes { get; set; } 

        private string _status = "Pending";
        [Required]
        [MaxLength(20)]
        public string Status
        {
            get
            {
                // If book is not returned and due date has passed, it's overdue
                if (_status == "Issued" && ReturnDate == null && DueDate < DateTime.Now)
                {
                    return "Overdue";
                }
                return _status;
            }
            set
            {
                if (value == "Pending" || value == "Issued" || value == "Returned" || value == "Overdue")
                {
                    _status = value;
                }
                else
                {
                    throw new ArgumentException("Invalid status value. Must be 'Issued', 'Returned', or 'Overdue'");
                }
            }
        }

        // Track when the user was last notified about overdue status
        public DateTime? LastOverdueNotified { get; set; }

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
