using MediatR;

namespace LocalUp.Application.Features.Products.Commands.Create
{
    public record CreateProductCommand(
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
        long BrandId) : IRequest<long>;
}