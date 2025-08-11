using ShopMate.Domain.Entities;

namespace ShopMate.Domain.IRepository
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<IEnumerable<Product>> GetByCategoryAsync(Guid categoryId);
        Task<Product?> GetByNameAndBrandAsync(string name, string? brand);
    }
}
