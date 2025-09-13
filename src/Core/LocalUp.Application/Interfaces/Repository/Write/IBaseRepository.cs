using LocalUp.Domain.Entities.Base;

namespace LocalUp.Application.Interfaces.Repository.Write
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity<TEntity>
    {
        Task<TEntity?> GetById(long id);
        Task<List<TEntity>?> GetListByListId(List<long> listId);
        Task Create(TEntity entity);
        Task CreateMultiple(List<TEntity> listEntity);
        void Update(TEntity entity);
        void UpdateMultiple(List<TEntity> listEntity);
        void Delete(TEntity entity);
        void DeleteMultiple(List<TEntity> listEntity);
    }
}
