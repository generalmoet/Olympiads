using Olympiads.Core.Models.Abstractions;

namespace Olympiads.Core.Interfaces;

public interface IJwtProvider
{
    string Generate(User user);
}
