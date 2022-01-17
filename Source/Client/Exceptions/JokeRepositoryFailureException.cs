using System.Runtime.Serialization;

namespace ChuckNorrisJokes.Client.Exceptions;

public class JokeRepositoryFailureException : Exception
{
    public JokeRepositoryFailureException()
        : base("Failed to request joke")
    { }

    public JokeRepositoryFailureException(string? message)
        : base(message)
    { }

    public JokeRepositoryFailureException(string? message, Exception? innerException)
        : base(message, innerException)
    { }

    protected JokeRepositoryFailureException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    { }
}