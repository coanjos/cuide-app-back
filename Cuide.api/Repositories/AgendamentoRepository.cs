using Cuide.api.Data;
using Cuide.api.Domain.Models;
using Cuide.api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Cuide.api.Repositories
{
    public class AgendamentoRepository : IAgendamentoRepository
    {
        private readonly DataContext _context;
        public AgendamentoRepository(DataContext context)
        {
            _context = context;
        }

        public async Task CriarAgendamentoAsync(Agendamento agendamento)
        {
            _context.Agendamentos.Add(agendamento);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Agendamento>> ListarAgendamentosAsync(int idProduto)
        {
            var existeAlgumPrestadorParaProduto = await _context.PrestadorServicos.Where(p => p.Id == idProduto).ToListAsync();

            if (!existeAlgumPrestadorParaProduto.Any())
            {
                return null;
            }

            var listaAgendamentos = await _context.Agendamentos
                .Include(o => o.Prestador)
                .Where(a => a.Prestador.ServicosOferecidos
                .Any(so => so.Servico.Id == idProduto))
                .ToListAsync();

            return listaAgendamentos;
        }
    }
}
