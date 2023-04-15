using Cuide.api.Controllers;
using Cuide.api.Domain.Models;
using Cuide.api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Cuide.UnitTests.Systems.Controllers
{
    public class AgendamentoControllerTests
    {
        [Fact]
        public async Task Post_Sucesso_DevePersistir()
        {
            var idPrestador = 1;
            var data = DateTime.Now;
            var agendamentoServiceMock = new Mock<IAgendamentoService>();
            var controller = new AgendamentoController(agendamentoServiceMock.Object);
            var result = (CreatedResult)await controller.Post(idPrestador, data);

            agendamentoServiceMock.Verify(service => service.CriarAgendamentoAsync(idPrestador, data), Times.Once());
            result.StatusCode.Should().Be(201);
        }
    }
}
