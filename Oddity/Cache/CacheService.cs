using System;
using System.Collections.Generic;
using Oddity.Models;

namespace Oddity.Cache
{
    public class CacheService<T> where T : ModelBase, IIdentifiable
    {
        public int LifetimeSeconds { get; set; }

        private readonly Dictionary<string, CacheItem<T>> _cachedData;
        private readonly Dictionary<string, CacheItem<List<T>>> _cachedLists;

        public CacheService(int lifetimeSeconds)
        {
            LifetimeSeconds = lifetimeSeconds;

            _cachedData = new Dictionary<string, CacheItem<T>>();
            _cachedLists = new Dictionary<string, CacheItem<List<T>>>();
        }

        public bool GetIfAvailable(out T data, string parameter)
        {
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

        public bool GetListIfAvailable(out List<T> data, string endpoint)
        {
            if (_cachedLists.ContainsKey(endpoint))
            {
                var item = _cachedLists[endpoint];
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
            _cachedData[parameter] = new CacheItem<T>(data, DateTime.Now);
        }

        public void UpdateList(List<T> data, string endpoint)
        {
            _cachedLists[endpoint] = new CacheItem<List<T>>(data, DateTime.Now);

            foreach (var item in data)
            {
                Update(item, item.Id);
            }
        }

        public void Clear()
        {
            _cachedLists.Clear();
            _cachedLists.Clear();
        }
    }
}
