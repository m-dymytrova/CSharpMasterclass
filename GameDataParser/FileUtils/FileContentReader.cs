using System.Text.Json;
using GameDataParser.Games;

namespace GameDataParser.FileUtils;

public static class FileContentReader
{
	public static List<Game> ReadGamesFromFile(string fileName)
	{
		string filePath = Path.Combine(ProjectPaths.DataDirectory, fileName);
		string jsonContent = File.ReadAllText(filePath);
		// cannot Deserialize interface, should have class?
		return JsonSerializer.Deserialize<List<Game>>(jsonContent);
	}
}