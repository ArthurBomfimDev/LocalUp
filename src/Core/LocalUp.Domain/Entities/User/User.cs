using LocalUp.Domain.Entities.Base;
using LocalUp.Domain.Entities.Enum;

namespace LocalUp.Domain.Entities;

public class User : BaseEntity<User>
{
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string PasswordHash { get; private set; }
    public UserRole Role { get; private set; }
    public string Phone { get; private set; }
    public List<UserAddress> Addresses { get; private set; }

    private User(string name, string email, string passwordHash, UserRole role,
                 string phone, List<UserAddress> addresses)
        : base()
    {
        Name = name;
        Email = email;
        PasswordHash = passwordHash;
        Role = role;
        Phone = phone;
        Addresses = addresses ?? new List<UserAddress>();
    }

    public static User Create(string name, string email, string passwordHash, UserRole role,
                              string phone,
                              IEnumerable<UserAddressDTO> addressDtos)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
        if (string.IsNullOrWhiteSpace(email)) throw new ArgumentNullException(nameof(email));
        if (string.IsNullOrWhiteSpace(passwordHash)) throw new ArgumentNullException(nameof(passwordHash));
        if (string.IsNullOrWhiteSpace(phone)) throw new ArgumentNullException(nameof(phone));
        
        var addresses = addressDtos?.Select(dto => UserAddress.Create(dto.Street, dto.City, dto.State, dto.Country, dto.PostalCode, dto.Number, dto.Complement)).ToList() ?? new List<UserAddress>();
        return new User(name, email, passwordHash, role, phone, addresses);
    }

    public void Update(string name, string email, string passwordHash, UserRole role,
                       string phone,
                       IEnumerable<UserAddressDTO> addressDtos)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
        if (string.IsNullOrWhiteSpace(email)) throw new ArgumentNullException(nameof(email));
        if (string.IsNullOrWhiteSpace(passwordHash)) throw new ArgumentNullException(nameof(passwordHash));

        Name = name;
        Email = email;
        PasswordHash = passwordHash;
        Role = role;
        Phone = phone;

        var newAddresses = addressDtos?.Select(dto => UserAddress.Create(dto.Street, dto.City, dto.State, dto.Country, dto.PostalCode, dto.Number, dto.Complement)).ToList() ?? new List<UserAddress>();
        Addresses = newAddresses;

        SetChangedDate();
    }

    public class UserAddressDTO
    {
        public string Street { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }
        public string PostalCode { get; private set; }
        public string Complement { get; private set; }
        public int Number { get; private set; }

        public UserAddressDTO(string street, string city, string state, string country, string postalCode, string complement, int number)
        {
            Street = street;
            City = city;
            State = state;
            Country = country;
            PostalCode = postalCode;
            Complement = complement;
            Number = number;
        }
    }
}