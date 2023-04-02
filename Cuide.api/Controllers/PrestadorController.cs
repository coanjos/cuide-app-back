using Microsoft.AspNetCore.Mvc;
using Cuide.api.Services.Interfaces;
using Cuide.api.Domain.Models;

namespace Cuide.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrestadorController : ControllerBase
    {
        private IPrestadorService _prestadorService;

        public PrestadorController(IPrestadorService PrestadorService)
        {
            _prestadorService = PrestadorService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Prestador prestador)
        {
            await _prestadorService.PostPrestadorAsync(prestador);

            return Created("api/prestador", prestador);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _prestadorService.GetPrestadoresAsync();

            if (!result.Any())
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> Get(int id)
        {
            var result = await _prestadorService.FindPrestadorAsync(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPut("{id}")]
        
        public async Task<IActionResult> Put(int id, Prestador body)
        {
            var prestadorExists = await _prestadorService.FindPrestadorAsync(id);

            if (prestadorExists == null)
            {
                return BadRequest();
            }

            await _prestadorService.UpdatePrestadorAsync(id, body);

            return NoContent();
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            var prestadorExists = await _prestadorService.FindPrestadorAsync(id);

            if (prestadorExists == null)
            {
                return BadRequest();
            }

            await _prestadorService.DeletePrestadorAsync(id);

            return Ok();
        }
    }
}
