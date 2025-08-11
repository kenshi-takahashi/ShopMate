using Microsoft.EntityFrameworkCore;
using ShopMate.Domain.Entities;
using ShopMate.Domain.IRepository;
using ShopMate.Persistence.Data;

namespace ShopMate.Persistence.Repositories;

public class PurchaseHistoryRepository : BaseRepository<PurchaseHistory>, IPurchaseHistoryRepository
{
    public PurchaseHistoryRepository(ShopMateDbContext dbContext) : base(dbContext) { }

    public async Task<IEnumerable<PurchaseHistory>> GetByUserAsync(Guid userId)
    {
        return await DbContext.PurchaseHistories.AsNoTracking().Where(p => p.UserId == userId).ToListAsync();
    }

    public async Task<IEnumerable<PurchaseHistory>> GetByProductAsync(Guid productId)
    {
        return await DbContext.PurchaseHistories.AsNoTracking().Where(p => p.ProductId == productId).ToListAsync();
    }

    public async Task<IEnumerable<PurchaseHistory>> GetByPriceRangeAsync(decimal? minPrice, decimal? maxPrice)
    {
        var query = DbContext.PurchaseHistories.AsNoTracking().AsQueryable();
        if (minPrice.HasValue)
        {
            query = query.Where(p => p.Price >= minPrice);
        }
        if (maxPrice.HasValue)
        {
            query = query.Where(p => p.Price <= maxPrice);
        }
        return await query.ToListAsync();
    }

    public async Task<IEnumerable<PurchaseHistory>> GetByDateRangeAsync(DateTime? from, DateTime? to)
    {
        var query = DbContext.PurchaseHistories.AsNoTracking().AsQueryable();
        if (from.HasValue)
        {
            query = query.Where(p => p.PurchasedAt >= from.Value);
        }
        if (to.HasValue)
        {
            query = query.Where(p => p.PurchasedAt <= to.Value);
        }
        return await query.ToListAsync();
    }

    public async Task<IEnumerable<PurchaseHistory>> GetByNotesAsync(string notesSubstring)
    {
        return await DbContext.PurchaseHistories.AsNoTracking()
            .Where(p => p.Notes != null && EF.Functions.ILike(p.Notes, $"%{notesSubstring}%"))
            .ToListAsync();
    }
}


