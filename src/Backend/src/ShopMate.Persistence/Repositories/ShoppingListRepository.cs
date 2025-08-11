using Microsoft.EntityFrameworkCore;
using ShopMate.Domain.Entities;
using ShopMate.Domain.IRepository;
using ShopMate.Persistence.Data;

namespace ShopMate.Persistence.Repositories;

public class ShoppingListRepository : BaseRepository<ShoppingList>, IShoppingListRepository
{
    public ShoppingListRepository(ShopMateDbContext dbContext) : base(dbContext) { }

    public async Task<IEnumerable<ShoppingList>> GetByOwnerAsync(Guid userId)
    {
        return await DbContext.ShoppingLists.AsNoTracking().Where(sl => sl.OwnerId == userId).ToListAsync();
    }

    public async Task<IEnumerable<ShoppingList>> GetByNamesAsync(string name)
    {
        return await DbContext.ShoppingLists.AsNoTracking().Where(sl => sl.Name == name).ToListAsync();
    }
}


