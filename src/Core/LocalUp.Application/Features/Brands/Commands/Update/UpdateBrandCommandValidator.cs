using FluentValidation;

namespace LocalUp.Application.Features.Brands.Commands.Update
{
    public class UpdateBrandCommandValidator : AbstractValidator<UpdateBrandCommand>
    {
        public UpdateBrandCommandValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id inválido.");
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("O nome é obrigatório.")
                .MaximumLength(100).WithMessage("O nome não pode exceder 100 caracteres.");
            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("A descrição não pode exceder 500 caracteres.");
        }
    }
}