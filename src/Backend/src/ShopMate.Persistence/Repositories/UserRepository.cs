using Microsoft.EntityFrameworkCore;
using ShopMate.Domain.Entities;
using ShopMate.Domain.IRepository;
using ShopMate.Persistence.Data;

namespace ShopMate.Persistence.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(ShopMateDbContext dbContext) : base(dbContext) { }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await DbContext.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<User?> GetByUsernameAsync(string username)
    {
        return await DbContext.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Username == username);
    }
}


