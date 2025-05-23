using System.Text.Json;

namespace Cookbook.StringRepositories;

public class StringJsonRepository : StringRepository
{
	protected override List<string> TextToStrings(string fileContents)
	{
		return JsonSerializer.Deserialize<List<string>>(fileContents);
	}

	protected override string? StringsToText(List<string> strings)
	{
		return JsonSerializer.Serialize(strings);
	}
}