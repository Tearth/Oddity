using System;
using System.Collections.Generic;

namespace Oddity.Cache
{
    public class CacheService<T>
    {
        public int LifespanSeconds { get; set; }

        private Dictionary<string, T> _cachedData;
        private DateTime _lastUpdate;

        public CacheService(int lifespanSeconds)
        {
            LifespanSeconds = lifespanSeconds;

            _cachedData = new Dictionary<string, T>();
            _lastUpdate = DateTime.MinValue;
        }

        public bool GetIfAvailable(out T data, string parameter)
        {
            if (parameter == null)
            {
                parameter = "";
            }

            if ((DateTime.Now - _lastUpdate).TotalSeconds >= LifespanSeconds || !_cachedData.ContainsKey(parameter))
            {
                data = default;
                return false;
            }

            data = _cachedData[parameter];
            return true;
        }

        public void Update(T data, string parameter)
        {
            if (parameter == null)
            {
                parameter = "";
            }

            _cachedData[parameter] = data;
            _lastUpdate = DateTime.Now;
        }
    }
}
