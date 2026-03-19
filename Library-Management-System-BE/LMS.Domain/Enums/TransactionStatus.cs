namespace LMS.Application;

public enum TransactionStatus
{
    Pending,
    Issued,    // Book is borrowed but not yet returned
    Returned,  // Book has been successfully returned
    Overdue    // Book is overdue (return date has passed)
}
