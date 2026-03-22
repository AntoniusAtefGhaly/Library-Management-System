using System.Collections.Generic;
using FluentAssertions;
using LMS.Domain.ValueObjects;
using Xunit;

namespace LMS.Tests.Domain.ValueObjects
{
    public class AddressTests
    {
        [Fact]
        public void Equality_SameValues_ShouldBeEqual()
        {
            // Arrange
            var addr1 = new Address("123 St", "City", "State", "12345");
            var addr2 = new Address("123 St", "City", "State", "12345");

            // Assert
            addr1.Should().Be(addr2);
        }

        [Fact]
        public void Equality_DifferentValues_ShouldNotBeEqual()
        {
            // Arrange
            var addr1 = new Address("123 St", "City", "State", "12345");
            var addr2 = new Address("456 St", "City", "State", "12345");

            // Assert
            addr1.Should().NotBe(addr2);
        }

        [Fact]
        public void ToString_ShouldReturnFormattedAddress()
        {
            // Arrange
            var addr = new Address("123 St", "City", "State", "12345");

            // Assert
            addr.ToString().Should().Be("123 St, City, State 12345");
        }
    }
}
