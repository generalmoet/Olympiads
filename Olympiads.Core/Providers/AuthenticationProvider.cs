using Olympiads.Core.Authorization.Register;
using Olympiads.Core.Models;
using Olympiads.Core.Interfaces;
using Olympiads.Core.Authorization.Login;
using Olympiads.Core.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Olympiads.Core.Providers;

public class AuthenticationProvider
{
    private readonly IEntityDbContext _context;

    private readonly IJwtProvider _jwtProvider;
    public AuthenticationProvider(IEntityDbContext context, IJwtProvider jwtProvider)
    {
        _context = context;
        _jwtProvider = jwtProvider;
    }

    public async Task Register(RegisterRequest request)
    {
        var team = new Team();
        if (_context.Teams.Count() > 0)
        {
            team = _context.Teams.Where(team => team.Name == request.TeamName && team.City == request.City).First();
        }

        if (team is null || _context.Teams.Count() == 0)
        {
            team = new Team(request.TeamName, request.City, new List<User>());
            _context.Teams.Add(team);
            await _context.SaveChangesAsync();
        }

        var user = new User()
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Surname = request.Surname,
            City = request.City,
            SchoolClass = request.SchoolClass,
            School = request.School,
            Email = request.Email,
            Birthday = request.Birthday,
            PhoneNumber = request.PhoneNumber,
            Password = request.Password,
            TeacherName = request.TeacherName,
            TeacherPhone = request.TeacherPhone,
            TeacherPost = request.TeacherPost
        };

        team = await _context.Teams.Include(team => team.Users).Where(team => team.Name == request.TeamName).FirstOrDefaultAsync();
        team.Users.Add(user);

        await _context.SaveChangesAsync();
    }

    public async Task<string> Login(LoginRequest request)
    {
        var user = _context.Users.Where(user => user.Email == request.Email).FirstOrDefault();

        if (user is null) throw new AuthenticationException("Incorrect login or password");
        if (request.Password != user.Password) throw new AuthenticationException("Incorrect login or password");

        string token = _jwtProvider.Generate(user);

        return token;
    }
}