using LocalUp.Application.Interfaces.Repository.Write;
using LocalUp.Application.Interfaces.UnitOfWork;
using MediatR;

namespace LocalUp.Application.Features.Products.Commands.Update
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, bool>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var existing = await _productRepository.GetById(request.Id);
            if (existing == null)
            {
                return false;
            }

            existing.Update(
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

            _productRepository.Update(existing);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}