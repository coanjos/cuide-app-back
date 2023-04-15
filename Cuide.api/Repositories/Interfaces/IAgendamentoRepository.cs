using Cuide.api.Domain.Models;

namespace Cuide.api.Repositories.Interfaces
{
    public interface IAgendamentoRepository
    {
        public Task CriarAgendamentoAsync(Agendamento agendamento);

    }
}
