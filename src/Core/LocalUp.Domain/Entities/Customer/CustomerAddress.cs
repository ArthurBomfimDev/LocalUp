using LocalUp.Domain.Entities.Enum;

namespace LocalUp.Domain.Entities;

public class CustomerAddress
{ 
    public long CustomerId { get; private set; }
    public string Street { get; private set; }
    public EnumState State { get; private set; }
    public EnumCountry Country { get; private set; }
    public string Complement { get; private set; }
    public string Neighborhood { get; private set; }
    public string PostalCode { get; private set; }
    public int Number { get; private set; }

    private CustomerAddress(long customerId, string street, EnumState state, EnumCountry country, string complement, string neighborhood, string postalCode, int number)
    {
        CustomerId = customerId;
        Street = street;
        State = state;
        Country = country;
        Complement = complement;
        Neighborhood = neighborhood;
        PostalCode = postalCode;
        Number = number;
    }

    public static CustomerAddress Create(long customerId, string street, EnumState state, string complement, string neighborhood, string postalCode, int number)
    {
        if (street == null) throw new ArgumentNullException("Street");
        if (state == default) throw new ArgumentNullException("EnumState");
        if (complement == null) throw new ArgumentNullException("Complement");
        if (neighborhood == null) throw new ArgumentNullException("Neighborhood");
        if (postalCode == null) throw new ArgumentNullException("PostalCode");
        if (number == default) throw new ArgumentNullException("Number");

        return new CustomerAddress(customerId, street, state, EnumCountry.BR, complement, neighborhood, postalCode, number)
    }

    public void Update(string street, EnumState state, string complement, string neighborhood, string postalCode, int number)
    {
        if (street == null) throw new ArgumentNullException("Street");
        if (state == default) throw new ArgumentNullException("EnumState");
        if (complement == null) throw new ArgumentNullException("Complement");
        if (neighborhood == null) throw new ArgumentNullException("Neighborhood");
        if (postalCode == null) throw new ArgumentNullException("PostalCode");
        if (number == default) throw new ArgumentNullException("Number");

        Street = street;
        State = state;
        Complement = complement;
        Neighborhood = neighborhood;
        PostalCode = postalCode;
        Number = number;
    }
}
