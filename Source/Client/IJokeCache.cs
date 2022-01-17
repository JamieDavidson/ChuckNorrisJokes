using ChuckNorrisJokes.Client.Domain;

namespace ChuckNorrisJokes.Client;

public interface IJokeCache
{
    public int JokeCount { get; }

    public int CurrentIndex { get; }

    void AddJoke(ChuckNorrisJoke joke);

    ChuckNorrisJoke NextJoke();

    ChuckNorrisJoke PreviousJoke();
}