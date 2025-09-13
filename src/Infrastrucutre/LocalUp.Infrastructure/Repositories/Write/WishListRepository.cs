using LocalUp.Application.Interfaces.Repository.Write;
using LocalUp.Domain.Entities;
using LocalUp.Infrastructure.Persistence;
using LocalUp.Infrastructure.Repositories.Write.Base;

namespace LocalUp.Infrastructure.Repositories.Write
{
    public class WishListRepository : BaseRepository<WishList>, IWishListRepository
    {
        public WishListRepository(AppDbContext context) : base(context) { }
    }
}