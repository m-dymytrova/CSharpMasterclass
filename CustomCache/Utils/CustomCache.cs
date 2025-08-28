using System.Collections.Concurrent;
using System.Diagnostics;

namespace CustomCache.Utils;

public class CustomCache<TItem>
{
	private class CacheItem(TItem item, TimeSpan ttl)
	{
		public TItem Item { get; } = item;
		public DateTime ExpiresAt { get; } = DateTime.UtcNow.Add(ttl);

		public bool IsExpired => DateTime.UtcNow > ExpiresAt;
	}

	private readonly ConcurrentDictionary<string, CacheItem> _cache = new();

	public TItem GetOrAdd(string key, Func<TItem> itemFactory, TimeSpan ttl = default)
	{
		if (ttl == TimeSpan.Zero)
		{
			ttl = TimeSpan.FromSeconds(5);
		}

		var stopwatch = Stopwatch.StartNew();

		// var item = _cache.GetOrAdd(key, _ =>
		// {
		// 	var createdItem = itemFactory();
		// 	stopwatch.Stop();
		// 	Console.WriteLine($"Caching '{key}', itemFactory took {stopwatch.ElapsedMilliseconds} ms");
		// 	return createdItem;
		// });
		//
		// if (stopwatch.IsRunning)
		// {
		// 	stopwatch.Stop();
		// 	Console.WriteLine($"Returning cached '{key}'");
		// }
		//
		// return item;

		CacheItem cacheItem = _cache.AddOrUpdate(key,
			_ =>
			{
				var createdItem = itemFactory();
				stopwatch.Stop();
				Console.WriteLine($"Caching '{key}', itemFactory took {stopwatch.ElapsedMilliseconds} ms");
				return new CacheItem(createdItem, ttl);
			},
			(_, existingEntry) =>
			{
				if (existingEntry.IsExpired)
				{
					var createdItem = itemFactory();
					stopwatch.Stop();
					Console.WriteLine($"Updating cache for expired '{key}', itemFactory took {stopwatch.ElapsedMilliseconds} ms");
					return new CacheItem(createdItem, ttl);
				}

				stopwatch.Stop();
				Console.WriteLine($"Returning cached '{key}'");
				return existingEntry;
			});

		return cacheItem.Item;
	}
}