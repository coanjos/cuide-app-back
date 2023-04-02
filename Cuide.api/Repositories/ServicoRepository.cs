using Cuide.api.Data;
using Cuide.api.Domain.Models;
using Cuide.api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Cuide.api.Repositories
{
    public class ServicoRepository : IServicoRepository
    {
        private readonly DataContext _context;
        public ServicoRepository(DataContext context)
        {
            _context = context;
        }

        public async Task PostServicoAsync(Servico servico)
        {
            _context.Servicos.Add(servico);
            await _context.SaveChangesAsync(); 
        }
        public async Task<List<Servico>> GetServicosAsync()
        {
            var list = await _context.Servicos.ToListAsync();

            return list;
        }

        public async Task<Servico> FindServicoAsync(int id)
        {
            var servico = await _context.Servicos.FindAsync(id);

            return servico;
        }

        public async Task UpdateServicoAsync(int id, Servico body)
        {
            var servico = await FindServicoAsync(id);

            servico.Nome = body.Nome;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteServicoAsync(int id)
        {
            var servico = await FindServicoAsync(id);

            _context.Servicos.Remove(servico);
            await _context.SaveChangesAsync();
        }
    }
}
