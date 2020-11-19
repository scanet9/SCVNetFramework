using System;
using System.Threading.Tasks;
using CosmosDBRestApi.DataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CosmosDBRestApi.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private DbContext _context { get; set; }
        private DataLayer.Infrastructure.Interfaces.IUnitOfWork _uow;

        public UserController(DbContext context, DataLayer.Infrastructure.Interfaces.IUnitOfWork uow)
        {
            _context = context;
            _uow = uow;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserProva([FromBody] User user)
        {
            var entityEntry = await _uow.GetRepository<User>().CreateAsync(user);
            await _uow.SaveChangesAsync();
            return Ok(entityEntry);
        }
    }
}
