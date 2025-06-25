namespace Bookify.Domain.Abstractions;

public abstract class Entity<TModel>     
    where TModel : class
{
    protected Entity(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; init; }
}
