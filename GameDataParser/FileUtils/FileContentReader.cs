using System.Text.Json;
using GameDataParser.Games;
using GameDataParser.Exceptions;

namespace GameDataParser.FileUtils;

public static class FileContentReader
{

	public static List<Game> ReadGamesFromFile(string fileName)
	{
		string filePath = null;
		string jsonContent = null;
		
		try
		{
			filePath = ProjectPaths.GetDataFilePath(fileName);
			jsonContent = File.ReadAllText(filePath);
			return JsonSerializer.Deserialize<List<Game>>(jsonContent);
		}
		catch (Exception ex)
		{
			throw new ContentReaderException(fileName, jsonContent, ex);
		}
	}
}