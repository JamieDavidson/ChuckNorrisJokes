using ChuckNorrisJokes.Client.Domain;
using ChuckNorrisJokes.Client.Exceptions;

namespace ChuckNorrisJokes.Client;

public interface IJokeRepository
{
    /// <summary>
    /// Gets a random Chuck Norris Joke
    /// </summary>
    /// <exception cref="JokeRepositoryFailureException">
    /// Failed to retrieve joke
    /// </exception>
    Task<ChuckNorrisJoke> GetRandomJoke();
}