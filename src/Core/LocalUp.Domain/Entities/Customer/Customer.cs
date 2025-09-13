using LocalUp.Domain.Entities.Base;

namespace LocalUp.Domain.Entities;

public class Customer : BaseEntity<Customer>
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public string Phone { get; private set; }
    public List<CustomerAddress> ListAddress { get; private set; }

    private Customer(string name, string description, string phone)
    {
         Name = name;
         Description = description;
         Phone = phone;
    }

    public Customer Create(string name, string description, string phone)
    {
        if (name == null) throw new ArgumentNullException("name");
        if (description == null) throw new ArgumentNullException("description");
        if (phone == null) throw new ArgumentNullException("phone");
        if (phone.Length != 11) throw new ArgumentNullException("phone.Length != 11");

        return new Customer(name, description, phone);
    }

    public void Update(string name, string description, string phone)
    {
        if (name == null) throw new ArgumentNullException("name");
        if (description == null) throw new ArgumentNullException("description");
        if (phone == null) throw new ArgumentNullException("phone");
        if (phone.Length != 11) throw new ArgumentNullException("phone.Length != 11");

        Name = name;
        Description = description;
        Phone = phone;
    }
}