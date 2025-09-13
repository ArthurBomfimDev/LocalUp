namespace LocalUp.Application.DTOs
{
    public class CartDto
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public IEnumerable<CartItemDto> Items { get; set; }
        public decimal Total { get; set; }
    }
}
