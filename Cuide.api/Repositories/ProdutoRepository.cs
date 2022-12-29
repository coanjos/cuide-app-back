using Cuide.api.Data;
using Cuide.api.Domain.Models;
using Cuide.api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Cuide.api.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly DataContext _context;
        public ProdutoRepository(DataContext context)
        {
            _context = context;
        }

        public async Task PostProdutoAsync(Produto produto)
        {
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync(); 
        }
        public async Task<List<Produto>> GetProdutosAsync()
        {
            var list = await _context.Produtos.ToListAsync();

            return list;
        }

        public async Task<Produto> FindProdutoAsync(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);

            return produto;
        }

        public async Task UpdateProdutoAsync(int id, Produto body)
        {
            var produto = await FindProdutoAsync(id);

            produto.Nome = body.Nome;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteProdutoAsync(int id)
        {
            var produto = await FindProdutoAsync(id);

            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();
        }
    }
}
