using ChuckNorrisJokes.Client.Domain;

namespace ChuckNorrisJokes.Client;

public interface IJokeRepository
{
    ChuckNorrisJoke GetRandomJoke();
}