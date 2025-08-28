using CustomCache.Utils;

namespace CustomCache.Loaders;

public class DataDownloader
{
	// private readonly CustomCache<string> _cache = new();
	private readonly CustomCacheRefactored<string> _cache = new();

	private string GetData(string resourceId)
	{
		Thread.Sleep(1000);
		return $"Data for resource {resourceId}";
	}
	
	public string DownloadData(string resourceId)
	{
		var data = _cache.GetOrAdd(resourceId, () => GetData(resourceId), TimeSpan.FromSeconds(3));
		return data;
	}
}