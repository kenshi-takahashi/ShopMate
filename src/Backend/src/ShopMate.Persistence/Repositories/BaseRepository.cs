using Microsoft.EntityFrameworkCore;
using ShopMate.Domain.Entities;
using ShopMate.Domain.IRepository;
using ShopMate.Persistence.Data;

namespace ShopMate.Persistence.Repositories;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
{
    protected readonly ShopMateDbContext DbContext;
    protected readonly DbSet<TEntity> DbSet;

    public BaseRepository(ShopMateDbContext dbContext)
    {
        DbContext = dbContext;
        DbSet = dbContext.Set<TEntity>();
    }

    public virtual async Task<TEntity?> GetByIdAsync(Guid id)
    {
        return await DbSet.AsNoTracking().FirstOrDefaultAsync(e => (e as BaseEntity).Id == id);
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await DbSet.AsNoTracking().ToListAsync();
    }

    public virtual async Task<TEntity> AddAsync(TEntity entity)
    {
        await DbSet.AddAsync(entity);
        await DbContext.SaveChangesAsync();
        return entity;
    }

    public virtual async Task<TEntity> UpdateAsync(TEntity entity)
    {
        DbSet.Update(entity);
        await DbContext.SaveChangesAsync();
        return entity;
    }

    public virtual async Task DeleteAsync(TEntity entity)
    {
        DbSet.Remove(entity);
        await DbContext.SaveChangesAsync();
    }

    public virtual async Task<int> GetTotalCountAsync()
    {
        return await DbSet.AsNoTracking().CountAsync();
    }
}