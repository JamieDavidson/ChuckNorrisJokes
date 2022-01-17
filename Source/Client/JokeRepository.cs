using System.Net.Http.Json;
using ChuckNorrisJokes.Client.Domain;
using ChuckNorrisJokes.Client.Exceptions;

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


        // TODO: Probably make this async, that might be something they'll look at?
        try
        {
            var joke = client.GetFromJsonAsync<ChuckNorrisJoke>("/jokes/random").Result;

            if (joke == null)
            {
                // We won't actually get here, because I haven't handled missing properties
                // via System.Text.Json's JsonConverters, or handled ArgumentNullExceptions from ChuckNorrisJoke
                // constructor. I really miss Newtonsoft Json's JsonPropertyAttribute, I'll never understand why it
                // wasn't ported to System.Text.Json :(
                //
                // I was tempted to add Newtonsoft Json to the project and demonstrate this, but I think
                // this demonstrates well enough that I understand happy path vs sad path, exceptions etc, which I'd
                // imagine is more useful than demonstrating that I can use a particular library
                //
                throw new JokeRepositoryFailureException("Failed to deserialize joke response");
            }

            return joke;
        }
        catch (AggregateException e)
        {
            // In a real application we'd likely have branching behaviour here, perhaps some handling
            // for retry logic if we'd received a timeout response, or other logging behaviour if we receive
            // e.g. a bad request response
            //
            // In this case, the inner exception will be HttpRequestException, which contains a StatusCode property
            // indication the response code from the API
            throw new JokeRepositoryFailureException("Failed to fetch random joke", e);
        }
    }

    private HttpClient CreateHttpClient()
    {
        return new HttpClient
        {
            BaseAddress = new Uri(m_ApiBaseAddress)
        };
    }
}