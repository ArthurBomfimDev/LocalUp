using LocalUp.Application.Interfaces.Repository.Write;
using LocalUp.Application.Interfaces.UnitOfWork;
using MediatR;

namespace LocalUp.Application.Features.Products.Commands.Create
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, long>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<long> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = Product.Create(
                request.Title,
                request.Description,
                request.Price,
                request.DiscountPercent,
                request.WeightKg,
                request.HeightCm,
                request.WidthCm,
                request.DepthCm,
                request.Stock,
                request.CategoryId,
                request.BrandId);

            await _productRepository.Create(product);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return product.Id;
        }
    }
}