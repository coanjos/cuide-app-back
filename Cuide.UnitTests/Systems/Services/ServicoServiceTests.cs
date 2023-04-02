using Cuide.api.Domain.Models;
using Cuide.api.Services;
using Cuide.api.Repositories;
using Cuide.api.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;


namespace Cuide.UnitTests.Systems.Services
{
    public class ServicoServiceTests
    {
        [Fact]
        public async Task Post_Sucesso_DevePersistir()
        {
            var servico = new Servico() { Id = 1, Nome = "Unhas" };

            var servicoRepositoryMock = new Mock<IServicoRepository>();

            var service = new ServicoService(servicoRepositoryMock.Object);

            await service.PostServicoAsync(servico);

            servicoRepositoryMock.Verify(repository => repository.PostServicoAsync(servico), Times.Once());
        }

        [Fact]
        public async Task Get_Sucesso_DeveExecutarComSucesso()
        {
            var servicoRepositoryMock = new Mock<IServicoRepository>();

            servicoRepositoryMock.Setup(repository => repository.GetServicosAsync())
                .ReturnsAsync(new List<Servico>()
                {
                    new Servico()
                    {
                        Id = 1,
                        Nome = "Unhas"
                    }
                });

            var service = new ServicoService(servicoRepositoryMock.Object);

            var result = await service.GetServicosAsync();

            servicoRepositoryMock.Verify(repository => repository.GetServicosAsync(), Times.Once());

            result.Should().BeOfType<List<Servico>>();
        }

        [Fact]
        public async Task FindServico_Sucesso_DeveExecutarComSucesso()
        {
            int id = 1;

            var servicoRepositoryMock = new Mock<IServicoRepository>();

            servicoRepositoryMock.Setup(repository => repository.FindServicoAsync(id))
                .ReturnsAsync(new Servico()
                {
                    Id = 1,
                    Nome = "Unhas"
                });

            var service = new ServicoService(servicoRepositoryMock.Object);

            var result = await service.FindServicoAsync(id);            

            servicoRepositoryMock.Verify(repository => repository.FindServicoAsync(id), Times.Once());

            result.Should().BeOfType<Servico>();
        }

        [Fact]
        public async Task UpdateServico_Sucesso_DeveAtualizar()
        {
            var id = 1;
            var bodyToUpdate = new Servico() { Id = 1, Nome = "Cabelo" };

            var servicoRepositoryMock = new Mock<IServicoRepository>();

            servicoRepositoryMock.Setup(repository => repository.FindServicoAsync(id))
                .ReturnsAsync(new Servico()
                {
                    Id = 1,
                    Nome = "Unhas"
                });

            var service = new ServicoService(servicoRepositoryMock.Object);

            await service.UpdateServicoAsync(id, bodyToUpdate);

            servicoRepositoryMock.Verify(repository => repository.UpdateServicoAsync(id, bodyToUpdate), Times.Once());            
        }

        [Fact]
        public async Task DeleteServico_Sucesso_DeveDeletar()
        {
            var id = 1;

            var servicoRepositoryMock = new Mock<IServicoRepository>();

            servicoRepositoryMock.Setup(repository => repository.FindServicoAsync(id))
                .ReturnsAsync(new Servico()
                {
                    Id = 1,
                    Nome = "Unhas"
                }
              );

            var service = new ServicoService(servicoRepositoryMock.Object);

            await service.DeleteServicoAsync(id);

            servicoRepositoryMock.Verify(repository => repository.DeleteServicoAsync(id), Times.Once());
        }
    }
}
