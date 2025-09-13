using LocalUp.Application.Interfaces.Repository.Write;
using LocalUp.Application.Interfaces.UnitOfWork;
using MediatR;

namespace LocalUp.Application.Features.Brands.Commands.Update
{
    public class UpdateBrandCommandHandler : IRequestHandler<UpdateBrandCommand, bool>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateBrandCommandHandler(IBrandRepository brandRepository, IUnitOfWork unitOfWork)
        {
            _brandRepository = brandRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
        {
            var existing = await _brandRepository.GetById(request.Id);
            if (existing == null)
            {
                return false;
            }
            existing.Update(request.Name, request.Description);
            _brandRepository.Update(existing);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}