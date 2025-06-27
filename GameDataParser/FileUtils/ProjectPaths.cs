namespace GameDataParser.FileUtils;

public static class ProjectPaths
{
    public static string DataDirectory =>
        Path.Combine(AppContext.BaseDirectory, "Data");
    
    public static string GetDataFilePath(string fileName) =>
	    Path.Combine(DataDirectory, fileName);
}