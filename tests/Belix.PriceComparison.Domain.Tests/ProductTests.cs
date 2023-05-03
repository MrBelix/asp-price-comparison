using Belix.PriceComparison.Domain.Brands;
using Belix.PriceComparison.Domain.Categories;
using Belix.PriceComparison.Domain.Merchants;
using Belix.PriceComparison.Domain.Products;

namespace Belix.PriceComparison.Domain.Tests;
[TestFixture]
public class ProductTests
{
    private Product _product;
    private Merchant _merchant;

    [SetUp]
    public void SetUp()
    {
        var brand = Brand.Create("MyBrand");
        var category = Category.Create("MyCategory");
        _product = Product.Create("MyProduct", "MyDescription", brand, category);
        _merchant = Merchant.Create("MyMerchant");
    }

    [Test]
    public void CreateOrUpdatePrice_WhenMerchantHasNoPrice_ShouldAddMerchantPrice()
    {
        // Arrange
        var price = 10.0d;

        // Act
        _product.CreateOrUpdatePrice(_merchant, price);

        // Assert
        var merchantPrice = _product.GetMerchantPrice(_merchant);
        Assert.IsNotNull(merchantPrice);
        Assert.AreEqual(price, merchantPrice!.Price);
    }

    [Test]
    public void CreateOrUpdatePrice_WhenMerchantHasPrice_ShouldUpdateMerchantPrice()
    {
        // Arrange
        var price1 = 10.0d;
        var price2 = 15.0d;
        _product.CreateOrUpdatePrice(_merchant, price1);

        // Act
        _product.CreateOrUpdatePrice(_merchant, price2);

        // Assert
        var merchantPrice = _product.GetMerchantPrice(_merchant);
        Assert.IsNotNull(merchantPrice);
        Assert.AreEqual(price2, merchantPrice!.Price);
    }

    [Test]
    public void GetMerchantPrice_WhenMerchantHasNoPrice_ShouldReturnNull()
    {
        // Arrange

        // Act
        var merchantPrice = _product.GetMerchantPrice(_merchant);

        // Assert
        Assert.IsNull(merchantPrice);
    }

    [Test]
    public void MaxPrice_WhenProductHasNoMerchantPrices_ShouldReturnNull()
    {
        // Arrange

        // Act
        var maxPrice = _product.MaxPrice;

        // Assert
        Assert.AreEqual(0d, maxPrice);
    }

    [Test]
    public void MaxPrice_WhenProductHasMerchantPrices_ShouldReturnMaxPrice()
    {
        // Arrange
        var price1 = 10.0d;
        var price2 = 15.0d;
        _product.CreateOrUpdatePrice(_merchant, price1);
        _product.CreateOrUpdatePrice(Merchant.Create("AnotherMerchant"), price2);

        // Act
        var maxPrice = _product.MaxPrice;

        // Assert
        Assert.AreEqual(price2, maxPrice);
    }

    [Test]
    public void MinPrice_WhenProductHasNoMerchantPrices_ShouldReturnNull()
    {
        // Arrange

        // Act
        var minPrice = _product.MinPrice;

        // Assert
        Assert.AreEqual(0d, minPrice);
    }

    [Test]
    public void MinPrice_WhenProductHasMerchantPrices_ShouldReturnMinPrice()
    {
        // Arrange
        var price1 = 10.0d;
        var price2 = 15.0d;
        _product.CreateOrUpdatePrice(_merchant, price1);
        _product.CreateOrUpdatePrice(Merchant.Create("AnotherMerchant"), price2);

        // Act
        var minPrice = _product.MinPrice;

        // Assert
        Assert.AreEqual(price1, minPrice);
    }
}