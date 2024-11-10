using MediatR;

namespace Ordering.Domain.Abstractions
{
    public interface IDomainEvent : INotification
    {
        Guid EventId => Guid.NewGuid();
        public DateTime OccuredOn => DateTime.Now;

        //pengidentifikasi jenis peristiwa 
        public string EventType => GetType().AssemblyQualifiedName;
    }
}
