using Cuide.api.Domain.Models;
using Cuide.api.Repositories.Interfaces;
using Cuide.api.Services.Interfaces;

namespace Cuide.api.Services
{
    public class ServicoService : IServicoService
    {
        private readonly IServicoRepository _servicoRepository;

        public ServicoService(IServicoRepository servicoRepository)
        {
            _servicoRepository = servicoRepository;
        }

        public async Task PostServicoAsync(Servico servico)
        {
            await _servicoRepository.PostServicoAsync(servico);
        }
        public async Task<List<Servico>> GetServicosAsync()
        {
            return await _servicoRepository.GetServicosAsync();
        }

        public async Task<Servico> FindServicoAsync(int id)
        {
            return await _servicoRepository.FindServicoAsync(id);
        }

        public async Task UpdateServicoAsync(int id, Servico body)
        {
            await _servicoRepository.UpdateServicoAsync(id, body);
        }

        public async Task DeleteServicoAsync(int id)
        {
            await _servicoRepository.DeleteServicoAsync(id);
        }
    }
}
