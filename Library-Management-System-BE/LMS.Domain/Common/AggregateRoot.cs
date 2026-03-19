using System.Collections.Generic;

namespace LMS.Domain.Common
{
    public interface IAggregateRoot { }

    public abstract class AggregateRoot<TId> : IAggregateRoot
    {
        public TId Id { get;protected  set; } = default!;

        private readonly List<IDomainEvent> _domainEvents = new();
        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

        public void AddDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }

        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }
    }
}
