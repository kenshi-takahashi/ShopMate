using ShopMate.Domain.Entities;

namespace ShopMate.Domain.IRepository
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        Task<Category?> GetByNameAsync(string name);
    }
}
