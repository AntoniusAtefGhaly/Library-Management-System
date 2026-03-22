using System;
using FluentAssertions;
using LMS.Domain.Entities;
using Xunit;

namespace LMS.Tests.Domain.Entities
{
    public class TransactionTests
    {
        [Fact]
        public void Status_ShouldReturnOverdue_WhenIssued_AndDueDatePassed_AndNotReturned()
        {
            // Arrange
            var transaction = new Transaction();
            transaction.Status = "Issued";
            transaction.IssueDate = DateTime.Now.AddDays(-14);
            transaction.DueDate = DateTime.Now.AddDays(-1); // Yesterday
            transaction.ReturnDate = null;

            // Act & Assert
            transaction.Status.Should().Be("Overdue");
        }

        [Fact]
        public void Status_ShouldReturnIssued_WhenNotPassedDueDate()
        {
            // Arrange
            var transaction = new Transaction();
            transaction.Status = "Issued";
            transaction.IssueDate = DateTime.Now.AddDays(-7);
            transaction.DueDate = DateTime.Now.AddDays(7); // Next week
            transaction.ReturnDate = null;

            // Act & Assert
            transaction.Status.Should().Be("Issued");
        }

        [Fact]
        public void Status_ShouldReturnReturned_WhenBookReturned_EvenIfDueDatePassed()
        {
            // Arrange
            var transaction = new Transaction();
            transaction.Status = "Returned";
            transaction.IssueDate = DateTime.Now.AddDays(-14);
            transaction.DueDate = DateTime.Now.AddDays(-7);
            transaction.ReturnDate = DateTime.Now.AddDays(-7);

            // Act & Assert
            transaction.Status.Should().Be("Returned");
        }

        [Fact]
        public void Status_Set_ShouldThrowArgumentException_WhenInvalidStatusProvided()
        {
            // Arrange
            var transaction = new Transaction();

            // Act & Assert
            Action act = () => transaction.Status = "SomethingInvalid";
            act.Should().Throw<ArgumentException>();
        }
    }
}
