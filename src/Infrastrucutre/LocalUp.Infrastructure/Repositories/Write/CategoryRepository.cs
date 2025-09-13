using LocalUp.Application.Interfaces.Repository.Write;
using LocalUp.Domain.Entities;
using LocalUp.Infrastructure.Persistence;
using LocalUp.Infrastructure.Repositories.Write.Base;

namespace LocalUp.Infrastructure.Repositories.Write
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context) { }
    }
}