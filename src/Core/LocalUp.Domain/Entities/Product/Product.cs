using LocalUp.Domain.Entities;
using LocalUp.Domain.Entities.Base;
using LocalUp.Domain.Entities.Category;

public class Product : BaseEntity<Product>
{
    public string Title { get; private set; }
    public string Description { get; private set; }
    public decimal Price { get; private set; }
    public decimal DiscountPercent { get; private set; }
    public decimal WeightKg { get; private set; }
    public decimal HeightCm { get; private set; }
    public decimal WidthCm { get; private set; }
    public decimal DepthCm { get; private set; }
    public int Stock { get; private set; }
    public long CategoryId { get; private set; }
    public Category Category { get; private set; }
    public long BrandId { get; private set; }
    public Brand Brand { get; private set; }

    private Product(string title, string description, decimal price, decimal discountPercent,
                    decimal weightKg, decimal heightCm, decimal widthCm, decimal depthCm,
                    int stock, long categoryId, long brandId)
    {
        Title = title;
        Description = description;
        Price = price;
        DiscountPercent = discountPercent;
        WeightKg = weightKg;
        HeightCm = heightCm;
        WidthCm = widthCm;
        DepthCm = depthCm;
        Stock = stock;
        CategoryId = categoryId;
        BrandId = brandId;
    }

    public decimal FinalPrice => Price * (1 - DiscountPercent);

    public static Product Create(string title, string description, decimal price, decimal discountPercent,
                                 decimal weightKg, decimal heightCm, decimal widthCm, decimal depthCm,
                                 int stock, long categoryId, long brandId)
    {
        if (string.IsNullOrWhiteSpace(title)) throw new ArgumentNullException(nameof(title));
        if (price < 0) throw new ArgumentOutOfRangeException(nameof(price));
        if (discountPercent < 0 || discountPercent >= 1) throw new ArgumentOutOfRangeException(nameof(discountPercent));
        if (weightKg <= 0) throw new ArgumentOutOfRangeException(nameof(weightKg));
        if (heightCm <= 0) throw new ArgumentOutOfRangeException(nameof(heightCm));
        if (widthCm <= 0) throw new ArgumentOutOfRangeException(nameof(widthCm));
        if (depthCm <= 0) throw new ArgumentOutOfRangeException(nameof(depthCm));
        if (stock < 0) throw new ArgumentOutOfRangeException(nameof(stock));
        return new Product(title, description, price, discountPercent,
                           weightKg, heightCm, widthCm, depthCm,
                           stock, categoryId, brandId);
    }

    public void Update(string title, string description, decimal price, decimal discountPercent,
                        decimal weightKg, decimal heightCm, decimal widthCm, decimal depthCm,
                        int stock, long categoryId, long brandId)
    {
        if (string.IsNullOrWhiteSpace(title)) throw new ArgumentNullException(nameof(title));
        if (price < 0) throw new ArgumentOutOfRangeException(nameof(price));
        if (discountPercent < 0 || discountPercent >= 1) throw new ArgumentOutOfRangeException(nameof(discountPercent));
        if (weightKg <= 0) throw new ArgumentOutOfRangeException(nameof(weightKg));
        if (heightCm <= 0) throw new ArgumentOutOfRangeException(nameof(heightCm));
        if (widthCm <= 0) throw new ArgumentOutOfRangeException(nameof(widthCm));
        if (depthCm <= 0) throw new ArgumentOutOfRangeException(nameof(depthCm));
        if (stock < 0) throw new ArgumentOutOfRangeException(nameof(stock));
        Title = title;
        Description = description;
        Price = price;
        DiscountPercent = discountPercent;
        WeightKg = weightKg;
        HeightCm = heightCm;
        WidthCm = widthCm;
        DepthCm = depthCm;
        Stock = stock;
        CategoryId = categoryId;
        BrandId = brandId;
        SetChangedDate();
    }
}