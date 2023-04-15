using Cuide.api.Domain.Models;
using Cuide.api.Repositories.Interfaces;
using Cuide.api.Services.Interfaces;

namespace Cuide.api.Services
{
    public class PrestadorService : IPrestadorService
    {
        private readonly IPrestadorRepository _prestadorRepository;
        private readonly IServicoRepository _servicoRepository;

        public PrestadorService(IPrestadorRepository prestadorRepository, IServicoRepository servicoRepository)
        {
            _prestadorRepository = prestadorRepository;
            _servicoRepository = servicoRepository;
        }

        public async Task PostPrestadorAsync(Prestador prestador)
        {
            var servicosPrestador = prestador.ServicosOferecidos;

            if (servicosPrestador != null)
            {
                for (int i = 0; i < servicosPrestador.Count; i++)
                {
                    servicosPrestador[i].Servico = await _servicoRepository.FindServicoAsync(servicosPrestador[i].Servico.Id);
                }
            }

            await _prestadorRepository.PostPrestadorAsync(prestador);
        }

        public async Task<List<Prestador>> GetPrestadoresAsync()
        {
            return await _prestadorRepository.GetPrestadoresAsync();
        }

        public async Task<Prestador> FindPrestadorAsync(int id)
        {
            return await _prestadorRepository.FindPrestadorAsync(id);
        }

        public async Task UpdatePrestadorAsync(int id, Prestador body)
        {
            await _prestadorRepository.UpdatePrestadorAsync(id, body);
        }

        public async Task DeletePrestadorAsync(int id)
        {
            await _prestadorRepository.DeletePrestadorAsync(id);
        }
    }
}
