using Cuide.api.Data;
using Cuide.api.Domain.Models;
using Cuide.api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Cuide.api.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        public UserRepository(DataContext context)
        {
            _context = context;
        }
        public async Task PostUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();            
        }

        public async Task<List<User>> GetUsersAsync()
        {
            var list = await _context.Users.ToListAsync();

            return list;
        }

        public async Task<User> FindUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);

            return user;
        }

        public async Task UpdateUserAsync(int id, User body)
        {
            var user = await FindUserAsync(id);

            user.Email = body.Email;
            user.Nome = body.Nome;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await FindUserAsync(id);

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}
