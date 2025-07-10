using GameDataParser.Exceptions;
using GameDataParser.FileUtils;
using GameDataParser.Games;

namespace GameDataParser;

public class GameDataParserApp
{
	public void Run()
	{
		string fileName = "";

		try
		{
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
			GamePrinter.Print(games);

			Console.WriteLine("Press any key to close.");
			Console.ReadKey();
		}
		catch (ContentReaderException ex)
		{
			// Log file reading exception
			ExceptionLogger.Log(ex);
		}
		catch (Exception ex)
		{
			ExceptionLogger.Log(ex);
		}
	}
}