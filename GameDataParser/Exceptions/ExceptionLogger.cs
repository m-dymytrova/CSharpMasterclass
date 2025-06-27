namespace GameDataParser.Exceptions;

public static class ExceptionLogger
{
	private static readonly string LogFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log.txt");
	public static void Log(Exception ex)
	{
		string message = "";
		
		if (ex.InnerException != null)
		{
			message = ex.InnerException.Message;
		}
		else
		{
			message = ex.Message;
		}
		string logEntry = $"""
		                   
		                   [{DateTime.Now}]
		                   Exception message: {message} // how to add file name from another exception?
		                   Stack trace: {ex.StackTrace}
		                   """;
		File.AppendAllText(LogFilePath, logEntry);
	}
	
	public static void Log(ContentReaderException ex)
	{
		Console.WriteLine($"JSON in the {ex.FileName} was not in a valid format. JSON body:");
		Console.ForegroundColor = ConsoleColor.Red;
		Console.WriteLine(ex.FileContent);
		Console.ResetColor();
		Console.WriteLine("Sorry! The application has experienced an unexpected error and will have to be closed.");
		Log((Exception)ex);
	}
}