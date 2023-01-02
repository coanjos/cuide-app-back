using Cuide.api.Domain.Models;

namespace Cuide.api.Repositories.Interfaces
{
    public interface IProdutoRepository
    {
        public Task PostProdutoAsync(Produto produto);
        public Task<List<Produto>> GetProdutosAsync();
        public Task<Produto> FindProdutoAsync(int id);
        public Task UpdateProdutoAsync(int id, Produto body);
        public Task DeleteProdutoAsync(int id);
    }
}
