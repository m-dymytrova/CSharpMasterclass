namespace GameDataParser.FileUtils;

public static class ProjectPaths
{
    private static readonly string ProjectRoot = Path.GetFullPath(
        Path.Combine(AppContext.BaseDirectory, "..", "..", "..")
    );

    public static readonly string DataDirectory = Path.Combine(ProjectRoot, "Data");
}