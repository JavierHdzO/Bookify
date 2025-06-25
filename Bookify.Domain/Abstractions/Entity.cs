namespace Bookify.Domain.Abstractions;

public abstract class Entity<TModel>     
    where TModel : class
{
    protected Entity(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; init; }

    public bool IsTransient() => Object.Equals(Id, default(Guid));

    public override bool Equals(object? obj)
    {
        return obj is Entity<TModel> entity && Equals(entity);
    }

    public bool Equals (Entity<TModel>? other)
    {
        if (other is null || other.IsTransient() || this.IsTransient())
        {
            return false;
        }

        return Object.Equals(Id, other.Id);
    }

    int? _requestedHashCode;
    public override int GetHashCode()
    {
        if(!IsTransient())
        {
            if(!_requestedHashCode.HasValue)
            {
                _requestedHashCode = HashCode.Combine(Id);
            }

            return _requestedHashCode.Value;

        }
        return base.GetHashCode();

    }

    public static bool operator ==(Entity<TModel>? left, Entity<TModel>? right)
    {
        if (left is null && right is null)
        {
            return true;
        }

        if (left is null || right is null)
        {
            return false;
        }

        return left.Equals(right);
    }

    public static bool operator !=(Entity<TModel>? left, Entity<TModel>? right)
    {
        return !(left == right);
    }

}
