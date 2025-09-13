using LocalUp.Application.DTOs;
using LocalUp.Domain.Entities.Enum;
using MediatR;

namespace LocalUp.Application.Features.Users.Commands.Create
{
    public record CreateUserCommand(
        string Name,
        string Email,
        string PasswordHash,
        UserRole Role,
        string Phone,
        IEnumerable<UserAddressDto> Addresses) : IRequest<long>;
}
