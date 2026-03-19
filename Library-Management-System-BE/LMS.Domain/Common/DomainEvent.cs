using System;

namespace LMS.Domain.Common
{
    public interface IDomainEvent
    {
        DateTime OccurredOn { get; }
    }

    public abstract class DomainEvent : IDomainEvent
    {
        public DateTime OccurredOn { get; } = DateTime.UtcNow;
    }
}
