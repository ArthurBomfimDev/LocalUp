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
        if (name.Length > 100) throw new ArgumentException("Nome passa de 100 caracteres");

        if (string.IsNullOrWhiteSpace(description)) throw new ArgumentNullException(nameof(description));
        if (description.Length > 500) throw new ArgumentException("Descrição passa de 500 caracteres");

        return new Brand(name, description);
    }
    public void Update(string name, string description)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
        if (name.Length > 100) throw new ArgumentException("Nome passa de 100 caracteres");

        if (string.IsNullOrWhiteSpace(description)) throw new ArgumentNullException(nameof(description));
        if (description.Length > 500) throw new ArgumentException("Descrição passa de 500 caracteres");

        Name = name;
        Description = description;
        SetChangedDate();
    }
}