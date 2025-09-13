using LocalUp.Application.DTOs;
using LocalUp.Application.Interfaces.Repository.Read;
using LocalUp.Domain.Entities;
using LocalUp.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LocalUp.Infrastructure.Repositories.Read
{
    public class UserReadRepository : BaseReadRepository<User, UserDto>, IUserReadRepository
    {
        public UserReadRepository(AppDbContext context) : base(context) { }
        public override async Task<UserDto?> GetById(long id)
        {
            return await _dbSet.AsNoTracking()
                .Where(u => u.Id == id)
                .Select(u => new UserDto
                {
                    Id = u.Id,
                    Name = u.Name,
                    Email = u.Email,
                    Role = u.Role,
                    Phone = u.Phone,
                    Addresses = u.Addresses.Select(a => new UserAddressDto
                    {
                        Street = a.Street,
                        City = a.City,
                        State = a.State,
                        Country = a.Country,
                        PostalCode = a.PostalCode,
                        Number = a.Number,
                        Complement = a.Complement
                    }).ToList()
                })
                .SingleOrDefaultAsync();
        }
        public override async Task<List<UserDto>> GetAll()
        {
            return await _dbSet.AsNoTracking()
                .Select(u => new UserDto
                {
                    Id = u.Id,
                    Name = u.Name,
                    Email = u.Email,
                    Role = u.Role,
                    Phone = u.Phone,
                    Addresses = u.Addresses.Select(a => new UserAddressDto
                    {
                        Street = a.Street,
                        City = a.City,
                        State = a.State,
                        Country = a.Country,
                        PostalCode = a.PostalCode,
                        Number = a.Number,
                        Complement = a.Complement
                    }).ToList()
                })
                .ToListAsync();
        }
    }
}