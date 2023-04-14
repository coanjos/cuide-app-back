using Cuide.api.Services;
using Cuide.api.Domain.Models;
using Cuide.api.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Cuide.api.Controllers;
using Cuide.api.Services.Interfaces;

namespace Cuide.UnitTests.Systems.Services
{
    public class UserServiceTests
    {
        [Fact]

        public async Task Post_Sucesso_DevePersistir()
        {
            var user = new User() { Id = 1, Email = "doguinha@doguinha", Nome = "doguinha" };
            var userRepositoryMock = new Mock<IUserRepository>();
            var service = new UserService(userRepositoryMock.Object);
            await service.PostUserAsync(user);
            userRepositoryMock.Verify(repository => repository.PostUserAsync(user), Times.Once());
        }

        [Fact]

        public async Task Get_Sucesso_DeveListar()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(service => service.GetUsersAsync())
                .ReturnsAsync(new List<User>()
                {
                    new User()
                    {
                        Id = 1, 
                        Email = "doguinha@doguinha", 
                        Nome = "doguinha"
                    }
                });
            var service = new UserService(userRepositoryMock.Object);
            var result = await service.GetUsersAsync();
            userRepositoryMock.Verify(service => service.GetUsersAsync(), Times.Once());
        }
        [Fact]
        public async Task GetId_Sucesso_DeveExecutarComSucesso()
        {
            int id = 1;

            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(s => s.FindUserAsync(id))
                .ReturnsAsync(new User()
                {
                    Id = 1,
                    Email = "doguinha@doguinha",
                    Nome = "doguinha"
                });

            var service = new UserService(userRepositoryMock.Object);

            var result = await service.FindUserAsync(id);

            userRepositoryMock.Verify(service => service.FindUserAsync(id), Times.Once());
            result.Should().BeOfType<User>();
        }


        [Fact]
        public async Task UpdateUser_Sucesso_DeveAtualizar()
        {
            var id = 1;
            var bodyToUpdate = new User() { Id = 1, Nome = "doguinha", Email = "viraaiparça@gmail.com" };

            var userRepositoryMock = new Mock<IUserRepository>();

            userRepositoryMock.Setup(repository => repository.FindUserAsync(id))
                .ReturnsAsync(new User()
                {
                    Id = 1,
                    Nome = "doguinha",
                    Email = "doguinha@doguinha",
                });

            var service = new UserService(userRepositoryMock.Object);

            await service.UpdateUserAsync(id, bodyToUpdate);

            userRepositoryMock.Verify(repository => repository.UpdateUserAsync(id, bodyToUpdate), Times.Once());
        }

        [Fact]
        public async Task DeleteUser_Sucesso_DeveDeletar()
        {
            var id = 1;

            var userRepositoryMock = new Mock<IUserRepository>();

            userRepositoryMock.Setup(repository => repository.FindUserAsync(id))
                .ReturnsAsync(new User()
                {
                    Id = 1,
                    Nome = "Unhas"
                }
              );

            var service = new UserService(userRepositoryMock.Object);

            await service.DeleteUserAsync(id);

            userRepositoryMock.Verify(repository => repository.DeleteUserAsync(id), Times.Once());
        }
    }
}
