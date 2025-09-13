namespace LocalUp.Application.DTOs
{
    public class ProductDto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal DiscountPercent { get; set; }
        public decimal FinalPrice { get; set; }
        public decimal WeightKg { get; set; }
        public decimal HeightCm { get; set; }
        public decimal WidthCm { get; set; }
        public decimal DepthCm { get; set; }
        public int Stock { get; set; }
        public long CategoryId { get; set; }
        public string CategoryName { get; set; }
        public long BrandId { get; set; }
        public string BrandName { get; set; }
    }
}
