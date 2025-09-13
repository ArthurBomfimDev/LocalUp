using LocalUp.Application.Interfaces.Repository.Write;
using LocalUp.Application.Interfaces.UnitOfWork;
using LocalUp.Domain.Entities;
using MediatR;

namespace LocalUp.Application.Features.Users.Commands.Create
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, long>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CreateUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<long> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var addresses = request.Addresses?.Select(dto => UserAddress.Create(dto.Street, dto.City, dto.State, dto.Country, dto.PostalCode, dto.Number, dto.Complement)).ToList() ?? new List<UserAddress>();
            var user = User.Create(request.Name, request.Email, request.PasswordHash, request.Role, request.Phone, addresses);
            await _userRepository.Create(user);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return user.Id;
        }
    }
}
