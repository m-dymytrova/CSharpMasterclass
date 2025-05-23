using Cookbook.FileFormatting.Enums;

namespace Cookbook.FileFormatting.Extensions;

public static class FileFormatExtensions
{
	public static string ToExtension(this FileFormat format) => format switch
	{
		FileFormat.Text => "txt",
		FileFormat.Json => "json",
		_ => throw new NotSupportedException($"Unsupported format: {format}")
	};
}