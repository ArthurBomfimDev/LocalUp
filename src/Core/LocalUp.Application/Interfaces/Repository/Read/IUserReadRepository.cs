using LocalUp.Application.DTOs;
using LocalUp.Application.Interfaces.Repository.Read.Base;

namespace LocalUp.Application.Interfaces.Repository.Read;

public interface IUserReadRepository : IReadRepository<UserDto> { }