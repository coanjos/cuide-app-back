using Cuide.api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace Cuide.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendamentoController : ControllerBase
    {
        private IAgendamentoService _agendamentoService;
        public AgendamentoController(IAgendamentoService AgendamentoService)
        {
            _agendamentoService = AgendamentoService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(int idPrestador, DateTime data)
        {
            await _agendamentoService.CriarAgendamentoAsync(idPrestador, data);

            return Created("api/agendamento", data);
        }

        [HttpGet]
        public async Task<IActionResult> Get(int idProduto)
        {
            var agendamentos = await _agendamentoService.ListarAgendamentosAsync(idProduto);

            if (agendamentos == null)
            {
                return NotFound("Nenhum agendamento encontrado");
            }

            return Ok(agendamentos);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int idAgendamento)
        {
            var agendamentoExists = await _agendamentoService.FindAgendamentoAsync(idAgendamento);

            if (agendamentoExists == null)
            {
                return BadRequest();
            }

            await _agendamentoService.DeletarAgendamentoAsync(idAgendamento);

            return Ok();
        }
    }
}
