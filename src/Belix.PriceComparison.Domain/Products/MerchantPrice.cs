using Belix.PriceComparison.Domain.Merchants;
using Belix.PriceComparison.Domain.Shared.Primitives;

namespace Belix.PriceComparison.Domain.Products;

public class MerchantPrice : Entity
{
    public Guid MerchantId { get; private set; }
    
    public double Price { get; private set; }
    
    private MerchantPrice(Merchant merchant, double price) 
        : base(Guid.NewGuid())
    {
        MerchantId = merchant.Id;
        Price = price;
    }

    public static MerchantPrice Create(Merchant merchant, double price)
    {
        return new MerchantPrice(merchant, price);
    }
    
    public void UpdatePrice(double price)
    {
        Price = price;
    }
}