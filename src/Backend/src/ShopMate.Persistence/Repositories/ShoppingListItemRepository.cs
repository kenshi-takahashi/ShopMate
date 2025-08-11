using Microsoft.EntityFrameworkCore;
using ShopMate.Domain.Entities;
using ShopMate.Domain.IRepository;
using ShopMate.Persistence.Data;

namespace ShopMate.Persistence.Repositories;

public class ShoppingListItemRepository : BaseRepository<ShoppingListItem>, IShoppingListItemRepository
{
    public ShoppingListItemRepository(ShopMateDbContext dbContext) : base(dbContext) { }

    public async Task<IEnumerable<ShoppingListItem>> GetByShoppingListAsync(Guid shoppingListId)
    {
        return await DbContext.ShoppingListItems.AsNoTracking().Where(i => i.ShoppingListId == shoppingListId).ToListAsync();
    }

    public async Task<IEnumerable<ShoppingListItem>> GetByNameAsync(string name)
    {
        return await DbContext.ShoppingListItems.AsNoTracking().Where(i => i.Name == name).ToListAsync();
    }

    public async Task<IEnumerable<ShoppingListItem>> GetByQuantityAsync(int quantity)
    {
        return await DbContext.ShoppingListItems.AsNoTracking().Where(i => i.Quantity == quantity).ToListAsync();
    }

    public async Task<IEnumerable<ShoppingListItem>> GetByPriceRangeAsync(decimal? minPrice, decimal? maxPrice)
    {
        var query = DbContext.ShoppingListItems.AsNoTracking().AsQueryable();
        if (minPrice.HasValue)
        {
            query = query.Where(i => i.Price >= minPrice);
        }
        if (maxPrice.HasValue)
        {
            query = query.Where(i => i.Price <= maxPrice);
        }
        return await query.ToListAsync();
    }

    public async Task<IEnumerable<ShoppingListItem>> GetByNotesAsync(string notesSubstring)
    {
        return await DbContext.ShoppingListItems.AsNoTracking()
            .Where(i => i.Notes != null && EF.Functions.ILike(i.Notes, $"%{notesSubstring}%"))
            .ToListAsync();
    }

    public async Task<IEnumerable<ShoppingListItem>> GetByUnitAsync(string unit)
    {
        return await DbContext.ShoppingListItems.AsNoTracking().Where(i => i.Unit == unit).ToListAsync();
    }
}


