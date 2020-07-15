using System;

namespace Oddity.Cache
{
    public class CacheItem<T>
    {
        public T Data { get; set; }
        public DateTime UpdateTime { get; set; }

        public CacheItem(T data, DateTime updateTime)
        {
            Data = data;
            UpdateTime = updateTime;
        }
    }
}
