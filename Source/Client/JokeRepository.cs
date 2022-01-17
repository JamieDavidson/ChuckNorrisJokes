using System.Net.Http.Json;
using ChuckNorrisJokes.Client.Domain;

namespace ChuckNorrisJokes.Client;

public class JokeRepository : IJokeRepository
{
    private readonly string m_ApiBaseAddress;

    public JokeRepository(string apiBaseAddress)
    {
        m_ApiBaseAddress = apiBaseAddress ?? throw new ArgumentNullException(nameof(apiBaseAddress));
    }

    public ChuckNorrisJoke GetRandomJoke()
    {
        // Personal preference: I know it's recommended to reuse http clients because of fear of
        // socket exhaustion... but I've never once run in to it even in extremely high use applications
        //
        using var client = CreateHttpClient();


        // TODO: Handle failed requests, bad responses etc
        // TODO: Probably make this async, that might be something they'll look at?
        return client.GetFromJsonAsync<ChuckNorrisJoke>("/jokes/random").Result;
    }

    private HttpClient CreateHttpClient()
    {
        return new HttpClient
        {
            BaseAddress = new Uri(m_ApiBaseAddress)
        };
    }
}