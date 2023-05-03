using Belix.PriceComparison.Domain.Merchants;
using Belix.PriceComparison.Domain.Products;

namespace Belix.PriceComparison.Domain.Tests;

[TestFixture]
public class MerchantPriceTests
{
    private Merchant _merchant;
    private double _price;

    [SetUp]
    public void SetUp()
    {
        _merchant = Merchant.Create("Test Merchant");
        _price = 9.99d;
    }

    [Test]
    public void Create_ShouldSetMerchantIdAndPrice()
    {
        // Arrange
        // Act
        var merchantPrice = MerchantPrice.Create(_merchant, _price);

        // Assert
        Assert.That(merchantPrice.MerchantId, Is.EqualTo(_merchant.Id));
        Assert.That(merchantPrice.Price, Is.EqualTo(_price));
    }

    [Test]
    public void UpdatePrice_ShouldUpdatePrice()
    {
        // Arrange
        var merchantPrice = MerchantPrice.Create(_merchant, _price);
        var newPrice = 19.99d;

        // Act
        merchantPrice.UpdatePrice(newPrice);

        // Assert
        Assert.That(merchantPrice.Price, Is.EqualTo(newPrice));
    }
}