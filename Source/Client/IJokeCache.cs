using ChuckNorrisJokes.Client.Domain;

namespace ChuckNorrisJokes.Client;

public interface IJokeCache
{
    void AddJoke(ChuckNorrisJoke joke);

    ChuckNorrisJoke NextJoke();

    ChuckNorrisJoke PreviousJoke();
}