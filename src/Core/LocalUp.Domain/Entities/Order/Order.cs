using LocalUp.Domain.Entities.Base;

namespace LocalUp.Domain.Entities;

public class Order : BaseEntity<Order>
{
    public long UserId { get; private set; }
    public User User { get; private set; }
    public DateTimeOffset OrderDate { get; private set; }
    public List<OrderItem> Items { get; private set; }

    private Order(long userId)
    {
        UserId = userId;
        OrderDate = DateTimeOffset.UtcNow;
        Items = new List<OrderItem>();
    }

    public static Order Create(long userId)
    {
        if (userId <= 0) throw new ArgumentOutOfRangeException(nameof(userId));
        return new Order(userId);
    }

    public void AddItem(long productId, int quantity, decimal unitPrice)
    {
        if (quantity <= 0) throw new ArgumentOutOfRangeException(nameof(quantity));
        if (unitPrice < 0) throw new ArgumentOutOfRangeException(nameof(unitPrice));
        var existing = Items.FirstOrDefault(i => i.ProductId == productId);
        if (existing == null)
        {
            var item = OrderItem.Create(productId, quantity, unitPrice);
            Items.Add(item);
        }
        else
        {
            existing.Update(existing.Quantity + quantity, unitPrice);
        }
        SetChangedDate();
    }

    public decimal Total => Items.Sum(i => i.SubTotal);
}