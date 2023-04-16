using Cuide.api.Domain.Models;

namespace Cuide.api.Services.Interfaces
{
    public interface IAgendamentoService
    {
        public Task CriarAgendamentoAsync(int idPrestador, DateTime data);
        public Task<List<Agendamento>> ListarAgendamentosAsync(int idProduto);
    }
}
