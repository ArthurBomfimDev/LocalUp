namespace LocalUp.Domain.Entities.Base;

public class BaseEntity<TEntity> where TEntity : BaseEntity<TEntity>
{
    public long Id { get; private set; }
    public DateTimeOffset CreatedDate { get; protected set; }
    public DateTimeOffset? ChangedDate { get; protected set; }
    public bool IsActive { get; protected set; }

    protected BaseEntity()
    {
        CreatedDate = DateTimeOffset.UtcNow;
        IsActive = true;
    }

    public virtual void SetChangedDate()
    {
        ChangedDate = DateTimeOffset.UtcNow;
    }
}