using ChuckNorrisJokes.Client.Domain;

namespace ChuckNorrisJokes.ConsoleProject;

public interface IJokeWriter
{
    /// <summary>
    /// Displays current joke and other relevant information to the user
    /// </summary>
    /// <param name="currentJoke">Current joke to display</param>
    void WriteCurrentJoke(ChuckNorrisJoke currentJoke);
}