using LocalUp.Application.DTOs;
using LocalUp.Application.Interfaces.Repository.Read;
using LocalUp.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LocalUp.Infrastructure.Repositories.Read
{
    public class ProductReadRepository : BaseReadRepository<Product, ProductDto>, IProductReadRepository
    {
        public ProductReadRepository(AppDbContext context) : base(context) { }

        public override async Task<ProductDto?> GetById(long id)
        {
            return await _dbSet.AsNoTracking()
                .Include(p => p.Category)
                .Include(p => p.Brand)
                .Where(p => p.Id == id)
                .Select(p => new ProductDto
                {
                    Id = p.Id,
                    Title = p.Title,
                    Description = p.Description,
                    Price = p.Price,
                    DiscountPercent = p.DiscountPercent,
                    FinalPrice = p.Price * (1 - p.DiscountPercent),
                    WeightKg = p.WeightKg,
                    HeightCm = p.HeightCm,
                    WidthCm = p.WidthCm,
                    DepthCm = p.DepthCm,
                    Stock = p.Stock,
                    CategoryId = p.CategoryId,
                    CategoryName = p.Category != null ? p.Category.Name : null,
                    BrandId = p.BrandId,
                    BrandName = p.Brand != null ? p.Brand.Name : null
                })
                .SingleOrDefaultAsync();
        }

        public override async Task<List<ProductDto>> GetAll()
        {
            return await _dbSet.AsNoTracking()
                .Include(p => p.Category)
                .Include(p => p.Brand)
                .Select(p => new ProductDto
                {
                    Id = p.Id,
                    Title = p.Title,
                    Description = p.Description,
                    Price = p.Price,
                    DiscountPercent = p.DiscountPercent,
                    FinalPrice = p.Price * (1 - p.DiscountPercent),
                    WeightKg = p.WeightKg,
                    HeightCm = p.HeightCm,
                    WidthCm = p.WidthCm,
                    DepthCm = p.DepthCm,
                    Stock = p.Stock,
                    CategoryId = p.CategoryId,
                    CategoryName = p.Category != null ? p.Category.Name : null,
                    BrandId = p.BrandId,
                    BrandName = p.Brand != null ? p.Brand.Name : null
                })
                .ToListAsync();
        }
    }
}