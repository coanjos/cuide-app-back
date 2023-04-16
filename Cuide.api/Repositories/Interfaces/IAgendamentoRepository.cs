using Cuide.api.Domain.Models;

namespace Cuide.api.Repositories.Interfaces
{
    public interface IAgendamentoRepository
    {
        public Task CriarAgendamentoAsync(Agendamento agendamento);
        public Task<List<Agendamento>> ListarAgendamentosAsync(int idProduto);
        public Task<Agendamento> FindAgendamentoAsync(int idAgendamento);
        public Task DeletarAgendamentoAsync(int idAgendamento);
    }
}
