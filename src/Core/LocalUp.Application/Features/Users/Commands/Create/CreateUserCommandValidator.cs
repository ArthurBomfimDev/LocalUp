using FluentValidation;
using LocalUp.Application.DTOs;

namespace LocalUp.Application.Features.Users.Commands.Create
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(v => v.Name).NotEmpty().MaximumLength(100);
            RuleFor(v => v.Email).NotEmpty().EmailAddress().MaximumLength(150);
            RuleFor(v => v.PasswordHash).NotEmpty().MinimumLength(6);
            RuleFor(v => v.Phone).NotEmpty().MaximumLength(20);
            RuleForEach(v => v.Addresses).SetValidator(new UserAddressDtoValidator());
        }
    }

    public class UserAddressDtoValidator : AbstractValidator<UserAddressDto>
    {
        public UserAddressDtoValidator()
        {
            RuleFor(x => x.Street).NotEmpty().MaximumLength(150);
            RuleFor(x => x.City).NotEmpty().MaximumLength(100);
            RuleFor(x => x.State).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Country).NotEmpty().MaximumLength(100);
            RuleFor(x => x.PostalCode).NotEmpty().MaximumLength(20);
            RuleFor(x => x.Number).GreaterThan(0);
        }
    }
}
