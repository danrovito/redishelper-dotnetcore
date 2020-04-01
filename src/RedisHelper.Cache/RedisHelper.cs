using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Caching.Distributed;

namespace RedisHelper.Cache
{
    public class RedisHelper
    {
        private readonly IDistributedCache _cache;

        public RedisHelper(IDistributedCache cache)
        {
            _cache = cache;
        }
        /// <summary>
        /// Adds the value sent to the Redis cache for the amount of seconds given.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="seconds"></param>
        public void Put(string key, string value, int seconds = 0)
        {
            DistributedCacheEntryOptions options = null;

            options = new DistributedCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(seconds));

            _cache.SetString(key, value, options);
        }
        /// <summary>
        /// Adds the value sent to the Redis cache indefinitely. 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Forever(string key, string value)
        {
            _cache.SetString(key, value);
        }

        /// <summary>
        /// Retrieves the value of the key supplied
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string Get(string key)
        {
            var existingItem = _cache.GetString(key);

            return string.IsNullOrEmpty(existingItem) ? null : existingItem.ToString();
        }

        /// <summary>
        /// Deletes the cached value based on the key supplied.
        /// </summary>
        /// <param name="key"></param>
        public void Forget(string key)
        {
            _cache.Remove(key);
        }

        /// <summary>
        /// Validates if the key exists in the cache.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Exists(string key)
        {
            var item = _cache.GetString(key);

            return !string.IsNullOrEmpty(item);
        }
    }
}
