using LMS.Domain.Common;
using System.Text.RegularExpressions;

namespace LMS.Domain.ValueObjects
{
    public class ISBN : ValueObject
    {
        public string Value { get; }

        public ISBN(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("ISBN cannot be empty.", nameof(value));

            // Basic Sanitization: Remove hyphens and spaces
            var sanitizedValue = value.Replace("-", "").Replace(" ", "");

            if (!IsValidISBN(sanitizedValue))
                throw new ArgumentException($"Invalid ISBN format: {value}", nameof(value));

            Value = sanitizedValue;
        }

        private static bool IsValidISBN(string isbn)
        {
            // Simple check for 10 or 13 digits (optionally with 'X' at the end for ISBN-10)
            return Regex.IsMatch(isbn, @"^(?=(?:\D*\d){10}(?:(?:\D*\d){3})?$)[\d-]+X?$");
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public override string ToString() => Value;
    }
}
