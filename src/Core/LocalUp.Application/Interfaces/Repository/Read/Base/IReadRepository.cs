using LocalUp.Application.DTOs;

namespace LocalUp.Application.Interfaces.Repository.Read.Base
{
    public interface IReadRepository<TEntityDto>
    {
        Task<TEntityDto?> GetById(long id);
        Task<List<TEntityDto>> GetAll();
    }
}
