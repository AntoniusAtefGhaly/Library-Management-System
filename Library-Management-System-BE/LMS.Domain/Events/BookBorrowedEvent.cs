using System;
using LMS.Domain.Common;

namespace LMS.Domain.Events
{
    public class BookBorrowedEvent : DomainEvent
    {
        public Guid TransactionId { get; }
        public int BookId { get; }
        public int UserId { get; }

        public BookBorrowedEvent(Guid transactionId, int bookId, int userId)
        {
            TransactionId = transactionId;
            BookId = bookId;
            UserId = userId;
        }
    }
}
