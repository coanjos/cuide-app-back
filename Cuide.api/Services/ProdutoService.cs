using Cuide.api.Domain.Models;
using Cuide.api.Repositories.Interfaces;
using Cuide.api.Services.Interfaces;

namespace Cuide.api.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task PostProdutoAsync(Produto produto)
        {
            await _produtoRepository.PostProdutoAsync(produto);
        }
        public async Task<List<Produto>> GetProdutosAsync()
        {
            return await _produtoRepository.GetProdutosAsync();
        }

        public async Task<Produto> FindProdutoAsync(int id)
        {
            return await _produtoRepository.FindProdutoAsync(id);
        }

        public async Task UpdateProdutoAsync(int id, Produto body)
        {
            await _produtoRepository.UpdateProdutoAsync(id, body);
        }

        public async Task DeleteProdutoAsync(int id)
        {
            await _produtoRepository.DeleteProdutoAsync(id);
        }
    }
}
