using LocalUp.Domain.Entities.Enum;

namespace LocalUp.Application.DTOs
{
    public class UserDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public UserRole Role { get; set; }
        public IEnumerable<string> Phones { get; set; }
        public IEnumerable<UserAddressDto> Addresses { get; set; }
    }
}
