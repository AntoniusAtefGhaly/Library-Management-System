using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using LMS.Application;
using LMS.Application.Shared.Models;
using LMS.Domain.Entities;
using LMS.Domain.Interfaces.Repositories;
using Moq;
using Xunit;

namespace LMS.Tests.Application.Services
{
    public class FeedbackServiceTests
    {
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly Mock<IFeedbackRepository> _feedbackRepositoryMock;
        private readonly Mock<ITransactionRepository> _transactionRepositoryMock;
        private readonly Mock<ICurrentUserService> _currentUserServiceMock;
        private readonly FeedbackService _sut;

        public FeedbackServiceTests()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _feedbackRepositoryMock = new Mock<IFeedbackRepository>();
            _transactionRepositoryMock = new Mock<ITransactionRepository>();
            _currentUserServiceMock = new Mock<ICurrentUserService>();

            _unitOfWorkMock.Setup(u => u.FeedbackRepository).Returns(_feedbackRepositoryMock.Object);
            _unitOfWorkMock.Setup(u => u.TransactionRepository).Returns(_transactionRepositoryMock.Object);

            _sut = new FeedbackService(_unitOfWorkMock.Object, _currentUserServiceMock.Object);
        }

        private Feedback CreateFeedback(int id, int userId, int bookId)
        {
            var feedback = new Feedback
            {
                Id = id,
                UserId = userId,
                BookId = bookId,
                Rating = 5,
                Comment = "Great book!"
            };
            return feedback;
        }

        [Fact]
        public async Task GetAllFeedbacksAsync_ShouldReturnAllFeedbacks()
        {
            // Arrange
            var feedbacks = new List<Feedback> { CreateFeedback(1, 101, 201) };
            _feedbackRepositoryMock.Setup(r => r.GetAllAsync()).ReturnsAsync(feedbacks);

            // Act
            var result = await _sut.GetAllFeedbacksAsync();

            // Assert
            result.IsSuccess.Should().BeTrue();
            result.Data.Should().BeEquivalentTo(feedbacks.Select(f => new GetFeedbackDto
            {
                Id = f.Id,
                UserId = f.UserId,
                BookId = f.BookId,
                Rating = f.Rating,
                Comment = f.Comment
            }));
        }

        [Fact]
        public async Task AddFeedback_ShouldSucceed_WhenUserHasBorrowedAndNotReviewed()
        {
            // Arrange
            _currentUserServiceMock.Setup(c => c.UserId).Returns("101");
            var request = new AddFeedbackDto { BookId = 201, Rating = 5, Comment = "Loved it" };
            
            _transactionRepositoryMock.Setup(r => r.HasUserBorrowedBookAsync(101, 201)).ReturnsAsync(true);
            _feedbackRepositoryMock.Setup(r => r.GetAllAsync()).ReturnsAsync(new List<Feedback>());
            _unitOfWorkMock.Setup(u => u.SaveChangesAsync()).ReturnsAsync(1);

            // Act
            var result = await _sut.AddFeedbackAsync(request);

            // Assert
            result.IsSuccess.Should().BeTrue();
            result.Message.Should().Be("Feedback created successfully");
            _feedbackRepositoryMock.Verify(r => r.AddAsync(It.IsAny<Feedback>()), Times.Once);
            _unitOfWorkMock.Verify(u => u.SaveChangesAsync(), Times.Once);
        }

        [Fact]
        public async Task AddFeedback_ShouldFail_WhenUserHasNotBorrowed()
        {
            // Arrange
            _currentUserServiceMock.Setup(c => c.UserId).Returns("101");
            var request = new AddFeedbackDto { BookId = 201, Rating = 5, Comment = "Loved it" };
            
            _transactionRepositoryMock.Setup(r => r.HasUserBorrowedBookAsync(101, 201)).ReturnsAsync(false);

            // Act
            var result = await _sut.AddFeedbackAsync(request);

            // Assert
            result.IsSuccess.Should().BeFalse();
            result.Message.Should().Be("You can only review books that you have borrowed and returned");
        }

        [Fact]
        public async Task AddFeedback_ShouldFail_WhenUserHasAlreadyReviewed()
        {
            // Arrange
            _currentUserServiceMock.Setup(c => c.UserId).Returns("101");
            var request = new AddFeedbackDto { BookId = 201, Rating = 5, Comment = "Loved it" };
            
            _transactionRepositoryMock.Setup(r => r.HasUserBorrowedBookAsync(101, 201)).ReturnsAsync(true);
            var existingFeedback = CreateFeedback(1, 101, 201);
            _feedbackRepositoryMock.Setup(r => r.GetAllAsync()).ReturnsAsync(new List<Feedback> { existingFeedback });

            // Act
            var result = await _sut.AddFeedbackAsync(request);

            // Assert
            result.IsSuccess.Should().BeFalse();
            result.Message.Should().Be("You have already reviewed this book");
        }
    }
}
