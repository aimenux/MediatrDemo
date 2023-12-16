namespace MediatrDemo.Application.Exceptions;

public sealed class NotFoundException : Exception
{
    private NotFoundException()
    {
    }

    private NotFoundException(string message) : base(message)
    {
    }

    private NotFoundException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public static NotFoundException PersonIsNotFound(string personId)
    {
        return new NotFoundException($"Person ({personId}) is not found.");
    }
}
