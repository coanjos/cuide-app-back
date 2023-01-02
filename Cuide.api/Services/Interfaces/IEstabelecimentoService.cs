
using Cuide.api.Domain.Models;

namespace Cuide.api.Services.Interfaces
{
    public interface IEstabelecimentoService
    {
        public Task PostEstabelecimentoAsync(Estabelecimento estabelecimento);
        public Task<List<Estabelecimento>> GetEstabelecimentosAsync();
        public Task<Estabelecimento> FindEstabelecimentoAsync(int id);
        public Task UpdateEstabelecimentoAsync(int id, Estabelecimento body);
        public Task DeleteEstabelecimentoAsync(int id);
    }
}
