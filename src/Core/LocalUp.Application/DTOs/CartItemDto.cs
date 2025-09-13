namespace LocalUp.Application.DTOs
{
    public class CartItemDto
    {
        public long ProductId { get; set; }
        public string ProductTitle { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal SubTotal { get; set; }
    }
}
