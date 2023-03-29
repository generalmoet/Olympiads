using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Olympiads.Core.Authorization.Login;
using Olympiads.Core.Authorization.Register;
using Olympiads.Core.Interfaces;
using Olympiads.Core.Providers;
using System.Security.Claims;

namespace Olympiads.Web.Controllers;

[Route("[action]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IEntityDbContext _context;
    private readonly IJwtProvider _jwtProvider;
    private readonly IConfiguration _configuration;

    public UserController(IJwtProvider jwtProvider, IEntityDbContext context, IConfiguration configuration)
    {
        _jwtProvider = jwtProvider;
        _context = context;
        _configuration = configuration;
    }

    [HttpPost]
    public async Task<IActionResult> LoginUser([FromBody] LoginRequest request)
    {
        var authProvider = new AuthenticationProvider(_context, _jwtProvider);
        var token = await authProvider.Login(request);
        bool isAdmin = _configuration.GetSection("Admins").AsEnumerable().Any(str => str.Value == request.Email);

        return Ok(new { token, isAdmin });
    }

    [HttpPost]
    public async Task<IActionResult> RegisterUser([FromBody] RegisterRequest request)
    {
        var authProvider = new AuthenticationProvider(_context, _jwtProvider);
        await authProvider.Register(request);
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
        _context.UserAnswers.RemoveRange(_context.UserAnswers);
        _context.Users.RemoveRange(_context.Users);

        await _context.SaveChangesAsync();

        return Ok();
    }
}
