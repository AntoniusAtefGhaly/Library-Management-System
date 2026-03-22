using System;
using System.Threading.Tasks;
using FluentAssertions;
using LMS.Application;
using LMS.Application.Services;
using Microsoft.Extensions.Configuration;
using Moq;
using Xunit;

namespace LMS.Tests.Application.Services
{
    public class OverdueNotificationServiceTests
    {
        private readonly Mock<ITransactionService> _transactionServiceMock;
        private readonly Mock<IConfiguration> _configurationMock;
        private readonly OverdueNotificationService _sut; // System Under Test

        public OverdueNotificationServiceTests()
        {
            _transactionServiceMock = new Mock<ITransactionService>();
            _configurationMock = new Mock<IConfiguration>();
            _sut = new OverdueNotificationService(_transactionServiceMock.Object, _configurationMock.Object);
        }

        [Fact]
        public async Task ProcessOverdueNotifications_ShouldCallSendOverdueNotificationsAsync_ExactlyOnce()
        {
            // Arrange
            _transactionServiceMock.Setup(service => service.SendOverdueNotificationsAsync())
                .ReturnsAsync(5); // Sent 5 notifications

            // Act
            await _sut.ProcessOverdueNotifications();

            // Assert
            _transactionServiceMock.Verify(service => service.SendOverdueNotificationsAsync(), Times.Once);
        }

        [Fact]
        public async Task ProcessOverdueNotifications_ShouldNotThrowException_WhenTransactionServiceThrows()
        {
            // Arrange
            _transactionServiceMock.Setup(service => service.SendOverdueNotificationsAsync())
                .ThrowsAsync(new Exception("Database connection failed"));

            // Act
            Func<Task> act = async () => await _sut.ProcessOverdueNotifications();

            // Assert
            await act.Should().NotThrowAsync<Exception>();
            _transactionServiceMock.Verify(service => service.SendOverdueNotificationsAsync(), Times.Once);
        }
    }
}
