using Cuide.api.Controllers;
using Cuide.api.Domain.Models;
using Cuide.api.Services;
using Cuide.api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Cuide.UnitTests.Systems.Controllers
{
    public class ServicoControllerTests
    {
        [Fact]
        public async Task Post_Sucesso_DevePersistir()
        {
            var servico = new Servico() { Id = 1, Nome = "lavar prato"};

            var servicoServiceMock = new Mock<IServicoService>();

            var controller = new ServicoController(servicoServiceMock.Object);

            var result = (CreatedResult)await controller.Post(servico);

            servicoServiceMock.Verify(service => service.PostServicoAsync(servico), Times.Once());
            result.StatusCode.Should().Be(201);
        }

        [Fact]
        public async Task Get_Sucesso_DeveExecutarComSucesso()
        {
            var servicoServiceMock = new Mock<IServicoService>();

            servicoServiceMock.Setup(service => service.GetServicosAsync())
                .ReturnsAsync(new List<Servico>()
                {
                    new Servico() 
                    { 
                        Id = 1,
                        Nome = "quixeramobinks"
                    }
                });

            var controller = new ServicoController(servicoServiceMock.Object);

            var result = (OkObjectResult)await controller.Get();

            result.StatusCode.Should().Be(200);

            servicoServiceMock.Verify(service => service.GetServicosAsync(), Times.Once());

            result.Value.Should().BeOfType<List<Servico>>();
        }

        [Fact]
        public async Task Get_Erro_DeveRetornarNotFound() 
        {
            var servicosServiceMock = new Mock<IServicoService>();

            servicosServiceMock.Setup(service => service.GetServicosAsync())
                .ReturnsAsync(new List<Servico>());

            var controller = new ServicoController(servicosServiceMock.Object);

            var result = (NotFoundResult)await controller.Get();

            result.StatusCode.Should().Be(404);
        }

        [Fact]

        public async Task GetId_Sucesso_DeveExecutarComSucesso()
        {   
            int id = 1;

            var servicoServiceMock = new Mock<IServicoService>();

            servicoServiceMock.Setup(service => service.FindServicoAsync(id))
                .ReturnsAsync(new Servico()
                {
                    Id = 1,
                    Nome = "quixeramobim"
                });

            var controller = new ServicoController(servicoServiceMock.Object);

            var result = (OkObjectResult)await controller.Get(id);

            result.StatusCode.Should().Be(200);

            servicoServiceMock.Verify(service => service.FindServicoAsync(id), Times.Once());

            result.Value.Should().BeOfType<Servico>();
        }

        [Fact]
        public async Task GetId_Erro_DeveRetornarNotFound()
        {
            int id = 1;

            var servicoServiceMock = new Mock<IServicoService>();

            servicoServiceMock.Setup(service => service.FindServicoAsync(id))
                .ReturnsAsync(null as Servico);

            var controller = new ServicoController(servicoServiceMock.Object);

            var result = (NotFoundResult)await controller.Get(id);

            result.StatusCode.Should().Be(404);
        }

        [Fact]
        public async Task Put_Sucesso_DeveAtualizar()
        {
            var id = 1;
            var bodyToUpdate = new Servico() { Id = 1, Nome = "quixeramobim" };

            var servicoServiceMock = new Mock<IServicoService>();

            servicoServiceMock.Setup(service => service.FindServicoAsync(id))
                .ReturnsAsync(new Servico()
                {
                    Id = 1,
                    Nome = "quixeramobiiim"
                });

            var controller = new ServicoController(servicoServiceMock.Object);

            var result = (NoContentResult) await controller.Put(id, bodyToUpdate);

            servicoServiceMock.Verify(service => service.UpdateServicoAsync(id, bodyToUpdate), Times.Once());

            result.StatusCode.Should().Be(204);
        }

        [Fact]
        public async Task Put_Erro_DeveDevolverBadRequest()
        {
            var id = 1;

            var bodyToUpdate = new Servico() { Id = 1, Nome = "quixeramobim" };

            var servicoServiceMock = new Mock<IServicoService>();

            servicoServiceMock.Setup(service => service.FindServicoAsync(id))
                .ReturnsAsync(null as Servico);

            var controller = new ServicoController(servicoServiceMock.Object);

            var result = (BadRequestResult)await controller.Put(id, bodyToUpdate);

            servicoServiceMock.Verify(service => service.UpdateServicoAsync(id, bodyToUpdate), Times.Never());

            result.StatusCode.Should().Be(400);
        }

        [Fact]
        public async Task Delete_Sucesso_DeveDeletar()
        {
            var id = 1;

            var servicoServiceMock = new Mock<IServicoService>();

            servicoServiceMock.Setup(service => service.FindServicoAsync(id))
                .ReturnsAsync(new Servico() 
                { 
                    Id = 1,
                    Nome = "quixeramobim"
                }
              );

            var controller = new ServicoController(servicoServiceMock.Object);

            var result = (OkResult)await controller.Delete(id);

            servicoServiceMock.Verify(service => service.DeleteServicoAsync(id), Times.Once());

            result.StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task Delete_Erro_DeveDevolverBadRequest()
        {
            var id = 1;

            var servicoServiceMock = new Mock<IServicoService>();

            servicoServiceMock.Setup(service => service.FindServicoAsync(id))
                .ReturnsAsync(null as Servico);

            var controller = new ServicoController(servicoServiceMock.Object);

            var result = (BadRequestResult) await controller.Delete(id);

            servicoServiceMock.Verify(service => service.DeleteServicoAsync(id), Times.Never());

            result.StatusCode.Should().Be(400);
        }
    }
}
