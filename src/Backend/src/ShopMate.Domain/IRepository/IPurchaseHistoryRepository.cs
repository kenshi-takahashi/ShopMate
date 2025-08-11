using ShopMate.Domain.Entities;

namespace ShopMate.Domain.IRepository
{
    public interface IPurchaseHistoryRepository : IBaseRepository<PurchaseHistory>
    {
        Task<IEnumerable<PurchaseHistory>> GetByUserAsync(Guid userId);
        Task<IEnumerable<PurchaseHistory>> GetByProductAsync(Guid productId);

        Task<IEnumerable<PurchaseHistory>> GetByPriceRangeAsync(decimal? minPrice, decimal? maxPrice);
        Task<IEnumerable<PurchaseHistory>> GetByDateRangeAsync(DateTime? from, DateTime? to);
        Task<IEnumerable<PurchaseHistory>> GetByNotesAsync(string notesSubstring);
    }
}
