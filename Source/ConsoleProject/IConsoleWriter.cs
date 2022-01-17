using ChuckNorrisJokes.Client.Domain;

namespace ChuckNorrisJokes.ConsoleProject;

public interface IConsoleWriter
{
    void WriteCurrentJoke(ChuckNorrisJoke currentJoke);
}