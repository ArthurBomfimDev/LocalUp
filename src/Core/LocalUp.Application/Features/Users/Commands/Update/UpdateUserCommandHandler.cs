using LocalUp.Application.Interfaces.Repository.Write;
using LocalUp.Application.Interfaces.UnitOfWork;
using LocalUp.Domain.Entities;
using MediatR;

namespace LocalUp.Application.Features.Users.Commands.Update
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, bool>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var existing = await _userRepository.GetById(request.Id);
            if (existing == null)
            {
                return false;
            }
            var addresses = request.Addresses?.Select(dto => UserAddress.Create(dto.Street, dto.City, dto.State, dto.Country, dto.PostalCode, dto.Number, dto.Complement)).ToList() ?? new List<UserAddress>();
            existing.Update(request.Name, request.Email, request.PasswordHash, request.Role, request.Phone, addresses);
            _userRepository.Update(existing);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}