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

        [Fact]
        public async Task Get_Sucesso_DeveListarAgendamentos()
        {
            var idPrestador = 1;
            var idProduto = 1;
            var listaAgendamentos = new List<Agendamento>()
            {
                new Agendamento(),
                new Agendamento()
            };

            var agendamentoServiceMock = new Mock<IAgendamentoService>();
            agendamentoServiceMock.Setup(service => service.ListarAgendamentosAsync(idProduto)).ReturnsAsync(listaAgendamentos);

            var controller = new AgendamentoController(agendamentoServiceMock.Object);
            var result = (OkObjectResult)await controller.Get(idProduto);

            agendamentoServiceMock.Verify(service => service.ListarAgendamentosAsync(idProduto), Times.Once());
            result.StatusCode.Should().Be(200);
            result.Value.Should().BeOfType<List<Agendamento>>();
        }

        [Fact]
        public async Task Delete_Sucesso_DeveDeletarAgendamento()
        {
            var idAgendamento = 1;

            var agendamento = new Agendamento() { Id = 1 };

            var agendamentoServiceMock = new Mock<IAgendamentoService>();
            agendamentoServiceMock.Setup(service => service.FindAgendamentoAsync(idAgendamento)).ReturnsAsync(agendamento);

            var controller = new AgendamentoController(agendamentoServiceMock.Object);

            var result = (OkResult)await controller.Delete(idAgendamento);

            agendamentoServiceMock.Verify(s => s.DeletarAgendamentoAsync(idAgendamento), Times.Once());
            result.StatusCode.Should().Be(200);
        }
    }
}
