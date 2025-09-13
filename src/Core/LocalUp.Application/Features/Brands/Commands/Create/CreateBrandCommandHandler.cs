using LocalUp.Application.Interfaces.Repository.Write;
using LocalUp.Application.Interfaces.UnitOfWork;
using LocalUp.Domain.Entities;
using MediatR;

namespace LocalUp.Application.Features.Brands.Commands.Create
{
    public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, long>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CreateBrandCommandHandler(IBrandRepository brandRepository, IUnitOfWork unitOfWork)
        {
            _brandRepository = brandRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<long> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            var brand = Brand.Create(request.Name, request.Description);
            await _brandRepository.Create(brand);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return brand.Id;
        }
    }
}
