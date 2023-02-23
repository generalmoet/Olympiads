using Microsoft.AspNetCore.Mvc;
using Olympiads.Core.Interfaces;
using Olympiads.Core.Models;

namespace Olympiads.Web.Controllers
{
    [ApiController]
    [Route("[action]")]
    public class SomeController : ControllerBase
    {
        private readonly IEntityDbContext _context;

        public SomeController(IEntityDbContext context)
        {
            _context= context;
        }

        [HttpPost]
        public async Task<ActionResult> CreateUser([FromBody] User user)
        {
            var userForAdding = new User()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Password = user.Password,
                PhoneNumber = user.PhoneNumber
            };

            _context.Users.Add(userForAdding);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> CreateOlympiad([FromBody] Olympiad olympiad)
        {
            var olympiadForAdding = new Olympiad()
            {
                Name = olympiad.Name,
                Description= olympiad.Description,
                StartTime= olympiad.StartTime,
                EndTime= olympiad.EndTime,
                StartRegistrationTime= olympiad.StartRegistrationTime,
                EndRegistrationTime= olympiad.EndRegistrationTime
            };

            _context.Olympiad.Add(olympiadForAdding);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
