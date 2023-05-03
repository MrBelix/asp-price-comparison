using Belix.PriceComparison.Domain.Brands;

namespace Belix.PriceComparison.Domain.Tests;

[TestFixture]
public class BrandTests
{
    private string _brandName;

    [SetUp]
    public void SetUp()
    {
        _brandName = "Test Brand";
    }

    [Test]
    public void Create_ShouldSetBrandName()
    {
        // Arrange
        // Act
        var brand = Brand.Create(_brandName);

        // Assert
        Assert.That(brand.Name, Is.EqualTo(_brandName));
    }

    [Test]
    public void Create_WithEmptyBrandName_ShouldThrowArgumentNullException()
    {
        // Arrange
        var emptyBrandName = string.Empty;

        // Act & Assert
        Assert.That(() => Brand.Create(emptyBrandName), Throws.ArgumentNullException);
    }

    [Test]
    public void Create_WithNullBrandName_ShouldThrowArgumentNullException()
    {
        // Arrange
        string nullBrandName = null;

        // Act & Assert
        Assert.That(() => Brand.Create(nullBrandName), Throws.ArgumentNullException);
    }
}