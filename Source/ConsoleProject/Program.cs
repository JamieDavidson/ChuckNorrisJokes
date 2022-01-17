// See https://aka.ms/new-console-template for more information

using ChuckNorrisJokes.Client;
using ChuckNorrisJokes.ConsoleProject;

var repository = new JokeRepository("https://api.chucknorris.io/");
var writer = new ConsoleWriter();
var cache = new JokeCache();

var firstJoke = repository.GetRandomJoke();
cache.AddJoke(firstJoke);
writer.WriteCurrentJoke(firstJoke, cache.CurrentIndex, cache.JokeCount);

while (true)
{
    var key = Console.ReadKey();

    switch (key.KeyChar)
    {
        case 'j':
            var joke = repository.GetRandomJoke();
            cache.AddJoke(joke);
            writer.WriteCurrentJoke(joke, cache.CurrentIndex, cache.JokeCount);
            break;
        case 'p':
            writer.WriteCurrentJoke(cache.PreviousJoke(), cache.CurrentIndex, cache.JokeCount);
            break;
        case 'n':
            writer.WriteCurrentJoke(cache.NextJoke(), cache.CurrentIndex, cache.JokeCount);
            break;
        default:
            // TODO: Decide on behaviour, I suppose display a message to the user?
            break;
    }
}