using LocalUp.Application.Interfaces.Repository.Write;
using LocalUp.Domain.Entities;
using LocalUp.Infrastructure.Persistence;
using LocalUp.Infrastructure.Repositories.Write.Base;

namespace LocalUp.Infrastructure.Repositories.Write
{
    public class CartRepository : BaseRepository<Cart>, ICartRepository
    {
        public CartRepository(AppDbContext context) : base(context) { }
    }
}