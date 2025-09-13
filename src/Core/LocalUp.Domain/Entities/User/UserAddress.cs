using LocalUp.Domain.Entities.Base;

namespace LocalUp.Domain.Entities;

public class UserAddress : BaseEntity<UserAddress>
{
    public string Street { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string Country { get; private set; }
    public string PostalCode { get; private set; }
    public string Complement { get; private set; }
    public int Number { get; private set; }

    private UserAddress(string street, string city, string state, string country, string postalCode, int number, string complement) : base()
    {
        Street = street;
        City = city;
        State = state;
        Country = country;
        PostalCode = postalCode;
        Number = number;
        Complement = complement;
    }
    public static UserAddress Create(string street, string city, string state, string country,
                                     string postalCode, int number, string complement)
    {
        if (string.IsNullOrWhiteSpace(street)) throw new ArgumentNullException(nameof(street));
        if (string.IsNullOrWhiteSpace(city)) throw new ArgumentNullException(nameof(city));
        if (string.IsNullOrWhiteSpace(state)) throw new ArgumentNullException(nameof(state));
        if (string.IsNullOrWhiteSpace(country)) throw new ArgumentNullException(nameof(country));
        if (string.IsNullOrWhiteSpace(postalCode)) throw new ArgumentNullException(nameof(postalCode));
        return new UserAddress(street, city, state, country, postalCode, number, complement);
    }
    public void Update(string street, string city, string state, string country,
                       string postalCode, int number, string complement)
    {
        if (string.IsNullOrWhiteSpace(street)) throw new ArgumentNullException(nameof(street));
        if (string.IsNullOrWhiteSpace(city)) throw new ArgumentNullException(nameof(city));
        if (string.IsNullOrWhiteSpace(state)) throw new ArgumentNullException(nameof(state));
        if (string.IsNullOrWhiteSpace(country)) throw new ArgumentNullException(nameof(country));
        if (string.IsNullOrWhiteSpace(postalCode)) throw new ArgumentNullException(nameof(postalCode));
        Street = street;
        City = city;
        State = state;
        Country = country;
        PostalCode = postalCode;
        Number = number;
        Complement = complement;
        SetChangedDate();
    }
}
