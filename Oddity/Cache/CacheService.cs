using System;
using System.Collections.Generic;

namespace Oddity.Cache
{
    public class CacheService<T>
    {
        public int LifetimeSeconds { get; set; }

        private Dictionary<string, CacheItem<T>> _cachedData;

        public CacheService(int lifetimeSeconds)
        {
            LifetimeSeconds = lifetimeSeconds;

            _cachedData = new Dictionary<string, CacheItem<T>>();
        }

        public bool GetIfAvailable(out T data, string parameter)
        {
            parameter = parameter ?? "undefined";

            if (_cachedData.ContainsKey(parameter))
            {
                var item = _cachedData[parameter];
                if ((DateTime.Now - item.UpdateTime).TotalSeconds < LifetimeSeconds)
                {
                    data = item.Data;
                    return true;
                }
            }

            data = default;
            return false;
        }

        public void Update(T data, string parameter)
        {
            parameter = parameter ?? "undefined";
            _cachedData[parameter] = new CacheItem<T>(data, DateTime.Now);
        }
    }
}
