namespace Olympiads.Core.Exceptions;

public class EntityNotFoundExpection : Exception
{
    public EntityNotFoundExpection()
    {
    }

    public EntityNotFoundExpection(string? message) : base(message)
    {
    }

    public EntityNotFoundExpection(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
