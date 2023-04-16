using Cuide.api.Services;
using Cuide.api.Domain.Models;
using Cuide.api.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Cuide.api.Controllers;
using Cuide.api.Services.Interfaces;
using Xunit;

namespace Cuide.UnitTests.Systems.Services
{
    public class AgendamentoServiceTests
    {
        [Fact]
        public async Task CriarAgendamento_Sucesso_DeveCriar()
        {
            var idPrestador = 1;
            var data = DateTime.Now;
            var prestador = new Prestador() { Id = 1, Nome = "Doguinha" };
            var agendamento = new Agendamento() { Data = DateTime.Now, Prestador = prestador };
            var agendamentoRepositoryMock = new Mock<IAgendamentoRepository>();
            var prestadorRepositoryMock = new Mock<IPrestadorRepository>();
            prestadorRepositoryMock.Setup(repo => repo.FindPrestadorAsync(idPrestador)).ReturnsAsync(prestador);
            var service = new AgendamentoService(agendamentoRepositoryMock.Object, prestadorRepositoryMock.Object);

            await service.CriarAgendamentoAsync(idPrestador, data);

            prestadorRepositoryMock.Verify(repo => repo.FindPrestadorAsync(idPrestador), Times.Once());
            agendamentoRepositoryMock.Verify(repo => repo.CriarAgendamentoAsync(It.Is<Agendamento>(a => a.Prestador.Id == prestador.Id)));
        }

        [Fact]
        public async Task ListarAgendamentoAsync_Sucesso_DeveListar()
        {
            var idPrestador = 1;
            var idProduto = 1;
            var listaAgendamentos = new List<Agendamento>()
            {
                new Agendamento(),
                new Agendamento()
            };

            var agendamentoRepositoryMock = new Mock<IAgendamentoRepository>();
            var prestadorRepositoryMock = new Mock<IPrestadorRepository>();

            var service = new AgendamentoService(agendamentoRepositoryMock.Object, prestadorRepositoryMock.Object);

            agendamentoRepositoryMock.Setup(repo => repo.ListarAgendamentosAsync(idProduto)).ReturnsAsync(listaAgendamentos);

            var result = await service.ListarAgendamentosAsync(idProduto);

            result.Should().BeOfType<List<Agendamento>>();
        }
    }
}
