using LocalUp.Application.DTOs;
using LocalUp.Application.Interfaces.Repository.Read;
using LocalUp.Domain.Entities;
using LocalUp.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LocalUp.Infrastructure.Repositories.Read
{
    public class BrandReadRepository : BaseReadRepository<Brand, BrandDto>, IBrandReadRepository
    {
        public BrandReadRepository(AppDbContext context) : base(context) { }
        public override async Task<BrandDto?> GetById(long id)
        {
            return await _dbSet.AsNoTracking()
                .Where(b => b.Id == id)
                .Select(b => new BrandDto
                {
                    Id = b.Id,
                    Name = b.Name,
                    Description = b.Description
                })
                .SingleOrDefaultAsync();
        }
        public override async Task<List<BrandDto>> GetAll()
        {
            return await _dbSet.AsNoTracking()
                .Select(b => new BrandDto
                {
                    Id = b.Id,
                    Name = b.Name,
                    Description = b.Description
                })
                .ToListAsync();
        }
    }
}