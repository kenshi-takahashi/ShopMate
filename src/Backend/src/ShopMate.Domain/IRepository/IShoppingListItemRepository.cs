using ShopMate.Domain.Entities;

namespace ShopMate.Domain.IRepository
{
    public interface IShoppingListItemRepository : IBaseRepository<ShoppingListItem>
    {
        Task<IEnumerable<ShoppingListItem>> GetByShoppingListAsync(Guid shoppingListId);
        Task<IEnumerable<ShoppingListItem>> GetByNameAsync(string name);
        Task<IEnumerable<ShoppingListItem>> GetByQuantityAsync(int quantity);
        Task<IEnumerable<ShoppingListItem>> GetByPriceRangeAsync(decimal? minPrice, decimal? maxPrice);
        Task<IEnumerable<ShoppingListItem>> GetByNotesAsync(string notesSubstring);
        Task<IEnumerable<ShoppingListItem>> GetByUnitAsync(string unit);

    }
}
