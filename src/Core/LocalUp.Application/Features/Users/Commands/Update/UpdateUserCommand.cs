using LocalUp.Application.DTOs;
using LocalUp.Domain.Enums;
using MediatR;

namespace LocalUp.Application.Features.Users.Commands.Update
{
    public record UpdateUserCommand(
        long Id,
        string Name,
        string Email,
        string PasswordHash,
        UserRole Role,
        string Phone,
        IEnumerable<UserAddressDto> Addresses) : IRequest<bool>;
}