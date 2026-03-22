using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using LMS.Application;
using LMS.Application.Dtos;
using LMS.Application.Dtos.Category;
using LMS.Application.Shared.Models;
using LMS.Domain.Entities;
using LMS.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Http;
using Moq;
using Xunit;

namespace LMS.Tests.Application.Services
{
    public class CategoryServiceTests
    {
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly Mock<ICategoryRepository> _categoryRepositoryMock;
        private readonly Mock<IHelperService> _helperServiceMock;
        private readonly Mock<ICurrentUserService> _currentUserServiceMock;
        private readonly Mock<IReportService> _reportServiceMock;
        private readonly CategoryService _sut;

        public CategoryServiceTests()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _categoryRepositoryMock = new Mock<ICategoryRepository>();
            _helperServiceMock = new Mock<IHelperService>();
            _currentUserServiceMock = new Mock<ICurrentUserService>();
            _reportServiceMock = new Mock<IReportService>();

            _unitOfWorkMock.Setup(u => u.CategoryRepository).Returns(_categoryRepositoryMock.Object);
            _currentUserServiceMock.Setup(c => c.UserId).Returns("user123");

            _sut = new CategoryService(
                _unitOfWorkMock.Object,
                _helperServiceMock.Object,
                _currentUserServiceMock.Object,
                _reportServiceMock.Object);
        }

        private Category CreateCategory(int id, string name)
        {
            var category = new Category { Name = name, Description = "Desc" };
            var property = typeof(LMS.Domain.Common.AggregateRoot<int>).GetProperty("Id") ?? typeof(Category).GetProperty("Id");
            property?.SetValue(category, id);
            return category;
        }

        [Fact]
        public async Task GetAllCategoriesAsync_Paged_ShouldReturnApiPagedResult()
        {
            // Arrange
            var param = new CategoryParams { pageNumber = 1, pageSize = 10, Search = "", isActive = true };
            var categories = new List<Category> { CreateCategory(1, "Cat1"), CreateCategory(2, "Cat2") };
            var pagedResult = new pagedResult<Category> { TotalCount = 2, Result = categories };
            
            _categoryRepositoryMock.Setup(r => r.GetAllCategoriesAsync(param.pageNumber, param.pageSize, param.sortOrder, param.sortField, param.Search, param.isActive))
                .ReturnsAsync(pagedResult);

            // Act
            var result = await _sut.GetAllCategoriesAsync(param);

            // Assert
            result.IsSuccess.Should().BeTrue();
            result.TotalCount.Should().Be(2);
            result.Data.Should().HaveCount(2);
        }

        [Fact]
        public async Task GetAllCategoriesAsync_ShouldReturnApiResultWithDtoList()
        {
            // Arrange
            var categories = new List<Category> { CreateCategory(1, "Cat1") };
            categories[0].Books = new List<Book> { new Book() }; // Ensure books collection is not null
            _categoryRepositoryMock.Setup(r => r.GetAllCategoriesWithBooks()).ReturnsAsync(categories);

            // Act
            var result = await _sut.GetAllCategoriesAsync();

            // Assert
            result.IsSuccess.Should().BeTrue();
            result.Data.Should().HaveCount(1);
            result.Data!.First().Name.Should().Be("Cat1");
            result.Data!.First().BooksCount.Should().Be(1);
        }

        [Fact]
        public async Task GetCategoryByIdAsync_ShouldReturnSuccess_WhenExists()
        {
            // Arrange
            var category = CreateCategory(1, "Cat1");
            _categoryRepositoryMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(category);

            // Act
            var result = await _sut.GetCategoryByIdAsync(1);

            // Assert
            result.IsSuccess.Should().BeTrue();
            var data = result.Data as GetCategoryDto;
            data.Should().NotBeNull();
            data!.Name.Should().Be("Cat1");
        }

        [Fact]
        public async Task GetCategoryByIdAsync_ShouldReturnFailure_WhenNotExists()
        {
            // Arrange
            _categoryRepositoryMock.Setup(r => r.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((Category?)null);

            // Act
            var result = await _sut.GetCategoryByIdAsync(99);

            // Assert
            result.IsSuccess.Should().BeFalse();
            result.Message.Should().Be("Category not found");
        }

        [Fact]
        public async Task AddCategoryAsync_ShouldCreateAndReturnSuccess()
        {
            // Arrange
            var dto = new AddCategoryDto { Name = "New Cat", Description = "New Desc", ImageUrl = null };
            var httpContextMock = new Mock<HttpContext>();
            _unitOfWorkMock.Setup(u => u.SaveChangesAsync()).ReturnsAsync(1);

            // Act
            var result = await _sut.AddCategoryAsync(dto, httpContextMock.Object);

            // Assert
            result.IsSuccess.Should().BeTrue();
            _categoryRepositoryMock.Verify(r => r.AddAsync(It.Is<Category>(c => c.Name == "New Cat")), Times.Once);
            _unitOfWorkMock.Verify(u => u.SaveChangesAsync(), Times.Once);
        }

        [Fact]
        public async Task UpdateCategoryAsync_ShouldUpdateAndReturnSuccess()
        {
            // Arrange
            var dto = new UpdateCategoryDto { Id = 1, Name = "Updated Cat", Description = "Updated Desc", ImageUrl = null };
            var existingCategory = CreateCategory(1, "Old Cat");
            var httpContextMock = new Mock<HttpContext>();
            
            _categoryRepositoryMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(existingCategory);
            _unitOfWorkMock.Setup(u => u.SaveChangesAsync()).ReturnsAsync(1);

            // Act
            var result = await _sut.UpdateCategoryAsync(dto, httpContextMock.Object);

            // Assert
            result.IsSuccess.Should().BeTrue();
            existingCategory.Name.Should().Be("Updated Cat");
            _categoryRepositoryMock.Verify(r => r.Update(existingCategory), Times.Once);
            _unitOfWorkMock.Verify(u => u.SaveChangesAsync(), Times.Once);
        }

        [Fact]
        public async Task DeleteCategoryAsync_ShouldDeleteAndReturnSuccess()
        {
            // Arrange
            var existingCategory = CreateCategory(1, "Old Cat");
            _categoryRepositoryMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(existingCategory);
            _categoryRepositoryMock.Setup(r => r.DeleteAsync(existingCategory, "user123")).Returns(Task.CompletedTask);

            // Act
            var result = await _sut.DeleteCategoryAsync(1);

            // Assert
            result.IsSuccess.Should().BeTrue();
            _categoryRepositoryMock.Verify(r => r.DeleteAsync(existingCategory, "user123"), Times.Once);
        }

        [Fact]
        public async Task ActivateOrDeactivateCategoryAsync_ShouldToggleStatus()
        {
            // Arrange
            var existingCategory = CreateCategory(1, "Old Cat");
            existingCategory.IsActive = true;
            _categoryRepositoryMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(existingCategory);
            _unitOfWorkMock.Setup(u => u.SaveChangesAsync()).ReturnsAsync(1);

            // Act
            var result = await _sut.ActivateOrDeactivateCategoryAsync(1);

            // Assert
            result.IsSuccess.Should().BeTrue();
            existingCategory.IsActive.Should().BeFalse();
            _categoryRepositoryMock.Verify(r => r.Update(existingCategory), Times.Once);
            _unitOfWorkMock.Verify(u => u.SaveChangesAsync(), Times.Once);
        }
    }
}
