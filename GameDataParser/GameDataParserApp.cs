using GameDataParser.FileUtils;
using GameDataParser.Games;

namespace GameDataParser;

public class GameDataParserApp
{
	public void Run()
	{
		string fileName = "";

		// Entering the file name by the user
		while (string.IsNullOrEmpty(fileName))
		{
			Console.WriteLine("Enter the name of the file you want to read:");
			var userInput = Console.ReadLine();
			fileName = FileNameReader.GetFileNameFromUserInput(userInput);
		}
		
		// Reading the data from the JSON file
		List<Game> games = FileContentReader.ReadGamesFromFile(fileName);
		
		// Printing video games
		Console.WriteLine("Loaded games are:");
		foreach (var game in games)
		{
			Console.WriteLine($"{game.Title} ({game.ReleaseYear}) - Rating: {game.Rating}");
		}

	}
}