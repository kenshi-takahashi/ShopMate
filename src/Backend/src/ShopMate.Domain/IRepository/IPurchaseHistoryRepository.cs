using ShopMate.Domain.Entities;

namespace ShopMate.Domain.IRepository
{
    public interface IPurchaseHistoryRepository : IBaseRepository<PurchaseHistory>
    {
        Task<IEnumerable<PurchaseHistory>> GetByUserAsync(Guid userId);
        Task<IEnumerable<PurchaseHistory>> GetByProductAsync(Guid productId);
    }
}
