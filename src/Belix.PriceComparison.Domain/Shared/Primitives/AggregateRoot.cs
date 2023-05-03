namespace Belix.PriceComparison.Domain.Shared.Primitives;

public abstract class AggregateRoot : Entity
{
    protected AggregateRoot(Guid id) : base(id)
    {
    }
}