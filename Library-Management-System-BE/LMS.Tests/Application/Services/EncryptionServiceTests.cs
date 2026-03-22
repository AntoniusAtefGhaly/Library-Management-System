using FluentAssertions;
using LMS.Application;
using Xunit;

namespace LMS.Tests.Application.Services
{
    public class EncryptionServiceTests
    {
        private readonly EncryptionService _sut;

        public EncryptionServiceTests()
        {
            _sut = new EncryptionService();
        }

        [Fact]
        public void EncryptDecrypt_ShouldReturnOriginalText()
        {
            // Arrange
            var originalText = "Hello World";

            // Act
            var encrypted = _sut.EncryptText(originalText);
            var decrypted = _sut.DecryptText(encrypted);

            // Assert
            decrypted.Should().Be(originalText);
            encrypted.Should().NotBe(originalText);
        }

        [Fact]
        public void EncryptWithKey_ShouldUseCorrectKey()
        {
            // Arrange
            var originalText = "Secret Message";
            var key = "1234567890123456"; // 16 chars

            // Act
            var encrypted = _sut.EncryptText(originalText, key);
            var decrypted = _sut.DecryptText(encrypted, key);

            // Assert
            decrypted.Should().Be(originalText);
        }
    }
}
