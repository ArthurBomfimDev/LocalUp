using LocalUp.Application.Interfaces.Repository.Write;
using LocalUp.Infrastructure.Persistence;
using LocalUp.Infrastructure.Repositories.Write.Base;

namespace LocalUp.Infrastructure.Repositories.Write
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context) { }
    }
}