using Cuide.api.Domain.Models;
using Cuide.api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Cuide.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private IProdutoService _produtoService;
        public ProdutoController(IProdutoService produtoService) 
        {
            _produtoService = produtoService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Produto produto)
        {
            await _produtoService.PostProdutoAsync(produto);

            return Ok(produto);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _produtoService.GetProdutosAsync();

            return Ok(result);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> Get(int id)
        {
            var produto = await _produtoService.FindProdutoAsync(id);

            if (produto == null)
            {
                return NotFound();
            }

            return Ok(produto);
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> Put(int id, Produto body)
        {
            var produtoExists = await _produtoService.FindProdutoAsync(id);

            if (produtoExists == null)
            {
                return BadRequest();
            }

            await _produtoService.UpdateProdutoAsync(id, body);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var produtoExists = await _produtoService.FindProdutoAsync(id);

            if (produtoExists == null)
            {
                return BadRequest();
            }

            await _produtoService.DeleteProdutoAsync(id);
            return Ok();
        }

    }
}
