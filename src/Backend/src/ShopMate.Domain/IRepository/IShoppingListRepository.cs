using ShopMate.Domain.Entities;

namespace ShopMate.Domain.IRepository
{
    public interface IShoppingListRepository : IBaseRepository<ShoppingList>
    {
        Task<IEnumerable<ShoppingList>> GetByOwnerAsync(Guid userId);
        Task<IEnumerable<ShoppingList>> GetByNamesAsync(string name);
    }
}
