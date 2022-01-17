// See https://aka.ms/new-console-template for more information

using ChuckNorrisJokes.Client;
using ChuckNorrisJokes.ConsoleProject;

void GetRandomJoke(IJokeRepository jokeRepository, IJokeCache jokeCache, IJokeWriter consoleJokeWriter)
{
    var joke = jokeRepository.GetRandomJoke().Result;
    jokeCache.AddJoke(joke);
    consoleJokeWriter.WriteCurrentJoke(joke);
}

const string apiUrl = "https://api.chucknorris.io/";

var repository = new JokeRepository(apiUrl);
var cache = new JokeCache();
var writer = new ConsoleJokeWriter(cache);

GetRandomJoke(repository, cache, writer);

while (true)
{
    var key = Console.ReadKey();

    // Cheeky hack - Overwrite last character written in the console by moving caret back, writing empty space and
    // then moving caret back again
    // Seeing the "j" written in the console while waiting for network responses was annoying me!
    //
    Console.Write("\b \b");

    // Classic dilemma, casing of user input! I think I'll rely on user input being lower case, as we have a concise
    // set of instructions being displayed every repaint, although it would be nice to tell the user what was wrong,
    // since 'J' does not equal 'j'
    switch (key.KeyChar)
    {
        case 'j':
            GetRandomJoke(repository, cache, writer);
            break;
        case 'p':
            writer.WriteCurrentJoke(cache.PreviousJoke());
            break;
        case 'n':
            writer.WriteCurrentJoke(cache.NextJoke());
            break;
        default:
            // Decided to do nothing here, as with the cheeky hack above this behaviour
            // results in what _looks_ like a no-op to the user, and personally I think that
            // looks ok, however I've left the default branch here because I think it's important
            // to explicitly call out that I've thought about it and decided to do nothing
            break;
    }
}