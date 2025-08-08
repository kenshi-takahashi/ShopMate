using ShopMate.Domain.Entities;

namespace ShopMate.Domain.IRepository
{
    public interface IShoppingListRepository : IBaseRepository<ShoppingList>
    {
        Task<IEnumerable<ShoppingList>> GetByUserAsync(Guid userId);
    }
}
