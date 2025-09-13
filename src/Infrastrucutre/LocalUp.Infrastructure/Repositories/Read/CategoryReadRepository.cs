using LocalUp.Application.DTOs;
using LocalUp.Application.Interfaces.Repository.Read;
using LocalUp.Domain.Entities;
using LocalUp.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LocalUp.Infrastructure.Repositories.Read
{
    public class CategoryReadRepository : BaseReadRepository<Category, CategoryDto>, ICategoryReadRepository
    {
        public CategoryReadRepository(AppDbContext context) : base(context) { }
        public override async Task<CategoryDto?> GetById(long id)
        {
            return await _dbSet.AsNoTracking()
                .Where(c => c.Id == id)
                .Select(c => new CategoryDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description,
                    ParentCategoryId = c.ParentCategoryId
                })
                .SingleOrDefaultAsync();
        }

        public override async Task<List<CategoryDto>> GetAll()
        {
            return await _dbSet.AsNoTracking()
                .Select(c => new CategoryDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description,
                    ParentCategoryId = c.ParentCategoryId
                })
                .ToListAsync();
        }
    }
}