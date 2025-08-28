using System.Collections.Concurrent;
using System.Diagnostics;

namespace CustomCache.Utils;

/// <summary>
/// Thread-safe cache with expiration support. Refactored version.
/// </summary>
public class CustomCacheRefactored<TItem>
{
    private record CacheItem(TItem Item, DateTime ExpiresAt)
    {
        public bool IsExpired => DateTime.UtcNow > ExpiresAt;
        public static CacheItem Create(TItem item, TimeSpan ttl)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            if (ttl <= TimeSpan.Zero)
            {
                throw new ArgumentOutOfRangeException(nameof(ttl), "TTL must be positive.");
            }

            return new CacheItem(item, DateTime.UtcNow.Add(ttl));
        }
    }

    private readonly ConcurrentDictionary<string, CacheItem> _cache = new();

    /// <summary>
    /// Gets an item from the cache or adds it using the factory if missing or expired.
    /// </summary>
    public TItem GetOrAdd(string key, Func<TItem> itemFactory, TimeSpan ttl = default)
    {
        if (ttl == TimeSpan.Zero)
        {
            ttl = TimeSpan.FromSeconds(5);
        }
        
        var stopwatch = Stopwatch.StartNew();
        
        CacheItem cacheItem = _cache.AddOrUpdate(key,
            _ =>
            {
                var createdItem = itemFactory();
                stopwatch.Stop();
                Console.WriteLine($"Caching '{key}', itemFactory took {stopwatch.ElapsedMilliseconds} ms");
                return CacheItem.Create(createdItem, ttl);
            },
            (_, existingEntry) =>
            {
                if (existingEntry.IsExpired)
                {
                    var createdItem = itemFactory();
                    stopwatch.Stop();
                    Console.WriteLine($"Updating cache for expired '{key}', itemFactory took {stopwatch.ElapsedMilliseconds} ms");
                    return CacheItem.Create(createdItem, ttl);
                }
                stopwatch.Stop();
                Console.WriteLine($"Returning cached '{key}'");
                return existingEntry;
            });
        
        return cacheItem.Item;
    }
    
}

