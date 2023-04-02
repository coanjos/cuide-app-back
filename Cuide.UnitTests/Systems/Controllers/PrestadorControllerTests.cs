using Cuide.api.Controllers;
using Cuide.api.Domain.Models;
using Cuide.api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Cuide.UnitTests.Systems.Controllers
{
    public class PrestadorControllerTests
    {
        [Fact]
        public async Task Post_Sucesso_DevePersistir()
        {
            var prestador = new Prestador() { Id = 1, Nome = "doguinha" };

            var prestadorServiceMock = new Mock<IPrestadorService>();

            var controller = new PrestadorController(prestadorServiceMock.Object);

            var result = (CreatedResult)await controller.Post(prestador);

            prestadorServiceMock.Verify(service => service.PostPrestadorAsync(prestador), Times.Once());
            result.StatusCode.Should().Be(201);
        }

        [Fact]

        public async Task Get_Sucesso_DeveExecutarComSucesso()
        {
            var prestadorServiceMock = new Mock<IPrestadorService>();

            prestadorServiceMock.Setup(service => service.GetPrestadoresAsync())
                .ReturnsAsync(new List<Prestador>()
                {
                    new Prestador()
                    {
                        Id = 1,
                        Nome = "quixeramobinks"
                    }
                });

            var controller = new PrestadorController(prestadorServiceMock.Object);

            var result = (OkObjectResult)await controller.Get();

            result.StatusCode.Should().Be(200);

            prestadorServiceMock.Verify(service => service.GetPrestadoresAsync(), Times.Once());

            result.Value.Should().BeOfType<List<Prestador>>();
        }

        [Fact]

        public async Task Get_Erro_DeveRetornarNotFound()
        {
            var prestadorServiceMock = new Mock<IPrestadorService>();

            prestadorServiceMock.Setup(service => service.GetPrestadoresAsync())
                .ReturnsAsync(new List<Prestador>());

            var controller = new PrestadorController(prestadorServiceMock.Object);

            var result = (NotFoundResult)await controller.Get();

            result.StatusCode.Should().Be(404);
        }

        [Fact]

        public async Task GetId_Sucesso_DeveExecutarComSucesso()
        {
            int id = 1;

            var prestadorServiceMock = new Mock<IPrestadorService>();

            prestadorServiceMock.Setup(service => service.FindPrestadorAsync(id))
                .ReturnsAsync(new Prestador()
                {
                    Id = 1,
                    Nome = "quixeramobim"
                });

            var controller = new PrestadorController(prestadorServiceMock.Object);

            var result = (OkObjectResult)await controller.Get(id);

            result.StatusCode.Should().Be(200);

            prestadorServiceMock.Verify(service => service.FindPrestadorAsync(id), Times.Once());

            result.Value.Should().BeOfType<Prestador>();
        }

        [Fact]

        public async Task GetId_Erro_DeveRetornarNotFound()
        {
            int id = 1;

            var prestadorServiceMock = new Mock<IPrestadorService>();

            prestadorServiceMock.Setup(service => service.FindPrestadorAsync(id))
                .ReturnsAsync(null as Prestador);

            var controller = new PrestadorController(prestadorServiceMock.Object);

            var result = (NotFoundResult)await controller.Get(id);

            result.StatusCode.Should().Be(404);
        }

        [Fact]

        public async Task Put_Sucesso_DeveAtualizar()
        {
            var id = 1;
            var bodyToUpdate = new Prestador() { Id = 1, Nome = "quixeramobim" };

            var prestadorServiceMock = new Mock<IPrestadorService>();

            prestadorServiceMock.Setup(service => service.FindPrestadorAsync(id))
                .ReturnsAsync(new Prestador()
                {
                    Id = 1,
                    Nome = "quixeramobiiim"
                });

            var controller = new PrestadorController(prestadorServiceMock.Object);

            var result = (NoContentResult)await controller.Put(id, bodyToUpdate);

            prestadorServiceMock.Verify(service => service.UpdatePrestadorAsync(id, bodyToUpdate), Times.Once());

            result.StatusCode.Should().Be(204);
        }

        [Fact]

        public async Task Put_Erro_DeveDevolverBadRequest()
        {
            var id = 1;

            var bodyToUpdate = new Prestador() { Id = 1, Nome = "quixeramobim" };

            var prestadorServiceMock = new Mock<IPrestadorService>();

            prestadorServiceMock.Setup(service => service.FindPrestadorAsync(id))
                .ReturnsAsync(null as Prestador);

            var controller = new PrestadorController(prestadorServiceMock.Object);

            var result = (BadRequestResult)await controller.Put(id, bodyToUpdate);

            prestadorServiceMock.Verify(service => service.UpdatePrestadorAsync(id, bodyToUpdate), Times.Never());

            result.StatusCode.Should().Be(400);
        }

        [Fact]

        public async Task Delete_Sucesso_DeveDeletar()
        {
            var id = 1;

            var prestadorServiceMock = new Mock<IPrestadorService>();

            prestadorServiceMock.Setup(service => service.FindPrestadorAsync(id))
                .ReturnsAsync(new Prestador()
                {
                    Id = 1,
                    Nome = "quixeramobim"
                }
              );

            var controller = new PrestadorController(prestadorServiceMock.Object);

            var result = (OkResult)await controller.Delete(id);

            prestadorServiceMock.Verify(service => service.DeletePrestadorAsync(id), Times.Once());

            result.StatusCode.Should().Be(200);
        }

        [Fact]

        public async Task Delete_Erro_DeveDevolverBadRequest()
        {
            var id = 1;

            var prestadorServiceMock = new Mock<IPrestadorService>();

            prestadorServiceMock.Setup(service => service.FindPrestadorAsync(id))
                .ReturnsAsync(null as Prestador);

            var controller = new PrestadorController(prestadorServiceMock.Object);

            var result = (BadRequestResult)await controller.Delete(id);

            prestadorServiceMock.Verify(service => service.DeletePrestadorAsync(id), Times.Never());

            result.StatusCode.Should().Be(400);
        }
    }
}
