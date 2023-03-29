using Olympiads.Core.Models;

namespace Olympiads.Core.Interfaces;

public interface IJwtProvider
{
    string Generate(User user);
}
