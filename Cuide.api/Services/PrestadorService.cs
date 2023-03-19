using Cuide.api.Domain.Models;
using Cuide.api.Repositories.Interfaces;
using Cuide.api.Services.Interfaces;

namespace Cuide.api.Services
{
    public class PrestadorService : IPrestadorService
    {
        private readonly IPrestadorRepository _prestadorRepository;

        public PrestadorService(IPrestadorRepository prestadorRepository)
        {
            _prestadorRepository = prestadorRepository;
        }

        public async Task PostPrestadorAsync(Prestador prestador)
        {
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
