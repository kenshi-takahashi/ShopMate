using ShopMate.Domain.Entities;

namespace ShopMate.Domain.IRepository
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User?> GetByEmailAsync(string email);
        Task<User?> GetByUsernameAsync(string username);
    }
}
