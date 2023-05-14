namespace FunBooksAndVideos.Domain.SharedKernel;

public abstract class BaseEntity<TId>
{
    public List<BaseDomainEvent> Events = new List<BaseDomainEvent>();

    public TId Id { get; set; }
}
