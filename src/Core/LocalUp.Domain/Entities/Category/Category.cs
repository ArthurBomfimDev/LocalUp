using LocalUp.Domain.Entities.Base;

namespace LocalUp.Domain.Entities.Category;

public class Category : BaseEntity<Category>
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public long? ParentCategoryId { get; private set; }
    public Category ParentCategory { get; private set; }
    public List<Product> Products { get; private set; }

    private Category(string name, string description, long? parentCategoryId)
        : base()
    {
        Name = name;
        Description = description;
        ParentCategoryId = parentCategoryId;
        Products = new List<Product>();
    }
    public static Category Create(string name, string description, long? parentCategoryId)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
        return new Category(name, description, parentCategoryId);
    }
    public void Update(string name, string description, long? parentCategoryId)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
        Name = name;
        Description = description;
        ParentCategoryId = parentCategoryId;
        SetChangedDate();
    }
}