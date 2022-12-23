using Cuide.api.Domain.Models;
using Cuide.api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Cuide.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(User user)
        {
            await _userService.PostUserAsync(user);

            return Ok(user);
        } 

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _userService.GetUsersAsync();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _userService.FindUserAsync(id);

            if (result == null)
            {
                return NotFound();
            }            

            return Ok(result);            
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, User body)
        {
            var userExists = await _userService.FindUserAsync(id);

            if (userExists == null)
            {
                return BadRequest();
            }

            await _userService.UpdateUserAsync(id, body);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var userExists = await _userService.FindUserAsync(id);

            if (userExists == null)
            {
                return BadRequest();
            }

            await _userService.DeleteUserAsync(id);

            return Ok();
        }
    }
}
