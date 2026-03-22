using System.Collections.Generic;
using System.Security.Claims;
using FluentAssertions;
using LMS.Application;
using Microsoft.AspNetCore.Http;
using Moq;
using Xunit;

namespace LMS.Tests.Application.Services
{
    public class CurrentUserServiceTests
    {
        private readonly Mock<IHttpContextAccessor> _httpContextAccessorMock;

        public CurrentUserServiceTests()
        {
            _httpContextAccessorMock = new Mock<IHttpContextAccessor>();
        }

        [Fact]
        public void UserId_ShouldReturnNameIdentifier_WhenContextIsAvailable()
        {
            // Arrange
            var claims = new List<Claim> { new Claim(ClaimTypes.NameIdentifier, "123") };
            var identity = new ClaimsIdentity(claims, "TestAuth");
            var user = new ClaimsPrincipal(identity);
            var httpContext = new DefaultHttpContext { User = user };
            
            _httpContextAccessorMock.Setup(h => h.HttpContext).Returns(httpContext);

            // Act
            var sut = new CurrentUserService(_httpContextAccessorMock.Object);

            // Assert
            sut.UserId.Should().Be("123");
        }

        [Fact]
        public void UserId_ShouldReturnNull_WhenContextIsNull()
        {
            // Arrange
            _httpContextAccessorMock.Setup(h => h.HttpContext).Returns((HttpContext?)null);

            // Act
            var sut = new CurrentUserService(_httpContextAccessorMock.Object);

            // Assert
            sut.UserId.Should().BeNull();
        }
    }
}
