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
using LMS.Domain.Enums;
using LMS.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Http;
using Moq;
using Xunit;

namespace LMS.Tests.Application.Services
{
    public class BookServiceTests
    {
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly Mock<IBookRepository> _bookRepositoryMock;
        private readonly Mock<ITransactionRepository> _transactionRepositoryMock;
        private readonly Mock<IHelperService> _helperServiceMock;
        private readonly Mock<ICurrentUserService> _currentUserServiceMock;
        private readonly Mock<IReportService> _reportServiceMock;
        private readonly BookService _sut;

        public BookServiceTests()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _bookRepositoryMock = new Mock<IBookRepository>();
            _transactionRepositoryMock = new Mock<ITransactionRepository>();
            _helperServiceMock = new Mock<IHelperService>();
            _currentUserServiceMock = new Mock<ICurrentUserService>();
            _reportServiceMock = new Mock<IReportService>();

            _unitOfWorkMock.Setup(u => u.BookRepository).Returns(_bookRepositoryMock.Object);
            _unitOfWorkMock.Setup(u => u.TransactionRepository).Returns(_transactionRepositoryMock.Object);
            
            _currentUserServiceMock.Setup(c => c.UserId).Returns("123");

            _sut = new BookService(
                _unitOfWorkMock.Object,
                _helperServiceMock.Object,
                _currentUserServiceMock.Object,
                _reportServiceMock.Object
            );
        }

        private Book CreateBook(int id, string title)
        {
            var book = new Book { Title = title, Description = "Desc", AvailableCopies = 5, TotalCopies = 10 };
            book.Author = new Author { FullName = "Author Name" };
            book.Category = new Category { Name = "Category Name" };
            
            var property = typeof(LMS.Domain.Common.AggregateRoot<int>).GetProperty("Id") ?? typeof(Book).GetProperty("Id");
            property?.SetValue(book, id);
            
            return book;
        }

        [Fact]
        public async Task GetAllBooksAsync_ShouldReturnBooksWithAuthor()
        {
            // Arrange
            var books = new List<Book> { CreateBook(1, "Book1"), CreateBook(2, "Book2") };
            _bookRepositoryMock.Setup(r => r.getAllBooksWithAuthor()).ReturnsAsync(books);

            // Act
            var result = await _sut.GetAllBooksAsync();

            // Assert
            result.IsSuccess.Should().BeTrue();
            result.Data.Should().HaveCount(2);
            result.Data!.First().Title.Should().Be("Book1");
            result.Data!.First().AuthorName.Should().Be("Author Name");
        }

        [Fact]
        public async Task GetBooksPaged_ShouldReturnApiPagedResult()
        {
            // Arrange
            var param = new BookParams { pageNumber = 1, pageSize = 10, Search = "" };
            var books = new List<Book> { CreateBook(1, "Book1") };
            var pagedResult = new pagedResult<Book> { TotalCount = 1, Result = books };
            
            _bookRepositoryMock.Setup(r => r.GetBooksPaged(param.pageNumber, param.pageSize, param.sortOrder, param.sortField, param.Search, param.categoryId, param.authorId))
                .ReturnsAsync(pagedResult);

            // Act
            var result = await _sut.GetBooksPaged(param);

            // Assert
            result.IsSuccess.Should().BeTrue();
            result.TotalCount.Should().Be(1);
            result.Data.Should().HaveCount(1);
        }

        [Fact]
        public async Task GetBookDetailsById_ShouldReturnDetails_AndDetermineIfBorrowed()
        {
            // Arrange
            var book = CreateBook(1, "Detailed Book");
            _bookRepositoryMock.Setup(r => r.getBookDetailsById(1)).ReturnsAsync(book);
            
            _transactionRepositoryMock.Setup(r => r.AnyAsync(It.IsAny<Expression<Func<Transaction, bool>>>()))
                .ReturnsAsync(true); // Faking that there is an active transaction for it

            // Act
            var result = await _sut.getBookDetailsById(1);

            // Assert
            result.IsSuccess.Should().BeTrue();
            result.Data.Should().NotBeNull();
            result.Data!.Title.Should().Be("Detailed Book");
            result.Data!.IsBorrowed.Should().BeTrue();
        }

        [Fact]
        public async Task AddBookAsync_ShouldAddAndReturnSuccess()
        {
            // Arrange
            var dto = new AddBookDto { Title = "New Book", Description = "Desc", AuthorId = 1, CategoryId = 2 };
            var httpContextMock = new Mock<HttpContext>();
            _unitOfWorkMock.Setup(u => u.SaveChangesAsync()).ReturnsAsync(1);

            // Act
            var result = await _sut.AddBookAsync(dto, httpContextMock.Object);

            // Assert
            result.IsSuccess.Should().BeTrue();
            _bookRepositoryMock.Verify(r => r.AddAsync(It.Is<Book>(b => b.Title == "New Book")), Times.Once);
            _unitOfWorkMock.Verify(u => u.SaveChangesAsync(), Times.Once);
        }

        [Fact]
        public async Task UpdateBookAsync_ShouldUpdateAndReturnSuccess()
        {
            // Arrange
            var dto = new UpdateBookDto { Id = 1, Title = "Updated Title", Description = "Updated Desc" };
            var existingBook = CreateBook(1, "Old Title");
            var httpContextMock = new Mock<HttpContext>();

            _bookRepositoryMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(existingBook);
            _unitOfWorkMock.Setup(u => u.SaveChangesAsync()).ReturnsAsync(1);

            // Act
            var result = await _sut.UpdateBookAsync(dto, httpContextMock.Object);

            // Assert
            result.IsSuccess.Should().BeTrue();
            existingBook.Title.Should().Be("Updated Title");
            _bookRepositoryMock.Verify(r => r.Update(existingBook), Times.Once);
            _unitOfWorkMock.Verify(u => u.SaveChangesAsync(), Times.Once);
        }

        [Fact]
        public async Task DeleteBookAsync_ShouldDeleteAndReturnSuccess()
        {
            // Arrange
            var existingBook = CreateBook(1, "Book to Delete");
            _bookRepositoryMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(existingBook);
            _bookRepositoryMock.Setup(r => r.DeleteAsync(existingBook, "123")).Returns(Task.CompletedTask);

            // Act
            var result = await _sut.DeleteBookAsync(1);

            // Assert
            result.IsSuccess.Should().BeTrue();
            _bookRepositoryMock.Verify(r => r.DeleteAsync(existingBook, "123"), Times.Once);
        }

        [Fact]
        public async Task ActivateOrDeactivateBookAsync_ShouldToggleStatus()
        {
            // Arrange
            var existingBook = CreateBook(1, "Book");
            existingBook.IsActive = true;
            _bookRepositoryMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(existingBook);
            _unitOfWorkMock.Setup(u => u.SaveChangesAsync()).ReturnsAsync(1);

            // Act
            var result = await _sut.ActivateOrDeactivateBookAsync(1);

            // Assert
            result.IsSuccess.Should().BeTrue();
            existingBook.IsActive.Should().BeFalse();
            _bookRepositoryMock.Verify(r => r.Update(existingBook), Times.Once);
            _unitOfWorkMock.Verify(u => u.SaveChangesAsync(), Times.Once);
        }
    }
}
