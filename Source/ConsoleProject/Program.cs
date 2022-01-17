// See https://aka.ms/new-console-template for more information

using ChuckNorrisJokes.Client;
using ChuckNorrisJokes.ConsoleProject;

var repository = new JokeRepository("https://api.chucknorris.io/");
var writer = new ConsoleWriter();

writer.WriteCurrentJoke(repository.GetRandomJoke());

while (true)
{
    // TODO: Read individual key, j = new joke, p = previous joke, n = next joke in cache
    Console.ReadKey();
    writer.WriteCurrentJoke(repository.GetRandomJoke());
}