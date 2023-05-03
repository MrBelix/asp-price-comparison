using Belix.PriceComparison.Domain.Shared.Primitives;

namespace Belix.PriceComparison.Domain.Brands;

public class Brand : AggregateRoot
{
    public string Name { get; private set; }

    private Brand(string name) : 
        base(Guid.NewGuid())
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentNullException(nameof(name));
        }
        
        Name = name;
    }
    
    public static Brand Create(string name)
    {
        return new Brand(name);
    }
}