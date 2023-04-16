using Cuide.api.Domain.Models;
using Cuide.api.Repositories.Interfaces;
using Cuide.api.Services.Interfaces;

namespace Cuide.api.Services
{
    public class AgendamentoService : IAgendamentoService
    {
        private readonly IAgendamentoRepository _agendamentoRepository;
        private readonly IPrestadorRepository _prestadorRepository;
        public AgendamentoService(IAgendamentoRepository agendamentoRepository, IPrestadorRepository prestadorRepository)
        {
            _agendamentoRepository = agendamentoRepository ?? throw new ArgumentNullException(nameof(agendamentoRepository));
            _prestadorRepository = prestadorRepository ?? throw new ArgumentNullException(nameof(prestadorRepository));
        }
        public async Task CriarAgendamentoAsync(int idPrestador, DateTime data)
        {
            var prestador = await _prestadorRepository.FindPrestadorAsync(idPrestador);

            if (prestador == null) throw new ArgumentException("Prestador não encontrado!");

            var agendamento = new Agendamento() { Data = data, Prestador = prestador };

            await _agendamentoRepository.CriarAgendamentoAsync(agendamento);
        }

        public async Task<List<Agendamento>> ListarAgendamentosAsync(int idProduto)
        {
            var listaAgendamentos = await _agendamentoRepository.ListarAgendamentosAsync(idProduto);

            return listaAgendamentos;
        }

        public async Task<Agendamento> FindAgendamentoAsync(int idAgendamento)
        {
            return await _agendamentoRepository.FindAgendamentoAsync(idAgendamento);
        }

        public async Task DeletarAgendamentoAsync(int idAgendamento)
        {
            await _agendamentoRepository.DeletarAgendamentoAsync(idAgendamento);
        }
    }
}
