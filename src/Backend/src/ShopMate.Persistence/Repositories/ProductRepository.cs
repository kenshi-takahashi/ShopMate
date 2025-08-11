using Microsoft.EntityFrameworkCore;
using ShopMate.Domain.Entities;
using ShopMate.Domain.IRepository;
using ShopMate.Persistence.Data;

namespace ShopMate.Persistence.Repositories;

public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    public ProductRepository(ShopMateDbContext dbContext) : base(dbContext) { }

    public async Task<IEnumerable<Product>> GetByCategoryAsync(Guid categoryId)
    {
        return await DbContext.Products.AsNoTracking().Where(p => p.CategoryId == categoryId).ToListAsync();
    }

    public async Task<Product?> GetByNameAndBrandAsync(string name, string? brand)
    {
        return await DbContext.Products.AsNoTracking()
            .FirstOrDefaultAsync(p => p.Name == name && p.Brand == brand);
    }
}


