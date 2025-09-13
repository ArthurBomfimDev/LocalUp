using FluentValidation;

namespace LocalUp.Application.Features.Categories.Commands.Create
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("O nome é obrigatório.")
                .MaximumLength(100).WithMessage("O nome não pode exceder 100 caracteres.");

            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("A descrição não pode exceder 500 caracteres.");
        }
    }
}