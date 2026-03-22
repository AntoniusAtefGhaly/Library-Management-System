using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FluentAssertions;
using LMS.Application;
using LMS.Application.Dtos.Transaction;
using LMS.Application.Managers.Interfaces;
using LMS.Application.Shared.Models;
using LMS.Domain.Entities;
using LMS.Domain.Enums;
using LMS.Domain.Interfaces.Repositories;
using Moq;
using Xunit;

namespace LMS.Tests.Application.Services
{
    public class TransactionServiceTests
    {
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly Mock<ITransactionRepository> _transactionRepositoryMock;
        private readonly Mock<IBookRepository> _bookRepositoryMock;
        private readonly Mock<ITrendingBooksService> _trendingBooksServiceMock;
        private readonly Mock<ICurrentUserService> _currentUserServiceMock;
        private readonly Mock<IEmailService> _emailServiceMock;
        private readonly Mock<IReportService> _reportServiceMock;
        private readonly TransactionService _sut;

        public TransactionServiceTests()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _transactionRepositoryMock = new Mock<ITransactionRepository>();
            _bookRepositoryMock = new Mock<IBookRepository>();
            _trendingBooksServiceMock = new Mock<ITrendingBooksService>();
            _currentUserServiceMock = new Mock<ICurrentUserService>();
            _emailServiceMock = new Mock<IEmailService>();
            _reportServiceMock = new Mock<IReportService>();

            _unitOfWorkMock.Setup(u => u.TransactionRepository).Returns(_transactionRepositoryMock.Object);
            _unitOfWorkMock.Setup(u => u.BookRepository).Returns(_bookRepositoryMock.Object);

            _sut = new TransactionService(
                _unitOfWorkMock.Object,
                _trendingBooksServiceMock.Object,
                _currentUserServiceMock.Object,
                _emailServiceMock.Object,
                _reportServiceMock.Object
            );
        }

        private Transaction CreateTransaction(Guid id, int userId, int bookId, string status)
        {
            var transaction = new Transaction
            {
                UserId = userId,
                BookId = bookId
            };
            transaction.Status = status; // This uses the internal logic to set _status
            
            var property = typeof(LMS.Domain.Common.AggregateRoot<Guid>).GetProperty("Id") ?? typeof(Transaction).GetProperty("Id");
            property?.SetValue(transaction, id);
            
            return transaction;
        }

        private Book CreateBook(int id, string title, int available)
        {
            var book = new Book { Title = title, AvailableCopies = available, TotalCopies = available + 1 };
            var property = typeof(LMS.Domain.Common.AggregateRoot<int>).GetProperty("Id") ?? typeof(Book).GetProperty("Id");
            property?.SetValue(book, id);
            return book;
        }

        [Fact]
        public async Task BorrowBookAsync_ShouldSucceed_WhenBookIsAvailable()
        {
            // Arrange
            _currentUserServiceMock.Setup(c => c.UserId).Returns("123");
            var dto = new BorrowBookDto { BookId = 1, BorrowDays = 30 };
            var book = CreateBook(1, "Available Book", 5);

            _bookRepositoryMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(book);
            _transactionRepositoryMock.Setup(r => r.AnyAsync(It.IsAny<Expression<Func<Transaction, bool>>>()))
                .ReturnsAsync(false);
            _unitOfWorkMock.Setup(u => u.SaveChangesAsync()).ReturnsAsync(1);

            // Act
            var result = await _sut.BorrowBookAsync(dto);

            // Assert
            result.IsSuccess.Should().BeTrue();
            result.Message.Should().Be("Book borrowed successfully");
            book.AvailableCopies.Should().Be(4);
            _transactionRepositoryMock.Verify(r => r.AddAsync(It.IsAny<Transaction>()), Times.Once);
            _trendingBooksServiceMock.Verify(t => t.SetTrendingBookAsync(1), Times.Once);
            _unitOfWorkMock.Verify(u => u.SaveChangesAsync(), Times.Once);
        }

        [Fact]
        public async Task BorrowBookAsync_ShouldFail_WhenBookIsNotAvailable()
        {
            // Arrange
            _currentUserServiceMock.Setup(c => c.UserId).Returns("123");
            var dto = new BorrowBookDto { BookId = 1, BorrowDays = 30 };
            var book = CreateBook(1, "Empty Book", 0);

            _bookRepositoryMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(book);

            // Act
            var result = await _sut.BorrowBookAsync(dto);

            // Assert
            result.IsSuccess.Should().BeFalse();
            result.Message.Should().Be("Book is not available for borrowing");
        }

        [Fact]
        public async Task IssueBookAsync_ShouldSucceed_WhenTransactionIsPending()
        {
            // Arrange
            _currentUserServiceMock.Setup(c => c.UserId).Returns("100"); // Librarian ID
            var transactionId = Guid.NewGuid();
            var transaction = CreateTransaction(transactionId, 123, 1, "Pending");
            transaction.RequestDate = DateTime.Now.AddDays(-1);
            transaction.BorrowDays = 14;

            _transactionRepositoryMock.Setup(r => r.GetByIdAsync(transactionId.ToString())).ReturnsAsync(transaction);
            _unitOfWorkMock.Setup(u => u.SaveChangesAsync()).ReturnsAsync(1);

            var dto = new IssueBookDto { TransactionId = transactionId.ToString(), IssueDate = DateTime.Now.AddHours(-1) };

            // Act
            var result = await _sut.IssueBookAsync(dto);

            // Assert
            result.IsSuccess.Should().BeTrue();
            result.Message.Should().Be("Book has been Issued successfully");
            transaction.Status.Should().Be("Issued");
            transaction.IssueDate.Should().NotBeNull();
            transaction.DueDate.Should().NotBeNull();
            _transactionRepositoryMock.Verify(r => r.Update(transaction), Times.Once);
        }

        [Fact]
        public async Task ReturnBookAsync_ShouldSucceed_WhenTransactionIsIssued()
        {
            // Arrange
            _currentUserServiceMock.Setup(c => c.UserId).Returns("100");
            var transactionId = Guid.NewGuid();
            var book = CreateBook(1, "Book", 4);
            var transaction = CreateTransaction(transactionId, 123, 1, "Issued");
            transaction.Book = book;
            transaction.IssueDate = DateTime.Now.AddDays(-7);
            
            _transactionRepositoryMock.Setup(r => r.GetByIdAsync(transactionId.ToString())).ReturnsAsync(transaction);
            _unitOfWorkMock.Setup(u => u.SaveChangesAsync()).ReturnsAsync(1);

            var dto = new ReturnBookDto { TransactionId = transactionId.ToString(), ReturnDate = DateTime.Now.AddHours(-1), Notes = "Good" };

            // Act
            var result = await _sut.ReturnBookAsync(dto);

            // Assert
            result.IsSuccess.Should().BeTrue();
            result.Message.Should().Be("Book has been Returned successfully");
            transaction.Status.Should().Be("Returned");
            book.AvailableCopies.Should().Be(5);
        }
    }
}
