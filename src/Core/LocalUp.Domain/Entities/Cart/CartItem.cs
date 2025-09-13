using LocalUp.Domain.Entities.Base;

namespace LocalUp.Domain.Entities.Cart;

public class CartItem : BaseEntity<CartItem>
{
    public long ProductId { get; private set; }
    public Product Product { get; private set; }
    public int Quantity { get; private set; }
    public decimal UnitPrice { get; private set; }
    public long CartId { get; private set; }
    public Cart Cart { get; private set; }
    private CartItem(long productId, int quantity, decimal unitPrice)
    {
        ProductId = productId;
        Quantity = quantity;
        UnitPrice = unitPrice;
    }
    public static CartItem Create(long productId, int quantity, decimal unitPrice)
    {
        if (quantity <= 0) throw new ArgumentOutOfRangeException(nameof(quantity));
        if (unitPrice < 0) throw new ArgumentOutOfRangeException(nameof(unitPrice));
        return new CartItem(productId, quantity, unitPrice);
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
