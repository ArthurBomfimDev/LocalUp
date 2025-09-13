using LocalUp.Domain.Entities.Base;

namespace LocalUp.Domain.Entities;

public class Brand : BaseEntity<Brand>
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public List<Product> Products { get; private set; }
    private Brand(string name, string description) : base()
    {
        Name = name;
        Description = description;
        Products = new List<Product>();
    }
    public static Brand Create(string name, string description)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
        return new Brand(name, description);
    }
    public void Update(string name, string description)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
        Name = name;
        Description = description;
        SetChangedDate();
    }
}