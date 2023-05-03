using Belix.PriceComparison.Domain.Shared.Primitives;

namespace Belix.PriceComparison.Domain.Merchants;

public class Merchant : AggregateRoot
{
    public string Name { get; private set; }
    
    private Merchant(string name) 
        : base(Guid.NewGuid())
    {
        Name = name;
    }
    
    public static Merchant Create(string name)
    {
        return new Merchant(name);
    }
}