using FluentAssertions;
using LMS.Domain.Enums;
using LMS.Application.Services;
using LMS.Domain.Entities;

using LMS.Domain.Interfaces.Repositories;
using Moq;
using System.Linq.Expressions;


namespace LMS.Tests.Application.Services
{
    public class DashboardServiceTests
    {
        private readonly Mock<ITransactionRepository> _transactionRepositoryMock;
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly DashboardService _dashboardService;

        public DashboardServiceTests()
        {
            _transactionRepositoryMock = new Mock<ITransactionRepository>();
            _userRepositoryMock = new Mock<IUserRepository>();
            _dashboardService = new DashboardService(_transactionRepositoryMock.Object, _userRepositoryMock.Object);
        }

        [Fact]
        public async Task GetDashboardAsync_ShouldReturnDashboardDto_WithCorrectData()
        {
            // Arrange
            int count = 5;

            _transactionRepositoryMock.Setup(repo => repo.GetTopBorrowedBookNamesAsync(count))
                .ReturnsAsync(new List<KeyValuePair<string, int>> { new KeyValuePair<string, int>("Book1", 10) });

            _transactionRepositoryMock.Setup(repo => repo.GetTopBorrowedAuthorNamesAsync(count))
                .ReturnsAsync(new List<KeyValuePair<string, int>> { new KeyValuePair<string, int>("Author1", 5) });

            _transactionRepositoryMock.Setup(repo => repo.GetTopBorrowedCategoryNamesAsync(count))
                .ReturnsAsync(new List<KeyValuePair<string, int>> { new KeyValuePair<string, int>("Category1", 8) });

            _transactionRepositoryMock.Setup(repo => repo.GetTopBorrowingUserNamesAsync(count))
                .ReturnsAsync(new List<KeyValuePair<string, int>> { new KeyValuePair<string, int>("User1", 12) });

            // Setup specific counts for each status
            _transactionRepositoryMock.Setup(repo => repo.GetTransactionCountByStatusAsync(It.Is<string?>(s => s == null)))
                .ReturnsAsync(100);
            _transactionRepositoryMock.Setup(repo => repo.GetTransactionCountByStatusAsync(TransactionStatus.Returned.ToString()))
                .ReturnsAsync(80);
            _transactionRepositoryMock.Setup(repo => repo.GetTransactionCountByStatusAsync(TransactionStatus.Overdue.ToString()))
                .ReturnsAsync(5);

            _userRepositoryMock.Setup(repo => repo.CountAsync(It.IsAny<Expression<Func<User, bool>>>()))
                .ReturnsAsync(50);

            // Act
            var result = await _dashboardService.GetDashboardAsync(count);

            // Assert
            result.Should().NotBeNull();
            result.TransactionCount.Should().Be(100);
            result.ReturnedCount.Should().Be(80);
            result.OverdueCount.Should().Be(5);
            result.MembersCount.Should().Be(50);

            result.TopBooks.Should().HaveCount(1);
            result.TopBooks.First().Text.Should().Be("Book1");
            result.TopBooks.First().Value.Should().Be(10);

            result.TopAuthers.Should().HaveCount(1);
            result.TopAuthers.First().Text.Should().Be("Author1");
            result.TopAuthers.First().Value.Should().Be(5);

            result.TopCategories.Should().HaveCount(1);
            result.TopCategories.First().Text.Should().Be("Category1");

            result.TopUsers.Should().HaveCount(1);
            result.TopUsers.First().Text.Should().Be("User1");
        }
    }
}
