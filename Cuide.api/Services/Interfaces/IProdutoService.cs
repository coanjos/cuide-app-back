using Cuide.api.Domain.Models;

namespace Cuide.api.Services.Interfaces
{
    public interface IProdutoService
    {
        public Task PostProdutoAsync(Produto produto);
        public Task<List<Produto>> GetProdutosAsync();
        public Task<Produto> FindProdutoAsync(int id);
        public Task UpdateProdutoAsync(int id, Produto body);
        public Task DeleteProdutoAsync(int id);
    }
}
