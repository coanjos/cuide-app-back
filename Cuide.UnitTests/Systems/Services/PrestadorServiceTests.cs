using Cuide.api.Services;
using Cuide.api.Domain.Models;
using Cuide.api.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Cuide.api.Controllers;
using Cuide.api.Services.Interfaces;

namespace Cuide.UnitTests.Systems.Services
{
    public class PrestadorServiceTests
    {
        [Fact]
        public async Task Post_Sucesso_DevePersistir()
        {
            var prestador = new Prestador() { Id = 1, Nome = "doguinha" };
            var prestadorRepositoryMock = new Mock<IPrestadorRepository>();
            var servicoRepositoryMock = new Mock<IServicoRepository>();
            var service = new PrestadorService(prestadorRepositoryMock.Object, servicoRepositoryMock.Object);
            await service.PostPrestadorAsync(prestador);
            prestadorRepositoryMock.Verify(repository => repository.PostPrestadorAsync(prestador), Times.Once());
        }

        [Fact]
        public async Task Get_Sucesso_DeveListar()
        {
            var prestadorRepositoryMock = new Mock<IPrestadorRepository>();
            prestadorRepositoryMock.Setup(service => service.GetPrestadoresAsync())
                .ReturnsAsync(new List<Prestador>()
                {
                    new Prestador()
                    {
                        Id = 1,
                        Nome = "doguinha"
                    }
                });
            var servicoRepositoryMock = new Mock<IServicoRepository>();
            var service = new PrestadorService(prestadorRepositoryMock.Object, servicoRepositoryMock.Object);
            var result = await service.GetPrestadoresAsync();
            prestadorRepositoryMock.Verify(service => service.GetPrestadoresAsync(), Times.Once());
        }

        [Fact]
        public async Task GetId_Sucesso_DeveExecutarComSucesso()
        {
            int id = 1;

            var prestadorRepositoryMock = new Mock<IPrestadorRepository>();
            prestadorRepositoryMock.Setup(s => s.FindPrestadorAsync(id))
                .ReturnsAsync(new Prestador()
                {
                    Id = 1,
                    Nome = "doguinha"
                });

            var servicoRepositoryMock = new Mock<IServicoRepository>();
            var service = new PrestadorService(prestadorRepositoryMock.Object, servicoRepositoryMock.Object);

            var result = await service.FindPrestadorAsync(id);

            prestadorRepositoryMock.Verify(service => service.FindPrestadorAsync(id), Times.Once());
            result.Should().BeOfType<Prestador>();
        }


        [Fact]
        public async Task UpdatePrestador_Sucesso_DeveAtualizar()
        {
            var id = 1;
            var bodyToUpdate = new Prestador() { Id = 1, Nome = "doguinha2" };

            var prestadorRepositoryMock = new Mock<IPrestadorRepository>();

            prestadorRepositoryMock.Setup(repository => repository.FindPrestadorAsync(id))
                .ReturnsAsync(new Prestador()
                {
                    Id = 1,
                    Nome = "doguinha",
                });

            var servicoRepositoryMock = new Mock<IServicoRepository>();
            var service = new PrestadorService(prestadorRepositoryMock.Object, servicoRepositoryMock.Object);

            await service.UpdatePrestadorAsync(id, bodyToUpdate);

            prestadorRepositoryMock.Verify(repository => repository.UpdatePrestadorAsync(id, bodyToUpdate), Times.Once());
        }

        [Fact]
        public async Task DeletePrestador_Sucesso_DeveDeletar()
        {
            var id = 1;

            var prestadorRepositoryMock = new Mock<IPrestadorRepository>();

            prestadorRepositoryMock.Setup(repository => repository.FindPrestadorAsync(id))
                .ReturnsAsync(new Prestador()
                {
                    Id = 1,
                    Nome = "Unhas"
                }
              );

            var servicoRepositoryMock = new Mock<IServicoRepository>();
            var service = new PrestadorService(prestadorRepositoryMock.Object, servicoRepositoryMock.Object);

            await service.DeletePrestadorAsync(id);

            prestadorRepositoryMock.Verify(repository => repository.DeletePrestadorAsync(id), Times.Once());
        }
    }
}
