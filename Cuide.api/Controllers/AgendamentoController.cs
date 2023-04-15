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

    }
}
