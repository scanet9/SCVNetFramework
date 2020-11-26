using System;
using System.Threading.Tasks;
using CosmosDBRestApi.BusinessLogic.Services.Interfaces;
using CosmosDBRestApi.DataLayer.DocumentModels.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CosmosDBRestApi.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserProvaAsync([FromBody] User user)
        {
            var result = await _userService.CreateUserProvaAsync(user);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync() => Ok(await _userService.GetAllAsync());

        [HttpGet("actives")]
        public async Task<IActionResult> GetActiveUsers() => Ok(await _userService.GetActiveUsers());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var user = await _userService.GetByIdAsync(id);

            if (user.Id != Guid.Empty)
                return Ok(user);

            return NotFound();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserProvaAsync(Guid id, [FromBody] User user)
        {
            var result = await _userService.UpdateUserProvaAsync(user);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserProvaAsync(Guid id)
        {
            var result = await _userService.DeleteUserProvaAsync(id);
            return Ok(result);
        }
    }
}
