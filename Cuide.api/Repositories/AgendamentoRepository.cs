using Cuide.api.Data;
using Cuide.api.Domain.Models;
using Cuide.api.Repositories.Interfaces;

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
    }
}
