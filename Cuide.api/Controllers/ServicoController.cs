using Cuide.api.Domain.Models;
using Cuide.api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Cuide.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicoController : ControllerBase
    {
        private IServicoService _servicoService;
        public ServicoController(IServicoService servicoService) 
        {
            _servicoService = servicoService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Servico servico)
        {
            await _servicoService.PostServicoAsync(servico);

            return Ok(servico);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _servicoService.GetServicosAsync();

            return Ok(result);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> Get(int id)
        {
            var servico = await _servicoService.FindServicoAsync(id);

            if (servico == null)
            {
                return NotFound();
            }

            return Ok(servico);
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> Put(int id, Servico body)
        {
            var servicoExists = await _servicoService.FindServicoAsync(id);

            if (servicoExists == null)
            {
                return BadRequest();
            }

            await _servicoService.UpdateServicoAsync(id, body);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var servicoExists = await _servicoService.FindServicoAsync(id);

            if (servicoExists == null)
            {
                return BadRequest();
            }

            await _servicoService.DeleteServicoAsync(id);
            return Ok();
        }

    }
}
