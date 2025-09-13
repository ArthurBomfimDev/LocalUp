using FluentValidation;

namespace LocalUp.Application.Features.Products.Commands.Update
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id inválido.");
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("O título é obrigatório.")
                .MaximumLength(200).WithMessage("O título não pode exceder 200 caracteres.");
            RuleFor(x => x.Description)
                .MaximumLength(1000).WithMessage("A descrição não pode exceder 1000 caracteres.");
            RuleFor(x => x.Price)
                .GreaterThanOrEqualTo(0).WithMessage("O preço deve ser maior ou igual a zero.");
            RuleFor(x => x.DiscountPercent)
                .GreaterThanOrEqualTo(0)
                .LessThan(1).WithMessage("O desconto deve estar entre 0 e 1 (por exemplo, 0.2 para 20%).");
            RuleFor(x => x.WeightKg)
                .GreaterThan(0).WithMessage("O peso deve ser maior que zero.");
            RuleFor(x => x.HeightCm)
                .GreaterThan(0).WithMessage("A altura deve ser maior que zero.");
            RuleFor(x => x.WidthCm)
                .GreaterThan(0).WithMessage("A largura deve ser maior que zero.");
            RuleFor(x => x.DepthCm)
                .GreaterThan(0).WithMessage("A profundidade deve ser maior que zero.");
            RuleFor(x => x.Stock)
                .GreaterThanOrEqualTo(0).WithMessage("O estoque não pode ser negativo.");
            RuleFor(x => x.CategoryId)
                .GreaterThan(0).WithMessage("A categoria é obrigatória.");
            RuleFor(x => x.BrandId)
                .GreaterThan(0).WithMessage("A marca é obrigatória.");
        }
    }
}