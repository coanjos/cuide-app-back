using Cuide.api.Domain.Models;

namespace Cuide.api.Services.Interfaces
{
    public interface IUserService
    {        
        public Task PostUserAsync(User user);
        public Task<List<User>> GetUsersAsync();
        public Task<User> FindUserAsync(int id);
        public Task UpdateUserAsync(int id, User body);
        public Task DeleteUserAsync(int id);

    }
}
