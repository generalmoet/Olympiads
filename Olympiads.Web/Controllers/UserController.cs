using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Olympiads.Core.Authorization.Login;
using Olympiads.Core.Authorization.Register;
using Olympiads.Core.Interfaces;
using Olympiads.Core.Providers;

namespace Olympiads.Web.Controllers;

[Route("[action]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IEntityDbContext _context;
    private readonly IJwtProvider _jwtProvider;

    public UserController(IJwtProvider jwtProvider, IEntityDbContext context)
    {
        _jwtProvider = jwtProvider;
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> LoginUser([FromBody] LoginRequest request)
    {
        var authProvider = new AuthenticationProvider(_context, _jwtProvider);
        var token = await authProvider.Login(request);

        return Ok(token);
    }

    [HttpPost]
    public async Task<IActionResult> RegisterUser([FromBody] RegisterRequest request)
    {
        var authProvider = new AuthenticationProvider(_context, _jwtProvider);
        var token = authProvider.Register(request);

        return Ok();
    }


    [HttpGet]
    [Authorize(Policy = "Administrator")]
    public async Task<IActionResult> CleanUpDb()
    {
        _context.Teams.RemoveRange(_context.Teams);
        _context.Olympiad.RemoveRange(_context.Olympiad);
        _context.QuestionAnswers.RemoveRange(_context.QuestionAnswers);
        _context.Questions.RemoveRange(_context.Questions);
        _context.StudentAnswers.RemoveRange(_context.StudentAnswers);
        _context.Students.RemoveRange(_context.Students);
        _context.Teachers.RemoveRange(_context.Teachers);

        await _context.SaveChangesAsync();

        return Ok();
    }
}
