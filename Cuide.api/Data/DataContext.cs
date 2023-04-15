using Cuide.api.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Cuide.api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }

        public DbSet<Prestador> Prestadores { get; set; }

        public DbSet<Servico> Servicos { get; set; }

        public DbSet<Agendamento> Agendamentos { get; set; }
        public DbSet<PrestadorServico> PrestadorServicos { get; set; }

    }
}
