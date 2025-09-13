using LocalUp.Application.Interfaces.Repository.Write;
using LocalUp.Application.Interfaces.UnitOfWork;
using MediatR;

namespace LocalUp.Application.Features.Categories.Commands.Update
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, bool>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var existing = await _categoryRepository.GetById(request.Id);
            if (existing == null)
            {
                return false;
            }
            existing.Update(request.Name, request.Description, request.ParentCategoryId);
            _categoryRepository.Update(existing);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}