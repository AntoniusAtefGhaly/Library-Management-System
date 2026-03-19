using LMS.Domain.Common;

namespace LMS.Domain.ValueObjects
{
    public class Address : ValueObject
    {
        public string? Street { get; }
        public string? City { get; }
        public string? State { get; }
        public string? ZipCode { get; }

        public Address(string? street, string? city, string? state, string? zipCode)
        {
            Street = street;
            City = city;
            State = state;
            ZipCode = zipCode;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Street ?? string.Empty;
            yield return City ?? string.Empty;
            yield return State ?? string.Empty;
            yield return ZipCode ?? string.Empty;
        }

        public override string ToString() => $"{Street}, {City}, {State} {ZipCode}";
    }
}
