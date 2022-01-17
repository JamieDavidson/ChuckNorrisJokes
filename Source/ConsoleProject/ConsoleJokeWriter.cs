using ChuckNorrisJokes.Client;
using ChuckNorrisJokes.Client.Domain;

namespace ChuckNorrisJokes.ConsoleProject;

internal sealed class ConsoleJokeWriter : IJokeWriter
{
    private readonly IJokeCache m_JokeCache;

    public ConsoleJokeWriter(IJokeCache jokeCache)
    {
        m_JokeCache = jokeCache ?? throw new ArgumentNullException(nameof(jokeCache));
    }

    public void WriteCurrentJoke(ChuckNorrisJoke currentJoke)
    {
        Console.Clear();
        Console.WriteLine($"Joke {m_JokeCache.CurrentIndex + 1} of {m_JokeCache.JokeCount}{Environment.NewLine}");

        Console.WriteLine($"{currentJoke.Value}{Environment.NewLine}");

        Console.WriteLine($"j - Get a random joke{Environment.NewLine}" +
                          $"p - Go back to previous joke{Environment.NewLine}" +
                          "n - Go to next joke");
    }
}