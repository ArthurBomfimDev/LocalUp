using LocalUp.Domain.Entities.Base;

namespace LocalUp.Domain.Entities.WishList;

public class WishListItem : BaseEntity<WishListItem>
{
    public long ProductId { get; private set; }
    public Product Product { get; private set; }
    public long WishListId { get; private set; }
    public WishList WishList { get; private set; }
    private WishListItem(long productId)
    {
        ProductId = productId;
    }
    public static WishListItem Create(long productId)
    {
        if (productId <= 0) throw new ArgumentOutOfRangeException(nameof(productId));
        return new WishListItem(productId);
    }
}
