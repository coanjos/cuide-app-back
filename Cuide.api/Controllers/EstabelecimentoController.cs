using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using Cuide.api.Services.Interfaces;
using Cuide.api.Domain.Models;

namespace Cuide.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstabelecimentoController : ControllerBase
    {
        private IEstabelecimentosService _estabelecimentoService;

        public EstabelecimentoController(IEstabelecimentosService estabelecimentoService)
        {
            _estabelecimentoService = estabelecimentoService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Estabelecimento estabelecimento)
        {
            await _estabelecimentoService.PostEstabelecimentoAsync(estabelecimento);

            return Ok(estabelecimento);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _estabelecimentoService.GetEstabelecimentosAsync();

            return Ok(result);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> Get(int id)
        {
            var result = await _estabelecimentoService.FindEstabelecimentoAsync(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPut("{id}")]
        
        public async Task<IActionResult> Put(int id, Estabelecimento body)
        {
            var estabelecimentoExists = await _estabelecimentoService.FindEstabelecimentoAsync(id);

            if (estabelecimentoExists == null)
            {
                return BadRequest();
            }

            await _estabelecimentoService.UpdateEstabelecimentoAsync(id, body);

            return NoContent();
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            var estabelecimentoExists = await _estabelecimentoService.FindEstabelecimentoAsync(id);

            if (estabelecimentoExists == null)
            {
                return BadRequest();
            }

            await _estabelecimentoService.DeleteEstabelecimentoAsync(id);

            return Ok();
        }
    }
}
