using Cuide.api.Domain.Models;
using Cuide.api.Repositories.Interfaces;
using Cuide.api.Services.Interfaces;

namespace Cuide.api.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task PostUserAsync(User user)
        {           
            await _userRepository.PostUserAsync(user);
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await _userRepository.GetUsersAsync();
        }

        public async Task<User> FindUserAsync(int id)
        {
            return await _userRepository.FindUserAsync(id);
        }

        public async Task UpdateUserAsync(int id, User body)
        {
            await _userRepository.UpdateUserAsync(id, body);
        }

        public async Task DeleteUserAsync(int id)
        {
            await _userRepository.DeleteUserAsync(id);
        }
    }
}
