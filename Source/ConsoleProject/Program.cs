// See https://aka.ms/new-console-template for more information

using ChuckNorrisJokes.Client;
using ChuckNorrisJokes.ConsoleProject;

var repository = new JokeRepository("https://api.chucknorris.io/");
var cache = new JokeCache();
var writer = new ConsoleJokeWriter(cache);

var firstJoke = repository.GetRandomJoke();
cache.AddJoke(firstJoke);
writer.WriteCurrentJoke(firstJoke);

while (true)
{
    var key = Console.ReadKey();

    // Cheeky hack - Overwrite last character written in the console
    // Seeing the "j" written in the console was annoying me!
    Console.Write("\b \b");
    switch (key.KeyChar)
    {
        case 'j':
            var joke = repository.GetRandomJoke();
            cache.AddJoke(joke);
            writer.WriteCurrentJoke(joke);
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