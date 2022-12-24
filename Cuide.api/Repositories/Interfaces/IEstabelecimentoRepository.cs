using Cuide.api.Domain.Models;

namespace Cuide.api.Repositories.Interfaces
{
    public interface IEstabelecimentoRepository
    {
        public Task PostEstabelecimentoAsync(Estabelecimento estabelecimento);
        public Task<List<Estabelecimento>> GetEstabelecimentosAsync();
        public Task<Estabelecimento> FindEstabelecimentoAsync(int id);
        public Task UpdateEstabelecimentoAsync(int id, Estabelecimento body);
        public Task DeleteEstabelecimentoAsync(int id);
    }
}
