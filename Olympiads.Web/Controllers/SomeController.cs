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
        public async Task<ActionResult> CreateUser([FromBody] Student user)
        {
            var userForAdding = new Student(user.FirstName, user.LastName, user.Surname, user.City, user.SchoolClass, user.School, user.Email, user.Password, user.PhoneNumber, user.Birthday);

            _context.Students.Add(userForAdding);
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
