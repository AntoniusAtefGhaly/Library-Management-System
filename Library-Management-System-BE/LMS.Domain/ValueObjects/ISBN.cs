using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using LMS.Domain.Common;

namespace LMS.Domain.ValueObjects
{
    public class ISBN : ValueObject
    {
        public string Value { get; }

        private ISBN(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("ISBN cannot be empty", nameof(value));

            // Basic ISBN-10 or ISBN-13 regex validation
            if (!Regex.IsMatch(value, @"^(?=(?:\D*\d){10}(?:(?:\D*\d){3})?$)[\d-]+$"))
                throw new ArgumentException("Invalid ISBN format", nameof(value));

            Value = value;
        }

        public static ISBN Create(string value) => new(value);

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public override string ToString() => Value;
    }
}
