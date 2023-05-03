using Belix.PriceComparison.Domain.Brands;
using Belix.PriceComparison.Domain.Categories;
using Belix.PriceComparison.Domain.Merchants;
using Belix.PriceComparison.Domain.Shared.Primitives;

namespace Belix.PriceComparison.Domain.Products;

public class Product : AggregateRoot
{
    private readonly List<MerchantPrice> _merchantPrices;

    public IReadOnlyCollection<MerchantPrice> Prices => _merchantPrices.AsReadOnly();
    public string Name { get; private set; }
    
    public string Description { get; private set; }
    
    public Guid BrandId { get; private set; }
    
    public Guid CategoryId { get; private set; }

    public double MaxPrice => _merchantPrices.Count > 0? _merchantPrices.Max(x => x.Price) : 0;

    public double MinPrice => _merchantPrices.Count > 0? _merchantPrices.Min(x => x.Price) : 0;
    
    private Product(string name, string description, Brand brand, Category category) 
        : base(Guid.NewGuid())
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentNullException(nameof(name));
        }
        
        if (string.IsNullOrWhiteSpace(description))
        {
            throw new ArgumentNullException(nameof(description));
        }

        if (brand is null)
        {
            throw new ArgumentNullException(nameof(brand));
        }

        if (category is null)
        {
            throw new ArgumentNullException(nameof(category));
        }

        Name = name;
        Description = description;
        BrandId = brand.Id;
        CategoryId = category.Id;
        _merchantPrices = new List<MerchantPrice>();
    }
    
    public static Product Create(string name, string description, Brand brand, Category category)
    {
        return new Product(name, description, brand, category);
    }

    public void CreateOrUpdatePrice(Merchant merchant, double price)
    {
        var merchantPrice = _merchantPrices.FirstOrDefault(x => x.MerchantId == merchant.Id);
        
        if (merchantPrice is null)
        {
            _merchantPrices.Add(MerchantPrice.Create(merchant, price));
        }
        else
        {
           merchantPrice.UpdatePrice(price);
        }
    }
    
    public MerchantPrice? GetMerchantPrice(Merchant merchant)
    {
        return _merchantPrices.FirstOrDefault(x => x.MerchantId == merchant.Id);
    }
}