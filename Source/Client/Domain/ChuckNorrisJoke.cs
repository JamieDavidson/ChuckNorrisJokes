namespace ChuckNorrisJokes.Client.Domain;

public class ChuckNorrisJoke
{
    public string Value { get; }

    public ChuckNorrisJoke(string value)
    {
        Value = value ?? throw new ArgumentNullException(nameof(value));
    }
}