using ChuckNorrisJokes.Client.Domain;

namespace ChuckNorrisJokes.Client;

public interface IJokeCache
{
    void AddJoke(ChuckNorrisJoke joke);

    ChuckNorrisJoke NextJoke();

    ChuckNorrisJoke PreviousJoke();
}

internal sealed class JokeCache : IJokeCache
{
    // TODO: Consider turning in to a dictionary for duplicate checks!
    // It's unlikely that we'll get a duplicate joke, since there are just _so many_ of them,
    // but it may be worth doing if there's time
    private readonly ICollection<ChuckNorrisJoke> m_Jokes;
    private int m_CurrentIndex;

    public JokeCache()
    {
        m_Jokes = new List<ChuckNorrisJoke>();
        m_CurrentIndex = 0;
    }

    public void AddJoke(ChuckNorrisJoke joke)
    {
        m_Jokes.Add(joke);
    }

    public ChuckNorrisJoke NextJoke()
    {
        m_CurrentIndex++;
        if (m_CurrentIndex >= m_Jokes.Count)
        {
            m_CurrentIndex = 0;
        }

        return m_Jokes.ElementAt(m_CurrentIndex);
    }

    public ChuckNorrisJoke PreviousJoke()
    {
        m_CurrentIndex--;
        if (m_CurrentIndex <= 0)
        {
            m_CurrentIndex = m_Jokes.Count - 1;
        }

        return m_Jokes.ElementAt(m_CurrentIndex);
    }
}