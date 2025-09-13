using LocalUp.Application.DTOs;
using LocalUp.Application.Interfaces.Repository.Read;
using LocalUp.Domain.Entities;
using LocalUp.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LocalUp.Infrastructure.Repositories.Read
{
    public class CartReadRepository : BaseReadRepository<Cart, CartDto>, ICartReadRepository
    {
        public CartReadRepository(AppDbContext context) : base(context) { }

        public override async Task<CartDto?> GetById(long id)
        {
            return await _dbSet.AsNoTracking()
                .Include(c => c.Items)
                .ThenInclude(i => i.Product)
                .Where(c => c.Id == id)
                .Select(c => new CartDto
                {
                    Id = c.Id,
                    UserId = c.UserId,
                    Items = c.Items.Select(i => new CartItemDto
                    {
                        ProductId = i.ProductId,
                        ProductTitle = i.Product.Title,
                        Quantity = i.Quantity,
                        UnitPrice = i.UnitPrice,
                        SubTotal = i.UnitPrice * i.Quantity
                    }).ToList(),
                    Total = c.Items.Sum(i => i.UnitPrice * i.Quantity)
                })
                .SingleOrDefaultAsync();
        }

        public override async Task<List<CartDto>> GetAll()
        {
            return await _dbSet.AsNoTracking()
                .Include(c => c.Items)
                .ThenInclude(i => i.Product)
                .Select(c => new CartDto
                {
                    Id = c.Id,
                    UserId = c.UserId,
                    Items = c.Items.Select(i => new CartItemDto
                    {
                        ProductId = i.ProductId,
                        ProductTitle = i.Product.Title,
                        Quantity = i.Quantity,
                        UnitPrice = i.UnitPrice,
                        SubTotal = i.UnitPrice * i.Quantity
                    }).ToList(),
                    Total = c.Items.Sum(i => i.UnitPrice * i.Quantity)
                })
                .ToListAsync();
        }
    }
}