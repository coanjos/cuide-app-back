using Cuide.api.Domain.Models;

namespace Cuide.api.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task PostUserAsync(User user);
        Task<List<User>> GetUsersAsync();
        Task<User> FindUserAsync(int id);
        Task UpdateUserAsync(int id, User body);
        Task DeleteUserAsync(int id);
    }
}
