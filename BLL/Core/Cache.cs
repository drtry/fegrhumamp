using Microsoft.Extensions.Caching.Memory;

namespace BLL.Core
{
    public class Cache<TItem>
    {
        private IMemoryCache _cache = new MemoryCache(new MemoryCacheOptions());

        public TItem Get(object key)
        {
            TItem cacheEntry;
            if (!_cache.TryGetValue(key, out cacheEntry)) // Ищем ключ в кэше.
            {
                return default(TItem);
            }
            return cacheEntry;
        }

        public TItem Create(object key, TItem createItem)
        {
            TItem cacheEntry;
            if (!_cache.TryGetValue(key, out cacheEntry)) // Ищем ключ в кэше.
            {
                // Ключ отсутствует в кэше, поэтому получаем данные.
                cacheEntry = createItem;

                // Сохраняем данные в кэше. 
                _cache.Set(key, cacheEntry);
            }
            return cacheEntry;
        }
    }
}
