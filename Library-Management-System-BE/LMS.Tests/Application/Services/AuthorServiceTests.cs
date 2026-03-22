using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using LMS.Application.Dtos.Author;
using LMS.Application;
using LMS.Application.Managers.Services;
using LMS.Application.Shared.Models;
using LMS.Domain.Entities;
using LMS.Domain.Interfaces;
using LMS.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Http;
using Moq;
using Xunit;

namespace LMS.Tests.Application.Services
{
    public class AuthorServiceTests
    {
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly Mock<IAuthorRepository> _authorRepositoryMock;
        private readonly Mock<IBookRepository> _bookRepositoryMock;
        private readonly Mock<IHelperService> _helperServiceMock;
        private readonly Mock<IReportService> _reportServiceMock;
        private readonly AuthorService _sut;

        public AuthorServiceTests()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _authorRepositoryMock = new Mock<IAuthorRepository>();
            _bookRepositoryMock = new Mock<IBookRepository>();
            _helperServiceMock = new Mock<IHelperService>();
            _reportServiceMock = new Mock<IReportService>();

            _unitOfWorkMock.Setup(uow => uow.AuthorRepository).Returns(_authorRepositoryMock.Object);
            _unitOfWorkMock.Setup(uow => uow.BookRepository).Returns(_bookRepositoryMock.Object);

            _sut = new AuthorService(_unitOfWorkMock.Object, _helperServiceMock.Object, _reportServiceMock.Object);
        }

        private Author CreateAuthor(int id, string name)
        {
            var author = new Author { FullName = name };
            var property = typeof(LMS.Domain.Common.AggregateRoot<int>).GetProperty("Id") ?? typeof(Author).GetProperty("Id");
            property?.SetValue(author, id);
            return author;
        }

        [Fact]
        public async Task GetAllAuthors_ShouldReturnReadAuthorDtos()
        {
            // Arrange
            var authors = new List<Author>
            {
                CreateAuthor(1, "Author One"),
                CreateAuthor(2, "Author Two")
            };
            _authorRepositoryMock.Setup(r => r.GetAllAuthors()).ReturnsAsync(authors);

            // Act
            var result = await _sut.GetAllAuthors();

            // Assert
            result.Should().HaveCount(2);
            result.First().FullName.Should().Be("Author One");
        }

        [Fact]
        public async Task GetAuthorById_ShouldReturnAuthor_WhenExists()
        {
            // Arrange
            var author = CreateAuthor(1, "Existing Author");
            _authorRepositoryMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(author);

            // Act
            var result = await _sut.GetAuthorById(1);

            // Assert
            result.Should().NotBeNull();
            result!.FullName.Should().Be("Existing Author");
        }

        [Fact]
        public async Task GetAuthorById_ShouldReturnNull_WhenNotExists()
        {
            // Arrange
            _authorRepositoryMock.Setup(r => r.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((Author?)null);

            // Act
            var result = await _sut.GetAuthorById(99);

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public async Task DeleteAuthorById_ShouldReturn1_WhenAuthorExists()
        {
            // Arrange
            var author = CreateAuthor(1, "");
            _authorRepositoryMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(author);
            _authorRepositoryMock.Setup(r => r.DeleteAsync(author, "user1")).Returns(Task.CompletedTask);

            // Act
            var result = await _sut.DeleteAuthorById(1, "user1");

            // Assert
            result.Should().Be(1);
            _authorRepositoryMock.Verify(r => r.DeleteAsync(author, "user1"), Times.Once);
        }

        [Fact]
        public async Task ActivateOrDeactivateAuthor_ShouldToggleIsActive()
        {
            // Arrange
            var author = CreateAuthor(1, "");
            author.IsActive = true;
            _authorRepositoryMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(author);
            _unitOfWorkMock.Setup(u => u.SaveChangesAsync()).ReturnsAsync(1);

            // Act
            var result = await _sut.ActivateOrDeactivateAuthor(1);

            // Assert
            result.IsSuccess.Should().BeTrue();
            author.IsActive.Should().BeFalse();
            _authorRepositoryMock.Verify(r => r.Update(author), Times.Once);
            _unitOfWorkMock.Verify(u => u.SaveChangesAsync(), Times.Once);
        }

        [Fact]
        public async Task CreateAuthor_ShouldCreateAndReturnSuccess()
        {
            // Arrange
            var createDto = new CreateAuthorDto { fullName = "New Author", description = "Desc", dateOfBirth = DateOnly.FromDateTime(DateTime.Now) };
            var httpContextMock = new Mock<HttpContext>();
            _unitOfWorkMock.Setup(u => u.SaveChangesAsync()).ReturnsAsync(1);

            // Act
            var result = await _sut.CreateAuthor(createDto, httpContextMock.Object, "user1");

            // Assert
            result.IsSuccess.Should().BeTrue();
            _authorRepositoryMock.Verify(r => r.AddAsync(It.Is<Author>(a => a.FullName == "New Author")), Times.Once);
            _unitOfWorkMock.Verify(u => u.SaveChangesAsync(), Times.Once);
        }
    }
}
