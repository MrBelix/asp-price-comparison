using Belix.PriceComparison.Domain.Categories;

namespace Belix.PriceComparison.Domain.Tests;

[TestFixture]
public class CategoryTests
{
    private string _categoryName;
    private Category _parentCategory;

    [SetUp]
    public void SetUp()
    {
        _categoryName = "Test Category";
        _parentCategory = Category.Create("Parent Category");
    }

    [Test]
    public void Create_ShouldSetCategoryName()
    {
        // Arrange
        // Act
        var category = Category.Create(_categoryName);

        // Assert
        Assert.That(category.Name, Is.EqualTo(_categoryName));
    }

    [Test]
    public void Create_WithEmptyCategoryName_ShouldThrowArgumentNullException()
    {
        // Arrange
        var emptyCategoryName = string.Empty;

        // Act & Assert
        Assert.That(() => Category.Create(emptyCategoryName), Throws.ArgumentNullException);
    }

    [Test]
    public void Create_WithNullCategoryName_ShouldThrowArgumentNullException()
    {
        // Arrange
        string nullCategoryName = null;

        // Act & Assert
        Assert.That(() => Category.Create(nullCategoryName), Throws.ArgumentNullException);
    }

    [Test]
    public void CreateSubCategory_ShouldSetCategoryNameAndParentId()
    {
        // Arrange
        // Act
        var subCategory = Category.CreateSubCategory(_categoryName, _parentCategory);

        // Assert
        Assert.That(subCategory.Name, Is.EqualTo(_categoryName));
        Assert.That(subCategory.ParentId, Is.EqualTo(_parentCategory.Id));
    }

    [Test]
    public void CreateSubCategory_WithEmptyCategoryName_ShouldThrowArgumentNullException()
    {
        // Arrange
        var emptyCategoryName = string.Empty;

        // Act & Assert
        Assert.That(() => Category.CreateSubCategory(emptyCategoryName, _parentCategory), Throws.ArgumentNullException);
    }

    [Test]
    public void CreateSubCategory_WithNullCategoryName_ShouldThrowArgumentNullException()
    {
        // Arrange
        string nullCategoryName = null;

        // Act & Assert
        Assert.That(() => Category.CreateSubCategory(nullCategoryName, _parentCategory), Throws.ArgumentNullException);
    }

    [Test]
    public void CreateSubCategory_WithNullParentCategory_ShouldThrowArgumentNullException()
    {
        // Arrange
        Category nullParentCategory = null;

        // Act & Assert
        Assert.That(() => Category.CreateSubCategory(_categoryName, nullParentCategory), Throws.ArgumentNullException);
    }
}