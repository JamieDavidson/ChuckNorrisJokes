// See https://aka.ms/new-console-template for more information

using ChuckNorrisJokes.Client;

var repository = new JokeRepository("https://api.chucknorris.io/");

Console.WriteLine(repository.GetRandomJoke().Value);

while (true)
{
    // TODO: Read individual key, j = new joke, p = previous joke, n = next joke in cache
    Console.ReadKey();
    Console.WriteLine(repository.GetRandomJoke().Value);
}