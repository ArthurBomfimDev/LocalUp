using MediatR;

namespace LocalUp.Application.Features.Products.Commands.Update
{
    public record UpdateProductCommand(
        long Id,
        string Title,
        string Description,
        decimal Price,
        decimal DiscountPercent,
        decimal WeightKg,
        decimal HeightCm,
        decimal WidthCm,
        decimal DepthCm,
        int Stock,
        long CategoryId,
        long BrandId) : IRequest<bool>;
}