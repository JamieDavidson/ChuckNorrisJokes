using ChuckNorrisJokes.Client.Domain;

namespace ChuckNorrisJokes.Client;

public sealed class JokeCache : IJokeCache
{
    // TODO: Consider turning in to a dictionary for duplicate checks!
    // It's unlikely that we'll get a duplicate joke, since there are just _so many_ of them,
    // but it may be worth doing if there's time
    private readonly ICollection<ChuckNorrisJoke> m_Jokes;
    public int CurrentIndex { get; private set; }
    public int JokeCount => m_Jokes.Count;

    public JokeCache()
    {
        m_Jokes = new List<ChuckNorrisJoke>();
        CurrentIndex = 0;
    }

    public void AddJoke(ChuckNorrisJoke joke)
    {
        m_Jokes.Add(joke);
        CurrentIndex = m_Jokes.Count - 1;
    }

    public ChuckNorrisJoke NextJoke()
    {
        CurrentIndex++;
        if (CurrentIndex >= m_Jokes.Count)
        {
            CurrentIndex = 0;
        }

        return m_Jokes.ElementAt(CurrentIndex);
    }

    public ChuckNorrisJoke PreviousJoke()
    {
        CurrentIndex--;
        if (CurrentIndex < 0)
        {
            CurrentIndex = m_Jokes.Count - 1;
        }

        return m_Jokes.ElementAt(CurrentIndex);
    }
}