using Microsoft.EntityFrameworkCore;
using ShopMate.Domain.Entities;
using ShopMate.Domain.IRepository;
using ShopMate.Persistence.Data;

namespace ShopMate.Persistence.Repositories;

public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
{
    public CategoryRepository(ShopMateDbContext dbContext) : base(dbContext) { }

    public async Task<Category?> GetByNameAsync(string name)
    {
        return await DbContext.Categories.AsNoTracking().FirstOrDefaultAsync(c => c.Name == name);
    }
}


