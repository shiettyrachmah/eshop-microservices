namespace Ordering.API.Abstractions
{
    // Class IAggregate adalah jenis entitas khusus yang dapat menangani peristiwa domain

    public interface IAggregate<T>:IAggregate, IEntity<T>
    {

    }
    public interface IAggregate : IEntity
    {
        IReadOnlyList<IDomainEvent> DomainEvents { get; }
        IDomainEvent[] ClearDomainEvents();
    }
}
