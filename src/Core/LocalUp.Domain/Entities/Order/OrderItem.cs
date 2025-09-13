using LocalUp.Domain.Entities.Base;

namespace LocalUp.Domain.Entities;

public class OrderItem : BaseEntity<OrderItem>
{
    public long ProductId { get; private set; }
    public Product Product { get; private set; }
    public int Quantity { get; private set; }
    public decimal UnitPrice { get; private set; }
    public long OrderId { get; private set; }
    public Order Order { get; private set; }

    private OrderItem(long productId, int quantity, decimal unitPrice)
    {
        ProductId = productId;
        Quantity = quantity;
        UnitPrice = unitPrice;
    }

    public static OrderItem Create(long productId, int quantity, decimal unitPrice)
    {
        if (quantity <= 0) throw new ArgumentOutOfRangeException(nameof(quantity));
        if (unitPrice < 0) throw new ArgumentOutOfRangeException(nameof(unitPrice));
        return new OrderItem(productId, quantity, unitPrice);
    }

    public void Update(int quantity, decimal unitPrice)
    {
        if (quantity <= 0) throw new ArgumentOutOfRangeException(nameof(quantity));
        if (unitPrice < 0) throw new ArgumentOutOfRangeException(nameof(unitPrice));
        Quantity = quantity;
        UnitPrice = unitPrice;
        SetChangedDate();
    }

    public decimal SubTotal => UnitPrice * Quantity;
}