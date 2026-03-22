using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FluentAssertions;
using LMS.Application;
using LMS.Application.Dtos.Book;
using LMS.Application.Shared.Models;
using LMS.Domain.Entities;
using LMS.Domain.Interfaces.Repositories;
using Moq;
using Xunit;

namespace LMS.Tests.Application.Services
{
    public class TrendingBooksServiceTests
    {
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly Mock<IBookRepository> _bookRepositoryMock;
        private readonly Mock<ITransactionRepository> _transactionRepositoryMock;
        private readonly TrendingBooksService _sut;

        public TrendingBooksServiceTests()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _bookRepositoryMock = new Mock<IBookRepository>();
            _transactionRepositoryMock = new Mock<ITransactionRepository>();

            _unitOfWorkMock.Setup(u => u.BookRepository).Returns(_bookRepositoryMock.Object);
            _unitOfWorkMock.Setup(u => u.TransactionRepository).Returns(_transactionRepositoryMock.Object);

            _sut = new TrendingBooksService(_unitOfWorkMock.Object);
        }

        private Book CreateBook(int id, string title, bool isTrending = false)
        {
            var book = new Book { Title = title, IsTrending = isTrending, AvailableCopies = 1 };
            book.Author = new Author { FullName = "Author Name" };
            var property = typeof(LMS.Domain.Common.AggregateRoot<int>).GetProperty("Id") ?? typeof(Book).GetProperty("Id");
            property?.SetValue(book, id);
            return book;
        }

        [Fact]
        public async Task GetAllTrendingBooksAsync_ShouldReturnTrendingAndTopBorrowedBooks()
        {
            // Arrange
            var trendingBook = CreateBook(1, "Trending1", true);
            var topBorrowedBook = CreateBook(2, "TopBorrowed1", false);

            _bookRepositoryMock.Setup(r => r.GetWhereIncludeAsync(It.IsAny<Expression<Func<Book, bool>>>(), It.IsAny<string[]>()))
                .ReturnsAsync((Expression<Func<Book, bool>> predicate, string[] includes) => 
                {
                    var compiled = predicate.Compile();
                    var allBooks = new List<Book> { trendingBook, topBorrowedBook };
                    return allBooks.Where(compiled).ToList();
                });

            _transactionRepositoryMock.Setup(r => r.GetTopBorrowedBooksAsync(20)).ReturnsAsync(new List<int> { 2 });

            var bookParams = new BookParams { pageNumber = 1, pageSize = 10 };

            // Act
            var result = await _sut.GetAllTrendingBooksAsync(bookParams);

            // Assert
            result.IsSuccess.Should().BeTrue();
            result.Data.Should().Contain(b => b.Title == "Trending1");
            result.Data.Should().Contain(b => b.Title == "TopBorrowed1");
        }

        [Fact]
        public async Task GetAllTrendingBooksAsync_RefinedMock_ShouldHandleFiltering()
        {
            // Arrange
            var trendingBook = CreateBook(1, "TrendingBook", true);
            var topBorrowedBook = CreateBook(2, "PopularBook", false);

            _bookRepositoryMock.Setup(r => r.GetWhereIncludeAsync(It.IsAny<Expression<Func<Book, bool>>>(), It.IsAny<string[]>()))
                .ReturnsAsync((Expression<Func<Book, bool>> predicate, string[] includes) => 
                {
                    var compiled = predicate.Compile();
                    var allBooks = new List<Book> { trendingBook, topBorrowedBook };
                    return allBooks.Where(compiled).ToList();
                });

            _transactionRepositoryMock.Setup(r => r.GetTopBorrowedBooksAsync(20)).ReturnsAsync(new List<int> { 2 });

            var bookParams = new BookParams { pageNumber = 1, pageSize = 10, Search = "Trending" };

            // Act
            var result = await _sut.GetAllTrendingBooksAsync(bookParams);

            // Assert
            result.IsSuccess.Should().BeTrue();
            result.Data.Should().HaveCount(1);
            result.Data!.First().Title.Should().Be("TrendingBook");
        }

        [Fact]
        public async Task SetTrendingBookAsync_ShouldUpdateBookAndReturnSuccess()
        {
            // Arrange
            var book = CreateBook(1, "Test Book", false);
            _bookRepositoryMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(book);
            _unitOfWorkMock.Setup(u => u.SaveChangesAsync()).ReturnsAsync(1);

            // Act
            var result = await _sut.SetTrendingBookAsync(1);

            // Assert
            result.IsSuccess.Should().BeTrue();
            book.IsTrending.Should().BeTrue();
            _unitOfWorkMock.Verify(u => u.SaveChangesAsync(), Times.Once);
        }
    }
}
