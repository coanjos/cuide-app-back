
using Cuide.api.Controllers;
using Cuide.api.Domain.Models;
using Cuide.api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Cuide.UnitTests.Systems.Controllers
{
    public class UserControllerTests
    {
        [Fact]
        public async Task Post_Sucesso_DevePersistir()
        {
            var user = new User() { Id = 1, Nome = "Doguinha", Email = "doguinha@doguinha.com" };

            var userServiceMock = new Mock<IUserService>();

            var controller = new UserController(userServiceMock.Object);

            var result = (CreatedResult)await controller.Post(user);

            userServiceMock.Verify(s => s.PostUserAsync(user), Times.Once());
            result.StatusCode.Should().Be(201);
        }

        [Fact]
        public async Task Get_Sucesso_DeveExecutarComSucesso()
        {
            var userServiceMock = new Mock<IUserService>();
            userServiceMock.Setup(s => s.GetUsersAsync())
                .ReturnsAsync(new List<User>()
                {
                    new User()
                    {
                        Id = 1,
                        Nome = "Doguinha",
                        Email = "doguinha@doguinha.com"
                    }
                });

            var controller = new UserController(userServiceMock.Object);

            var result = (OkObjectResult)await controller.Get();

            result.StatusCode.Should().Be(200);
            userServiceMock.Verify(service => service.GetUsersAsync(), Times.Once());
            result.Value.Should().BeOfType<List<User>>();
        }

        [Fact]
        public async Task Get_Erro_DeveRetornarNotFound()
        {
            var userServiceMock = new Mock<IUserService>();
            userServiceMock.Setup(s => s.GetUsersAsync())
                .ReturnsAsync(new List<User>());


            var controller = new UserController(userServiceMock.Object);

            var result = (NotFoundResult)await controller.Get();

            result.StatusCode.Should().Be(404);
        }

        [Fact]
        public async Task GetId_Sucesso_DeveExecutarComSucesso()
        {
            int id = 1;

            var userServiceMock = new Mock<IUserService>();
            userServiceMock.Setup(s => s.FindUserAsync(id))
                .ReturnsAsync(new User()
                {
                    Id = 1,
                    Nome = "Doguinha",
                    Email = "doguinha@doguinha.com"
                }
                );

            var controller = new UserController(userServiceMock.Object);

            var result = (OkObjectResult)await controller.Get(id);

            result.StatusCode.Should().Be(200);
            userServiceMock.Verify(service => service.FindUserAsync(id), Times.Once());
            result.Value.Should().BeOfType<User>();
        }

        [Fact]
        public async Task GetId_Erro_DeveRetornarNotFound()
        {
            int id = 1;

            var userServiceMock = new Mock<IUserService>();
            userServiceMock.Setup(s => s.FindUserAsync(id))
                .ReturnsAsync(null as User);

            var controller = new UserController(userServiceMock.Object);

            var result = (NotFoundResult)await controller.Get(id);

            result.StatusCode.Should().Be(404);
        }

        [Fact]
        public async Task Put_Sucesso_DeveAtualizar()
        {
            var id = 1;

            var bodyToUpdate = new User() { Id = 1, Nome = "Doguinha Mais Atual", Email = "doguinha@doguinha.com" };

            var userServiceMock = new Mock<IUserService>();

            userServiceMock.Setup(s => s.FindUserAsync(id))
                .ReturnsAsync(new User()
                {
                    Id = 1,
                    Nome = "Doguinha",
                    Email = "doguinha@doguinha.com"
                }
               );

            var controller = new UserController(userServiceMock.Object);

            var result = (NoContentResult)await controller.Put(id, bodyToUpdate);

            userServiceMock.Verify(s => s.UpdateUserAsync(id, bodyToUpdate), Times.Once());
            result.StatusCode.Should().Be(204);
        }

        [Fact]
        public async Task Put_Erro_DeveDevolverBadRequest()
        {
            var id = 1;

            var bodyToUpdate = new User() { Id = 1, Nome = "Doguinha Mais Atual", Email = "doguinha@doguinha.com" };

            var userServiceMock = new Mock<IUserService>();

            userServiceMock.Setup(s => s.FindUserAsync(id))
                .ReturnsAsync(null as User);

            var controller = new UserController(userServiceMock.Object);

            var result = (BadRequestResult) await controller.Put(id, bodyToUpdate);

            userServiceMock.Verify(s => s.UpdateUserAsync(id, bodyToUpdate), Times.Never());
            result.StatusCode.Should().Be(400);
        }

        [Fact]
        public async Task Delete_Sucesso_DeveDeletar()
        {
            var id = 1;            

            var userServiceMock = new Mock<IUserService>();

            userServiceMock.Setup(s => s.FindUserAsync(id))
                .ReturnsAsync(new User()
                {
                    Id = 1,
                    Nome = "Doguinha",
                    Email = "doguinha@doguinha.com"
                }
               );

            var controller = new UserController(userServiceMock.Object);

            var result = (OkResult) await controller.Delete(id);

            userServiceMock.Verify(s => s.DeleteUserAsync(id), Times.Once());
            result.StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task Delete_Erro_DeveDevolverBadRequest()
        {
            var id = 1;

            var userServiceMock = new Mock<IUserService>();

            userServiceMock.Setup(s => s.FindUserAsync(id))
                .ReturnsAsync(null as User);

            var controller = new UserController(userServiceMock.Object);

            var result = (BadRequestResult) await controller.Delete(id);

            userServiceMock.Verify(s => s.DeleteUserAsync(id), Times.Never());
            result.StatusCode.Should().Be(400);
        }
    }
}
