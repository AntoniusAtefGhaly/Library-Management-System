using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using FluentAssertions;
using LMS.Application;
using LMS.Application.Dtos;
using LMS.Application.Dtos.User;
using LMS.Application.Shared.Models;
using LMS.Domain.Entities;
using LMS.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Moq;
using Xunit;

namespace LMS.Tests.Application.Services
{
    public class UserServiceTests
    {
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly Mock<IEncryptionService> _encryptionServiceMock;
        private readonly Mock<IConfiguration> _configurationMock;
        private readonly Mock<UserManager<User>> _userManagerMock;
        private readonly Mock<IHelperService> _helperServiceMock;
        private readonly Mock<IReportService> _reportServiceMock;
        private readonly UserService _sut;

        public UserServiceTests()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _userRepositoryMock = new Mock<IUserRepository>();
            _encryptionServiceMock = new Mock<IEncryptionService>();
            _configurationMock = new Mock<IConfiguration>();
            _helperServiceMock = new Mock<IHelperService>();
            _reportServiceMock = new Mock<IReportService>();

            // Mock UserManager
            var store = new Mock<IUserStore<User>>();
            _userManagerMock = new Mock<UserManager<User>>(store.Object, null, null, null, null, null, null, null, null);

            _unitOfWorkMock.Setup(u => u.UserRepository).Returns(_userRepositoryMock.Object);

            _sut = new UserService(
                _unitOfWorkMock.Object,
                _encryptionServiceMock.Object,
                _configurationMock.Object,
                _userManagerMock.Object,
                _helperServiceMock.Object,
                _reportServiceMock.Object
            );
        }

        [Fact]
        public async Task RegisterUserAsync_ShouldReturnSuccess_WhenValidData()
        {
            // Arrange
            var registerDto = new UserRegisterDto
            {
                Email = "test@example.com",
                Password = "Password123!",
                FirstName = "John",
                LastName = "Doe",
                PhoneNumber = "1234567890"
            };

            _userManagerMock.Setup(m => m.CreateAsync(It.IsAny<User>(), It.IsAny<string>()))
                .ReturnsAsync(IdentityResult.Success);
            _userManagerMock.Setup(m => m.AddClaimsAsync(It.IsAny<User>(), It.IsAny<IEnumerable<Claim>>()))
                .ReturnsAsync(IdentityResult.Success);
            _unitOfWorkMock.Setup(u => u.SaveChangesAsync()).ReturnsAsync(1);

            // Act
            var result = await _sut.RegisterUserAsync(registerDto);

            // Assert
            result.IsSuccess.Should().BeTrue();
            result.Message.Should().Be("Register Successfully");
            _userManagerMock.Verify(m => m.CreateAsync(It.IsAny<User>(), registerDto.Password), Times.Once);
        }

        [Fact]
        public async Task LoginAsync_ShouldReturnToken_WhenCredentialsAreValid()
        {
            // Arrange
            var loginDto = new UserLoginDto { Email = "test@example.com", Password = "Password123!" };
            var user = new User { Email = "test@example.com", IsActive = true, FirstName = "John", LastName = "Doe" };
            var claims = new List<Claim> { new Claim(ClaimTypes.NameIdentifier, "1") };

            _userManagerMock.Setup(m => m.FindByEmailAsync(loginDto.Email)).ReturnsAsync(user);
            _userManagerMock.Setup(m => m.CheckPasswordAsync(user, loginDto.Password)).ReturnsAsync(true);
            _userManagerMock.Setup(m => m.GetClaimsAsync(user)).ReturnsAsync(claims);
            
            _configurationMock.Setup(c => c.GetSection("SecretKey").Value).Returns("super_secret_key_at_least_32_chars_long");

            // Act
            var result = await _sut.LoginAsync(loginDto);

            // Assert
            result.IsSuccess.Should().BeTrue();
            result.Data.Should().BeOfType<TokenDto>();
            var tokenDto = (TokenDto)result.Data!;
            tokenDto.Email.Should().Be(user.Email);
            tokenDto.Token.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public async Task LoginAsync_ShouldFail_WhenUserIsNotActive()
        {
            // Arrange
            var loginDto = new UserLoginDto { Email = "inactive@example.com", Password = "Password123!" };
            var user = new User { Email = "inactive@example.com", IsActive = false };

            _userManagerMock.Setup(m => m.FindByEmailAsync(loginDto.Email)).ReturnsAsync(user);

            // Act
            var result = await _sut.LoginAsync(loginDto);

            // Assert
            result.IsSuccess.Should().BeFalse();
            result.Message.Should().Be("User Not Active");
        }

        [Fact]
        public async Task GetAllUsersAsync_ShouldReturnUsersFromRepo()
        {
            // Arrange
            var users = new List<User>
            {
                new User { FirstName = "User1", LastName = "Last1", Email = "u1@e.com", IsActive = true },
                new User { FirstName = "User2", LastName = "Last2", Email = "u2@e.com", IsActive = true }
            };
            _userRepositoryMock.Setup(r => r.GetAllAsync()).ReturnsAsync(users);

            // Act
            var result = await _sut.GetAllUsersAsync();

            // Assert
            result.IsSuccess.Should().BeTrue();
            var data = (List<GetUserDto>)result.Data!;
            data.Should().HaveCount(2);
        }
    }
}
