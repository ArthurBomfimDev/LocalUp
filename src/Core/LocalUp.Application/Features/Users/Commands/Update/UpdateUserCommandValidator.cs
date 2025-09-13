using FluentValidation;

namespace LocalUp.Application.Features.Users.Commands.Update
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id inválido.");
            RuleFor(v => v.Name)
                .NotEmpty().WithMessage("O nome é obrigatório.")
                .MaximumLength(100).WithMessage("O nome não pode exceder 100 caracteres.");
            RuleFor(v => v.Email)
                .NotEmpty().WithMessage("O e-mail é obrigatório.")
                .EmailAddress().WithMessage("O e-mail é inválido.")
                .MaximumLength(150).WithMessage("O e-mail não pode exceder 150 caracteres.");
            RuleFor(v => v.PasswordHash)
                .NotEmpty().WithMessage("A senha é obrigatória.")
                .MinimumLength(6).WithMessage("A senha deve ter pelo menos 6 caracteres.");
            RuleFor(v => v.Phone)
                .NotEmpty().WithMessage("O telefone é obrigatório.")
                .MaximumLength(20).WithMessage("O telefone não pode exceder 20 caracteres.");
            RuleForEach(v => v.Addresses).SetValidator(new UserAddressDtoValidator());
        }
    }

    internal class UserAddressDtoValidator : AbstractValidator<LocalUp.Application.DTOs.UserAddressDto>
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