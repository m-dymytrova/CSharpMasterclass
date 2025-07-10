namespace GameDataParser.Exceptions;

public class ContentReaderException(string fileName, string fileContent, Exception innerException)
	: Exception("Invalid json", innerException)
{
	public string FileName { get; } = fileName;
	public string FileContent { get; } = fileContent;
}