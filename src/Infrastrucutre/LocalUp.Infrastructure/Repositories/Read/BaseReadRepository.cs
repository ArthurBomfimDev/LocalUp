using LocalUp.Application.Interfaces.Repository.Read;
using LocalUp.Application.Interfaces.Repository.Read.Base;
using LocalUp.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LocalUp.Infrastructure.Repositories.Read
{
    public abstract class BaseReadRepository<TEntity, TDto> : IReadRepository<TDto>
        where TEntity : class
    {
        protected readonly AppDbContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        protected BaseReadRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public abstract Task<TDto?> GetById(long id);
        public abstract Task<List<TDto>> GetAll();
    }
}