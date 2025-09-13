using LocalUp.Application.Interfaces.Repository.Write;
using LocalUp.Domain.Entities.Base;
using LocalUp.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LocalUp.Infrastructure.Repositories.Write.Base
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : BaseEntity<TEntity>
    {
        protected readonly AppDbContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        protected BaseRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public virtual async Task<TEntity?> GetById(long id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<List<TEntity>?> GetListByListId(List<long> listId)
        {
            return await _dbSet.Where(x => listId.Contains(x.Id)).ToListAsync();
        }

        public virtual async Task Create(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task CreateMultiple(List<TEntity> listEntity)
        {
            await _dbSet.AddRangeAsync(listEntity);
        }

        public virtual void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }

        public void UpdateMultiple(List<TEntity> listEntity)
        {
            _dbSet.UpdateRange(listEntity);
        }

        public virtual void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public void DeleteMultiple(List<TEntity> listEntity)
        {
            _dbSet.RemoveRange(listEntity);
        }
    }
}