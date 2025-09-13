using LocalUp.Domain.Entities.Base;

namespace LocalUp.Domain.Entities;

public class Brand : BaseEntity<Brand>
{
    public string Name { get; private set; }
    public string Description { get; private set; }

    public List<Product> ListProduct { get; private set; }

    private Brand(string name, string description) : base()
    {
        Name = name;
        Description = description;
    }

    public Brand Create(string name, string description)
    {
        if (name == null) throw new ArgumentNullException("name");
        if (description == null) throw new ArgumentNullException("description");

        return new Brand(name, description);
    }

    public void Update(string name, string description)
    {
        if (name == null) throw new ArgumentNullException("name");
        if (description == null) throw new ArgumentNullException("description");

        Name = name;
        Description = description;

        SetChangedDate();
    }
}