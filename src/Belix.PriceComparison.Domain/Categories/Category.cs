using Belix.PriceComparison.Domain.Shared.Primitives;

namespace Belix.PriceComparison.Domain.Categories;

public class Category : AggregateRoot
{
    public Guid? ParentId { get; private set; }

    public string Name { get; private set; }
    
    private Category(string name, Guid? parentId = null) : 
        base(Guid.NewGuid())
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentNullException(nameof(name));
        }
        
        Name = name;
        ParentId = parentId;
    }
    
    public static Category Create(string name)
    {
        return new Category(name);
    }
    
    public static Category CreateSubCategory(string name, Category parentCategory)
    {
        if (parentCategory is null)
        {
            throw new ArgumentNullException(nameof(parentCategory));
        }
        
        return new Category(name, parentCategory.Id);
    }
}