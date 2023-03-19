using Cuide.api.Data;
using Cuide.api.Domain.Models;
using Cuide.api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Cuide.api.Repositories
{
    public class PrestadorRepository : IPrestadorRepository
    {
        private readonly DataContext _context;
        public PrestadorRepository(DataContext context)
        {
            _context = context;
        }

        public async Task PostPrestadorAsync(Prestador prestador)
        {
            _context.Prestadores.Add(prestador);
            await _context.SaveChangesAsync();
        }
        public async Task<List<Prestador>> GetPrestadoresAsync()
        {
            var list = await _context.Prestadores.ToListAsync();

            return list;
        }

        public async Task<Prestador> FindPrestadorAsync(int id)
        {
            var prestador = await _context.Prestadores.FindAsync(id);

            return prestador;
        }

        public async Task UpdatePrestadorAsync(int id, Prestador body)
        {
            var prestador = await FindPrestadorAsync(id);

            prestador.Nome = body.Nome;

            await _context.SaveChangesAsync();
        }

        public async Task DeletePrestadorAsync(int id)
        {
            var prestador = await FindPrestadorAsync(id);

            _context.Prestadores.Remove(prestador);
            await _context.SaveChangesAsync();
        }
    }
}
