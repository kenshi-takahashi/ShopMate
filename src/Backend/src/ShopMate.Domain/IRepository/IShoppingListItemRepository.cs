using ShopMate.Domain.Entities;

namespace ShopMate.Domain.IRepository
{
    public interface IShoppingListItemRepository : IBaseRepository<ShoppingListItem>
    {
        Task<IEnumerable<ShoppingListItem>> GetByShoppingListAsync(Guid shoppingListId);
    }
}
