using Cuide.api.Data;
using Cuide.api.Domain.Models;
using Cuide.api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Cuide.api.Repositories
{
    public class EstabelecimentoRepository : IEstabelecimentoRepository
    {
        private readonly DataContext _context;
        public EstabelecimentoRepository(DataContext context)
        {
            _context = context;
        }

        public async Task PostEstabelecimentoAsync(Estabelecimento estabelecimento)
        {
            _context.Estabelecimentos.Add(estabelecimento);
            await _context.SaveChangesAsync();
        }
        public async Task<List<Estabelecimento>> GetEstabelecimentosAsync()
        {
            var list = await _context.Estabelecimentos.ToListAsync();

            return list;
        }

        public async Task<Estabelecimento> FindEstabelecimentoAsync(int id)
        {
            var estabelecimento = await _context.Estabelecimentos.FindAsync(id);

            return estabelecimento;
        }

        public async Task UpdateEstabelecimentoAsync(int id, Estabelecimento body)
        {
            var estabelecimento = await FindEstabelecimentoAsync(id);

            estabelecimento.Nome = body.Nome;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteEstabelecimentoAsync(int id)
        {
            var estabelecimento = await FindEstabelecimentoAsync(id);

            _context.Estabelecimentos.Remove(estabelecimento);
            await _context.SaveChangesAsync();
        }
    }
}
