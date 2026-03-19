using System.ComponentModel.DataAnnotations;

namespace LMS.Application.Dtos.Transaction;

public class ReturnBookDto
{
    [Required]
    public string TransactionId { get; set; } = null!;
    [Required]
    public DateTime ReturnDate { get; set; }

    public string? Notes { get; set; }
}
