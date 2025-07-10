using GameDataParser.Games;

namespace GameDataParser.FileUtils;

public static class GamePrinter
{
	public static void Print(List<Game> games)
	{
		Console.WriteLine("Loaded games are:");
		foreach (var game in games)
		{
			Console.WriteLine($"{game.Title}, released in {game.ReleaseYear}, rating: {game.Rating}");
		}
	}
}