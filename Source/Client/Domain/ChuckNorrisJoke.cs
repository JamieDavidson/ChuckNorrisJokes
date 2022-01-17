namespace ChuckNorrisJokes.Client.Domain;

public record ChuckNorrisJoke(string Value)
{
    public string Value { get; } = Value ?? throw new ArgumentNullException(nameof(Value));
}