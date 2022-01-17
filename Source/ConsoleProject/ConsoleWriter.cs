using ChuckNorrisJokes.Client.Domain;

namespace ChuckNorrisJokes.ConsoleProject;

internal sealed class ConsoleWriter : IConsoleWriter
{
    public void WriteCurrentJoke(ChuckNorrisJoke currentJoke)
    {
        Console.Clear();
        Console.WriteLine(currentJoke.Value);
    }
}