using Cookbook.FileFormatting.Extensions;

namespace Cookbook.FileFormatting;

public static class FileMetadata
{
	public static string FilePath => $"{Settings.FileName}.{Settings.FileFormatSetting.ToExtension()}";
}