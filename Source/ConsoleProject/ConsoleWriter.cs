using ChuckNorrisJokes.Client.Domain;

namespace ChuckNorrisJokes.ConsoleProject;

internal sealed class ConsoleWriter : IConsoleWriter
{
    public void WriteCurrentJoke(ChuckNorrisJoke currentJoke, int currentIndex, int maxIndex)
    {
        Console.Clear();
        Console.WriteLine($"Joke {currentIndex + 1} of {maxIndex}{Environment.NewLine}");

        Console.WriteLine($"{currentJoke.Value}{Environment.NewLine}");

        Console.WriteLine($"j - Get a random joke{Environment.NewLine}" +
                          $"p - Go back to previous joke{Environment.NewLine}" +
                          $"n - Go to next joke{Environment.NewLine}");
    }
}