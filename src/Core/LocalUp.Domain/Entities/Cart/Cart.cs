using LocalUp.Domain.Entities.Base;

namespace LocalUp.Domain.Entities;

public class Cart : BaseEntity<Cart>
{
    public long UserId { get; private set; }
    public User User { get; private set; }
    public List<CartItem> Items { get; private set; }

    private Cart(long userId)
    {
        UserId = userId;
        Items = new List<CartItem>();
    }

    public static Cart Create(long userId)
    {
        if (userId <= 0) throw new ArgumentOutOfRangeException(nameof(userId));
        return new Cart(userId);
    }

    public void AddItem(long productId, int quantity, decimal unitPrice)
    {
        var existing = Items.FirstOrDefault(i => i.ProductId == productId);
        if (existing == null)
        {
            var item = CartItem.Create(productId, quantity, unitPrice);
            Items.Add(item);
        }
        else
        {
            existing.Update(existing.Quantity + quantity, unitPrice);
        }
        SetChangedDate();
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

    public decimal Total => Items.Sum(i => i.SubTotal);
}
