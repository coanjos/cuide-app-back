using Cuide.api.Domain.Models;
using Cuide.api.Repositories.Interfaces;
using Cuide.api.Services.Interfaces;

namespace Cuide.api.Services
{
    public class EstabelecimentoService : IEstabelecimentosService
    {
        private readonly IEstabelecimentoRepository _estabelecimentoRepository;

        public EstabelecimentoService(IEstabelecimentoRepository estabelecimentoRepository)
        {
            _estabelecimentoRepository = estabelecimentoRepository;
        }

        public async Task PostEstabelecimentoAsync(Estabelecimento estabelecimento)
        {
            await _estabelecimentoRepository.PostEstabelecimentoAsync(estabelecimento);
        }

        public async Task<List<Estabelecimento>> GetEstabelecimentosAsync()
        {
            return await _estabelecimentoRepository.GetEstabelecimentosAsync();
        }

        public async Task<Estabelecimento> FindEstabelecimentoAsync(int id)
        {
            return await _estabelecimentoRepository.FindEstabelecimentoAsync(id);
        }

        public async Task UpdateEstabelecimentoAsync(int id, Estabelecimento body)
        {
            await _estabelecimentoRepository.UpdateEstabelecimentoAsync(id, body);
        }

        public async Task DeleteEstabelecimentoAsync(int id)
        {
            await _estabelecimentoRepository.DeleteEstabelecimentoAsync(id);
        }
    }
}
