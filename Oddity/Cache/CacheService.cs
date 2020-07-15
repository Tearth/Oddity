using System;
using System.Collections.Generic;

namespace Oddity.Cache
{
    public class CacheService<T>
    {
        public int LifetimeSeconds { get; set; }

        private Dictionary<string, T> _cachedData;
        private DateTime _lastUpdate;

        public CacheService(int lifetimeSeconds)
        {
            LifetimeSeconds = lifetimeSeconds;

            _cachedData = new Dictionary<string, T>();
            _lastUpdate = DateTime.MinValue;
        }

        public bool GetIfAvailable(out T data, string parameter)
        {
            parameter = parameter ?? "undefined";

            if ((DateTime.Now - _lastUpdate).TotalSeconds >= LifetimeSeconds || !_cachedData.ContainsKey(parameter))
            {
                data = default;
                return false;
            }

            data = _cachedData[parameter];
            return true;
        }

        public void Update(T data, string parameter)
        {
            parameter = parameter ?? "undefined";

            _cachedData[parameter] = data;
            _lastUpdate = DateTime.Now;
        }
    }
}
