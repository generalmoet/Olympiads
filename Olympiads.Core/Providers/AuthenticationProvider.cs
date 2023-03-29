using Olympiads.Core.Authorization.Register;
using Olympiads.Core.Models;
using Olympiads.Core.Interfaces;
using Olympiads.Core.Authorization.Login;
using Olympiads.Core.Exceptions;

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
        var student = new User()
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
            Password = request.Password
        };

        _context.Users.Add(student);

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