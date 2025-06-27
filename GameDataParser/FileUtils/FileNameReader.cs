namespace GameDataParser.FileUtils
{
	public static class FileNameReader
	{
		public static string GetFileNameFromUserInput(string? userInput)
		{
			try
			{
				return GetFileName(userInput);
			}
			catch (ArgumentException ex)
			{
				Console.WriteLine(ex.Message);
				return "";
			}
		}

		private static string? GetFileName(string? userInput)
		{
			if (userInput is null)
			{
				throw new ArgumentException("File name cannot be null.");
			}

			if (userInput.Length <= 0)
			{
				throw new ArgumentException("File name cannot be empty.");
			}
			
			var fileNames = Directory.GetFiles(ProjectPaths.DataDirectory)
				.Select(Path.GetFileName);
			
			if (!fileNames.Contains(userInput + ".json", StringComparer.OrdinalIgnoreCase))
			{
				throw new ArgumentException("File not found.");
			}
			
			return userInput + ".json";
		}
		
	}
}