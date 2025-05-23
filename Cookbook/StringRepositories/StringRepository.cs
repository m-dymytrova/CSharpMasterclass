namespace Cookbook.StringRepositories;

public abstract class StringRepository : IStringRepository
{
	protected abstract List<string> TextToStrings(string fileContents);
	
	protected abstract string? StringsToText(List<string> strings);
	
	public List<string> Read(string filePath)
	{
		if (!File.Exists(filePath)) return [];
		var fileContents  = File.ReadAllText(filePath);
		return TextToStrings(fileContents);
	}


	public void Write(string filePath, List<string> strings)
	{
		File.WriteAllText(filePath, StringsToText(strings));
	}

}