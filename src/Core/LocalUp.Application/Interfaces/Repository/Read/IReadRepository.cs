using LocalUp.Application.DTOs;

namespace LocalUp.Application.Interfaces.Repository.Read
{
    public interface IReadRepository<TEntityDto>
    {
        Task<TEntityDto?> GetById(long id);
        Task<List<TEntityDto>> GetAll();
    }
    public interface IUserReadRepository : IReadRepository<UserDto> { }
    public interface IBrandReadRepository : IReadRepository<BrandDto> { }
    public interface ICategoryReadRepository : IReadRepository<CategoryDto> { }
    public interface IProductReadRepository : IReadRepository<ProductDto> { }
    public interface ICartReadRepository : IReadRepository<CartDto> { }
}
