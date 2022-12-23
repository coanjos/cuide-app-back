using Cuide.api.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Cuide.api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
