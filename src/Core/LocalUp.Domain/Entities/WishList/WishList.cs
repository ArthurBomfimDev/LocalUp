using LocalUp.Domain.Entities.Base;

namespace LocalUp.Domain.Entities;

public class WishList : BaseEntity<WishList>
{
    public long UserId { get; private set; }
    public User User { get; private set; }
    public List<WishListItem> Items { get; private set; }
    private WishList(long userId)
    {
        UserId = userId;
        Items = new List<WishListItem>();
    }
    public static WishList Create(long userId)
    {
        if (userId <= 0) throw new ArgumentOutOfRangeException(nameof(userId));
        return new WishList(userId);
    }
    public void AddItem(long productId)
    {
        if (!Items.Any(i => i.ProductId == productId))
        {
            Items.Add(WishListItem.Create(productId));
            SetChangedDate();
        }
    }
    public void RemoveItem(long productId)
    {
        var existing = Items.FirstOrDefault(i => i.ProductId == productId);
        if (existing != null)
        {
            Items.Remove(existing);
            SetChangedDate();
        }
    }
}