using System;

namespace Oddity.Cache
{
    /// <summary>
    /// Represents an container for the cached data.
    /// </summary>
    /// <typeparam name="TData">Type of the cached data.</typeparam>
    public class CacheItem<TData>
    {
        /// <summary>
        /// Gets or sets the cached data.
        /// </summary>
        public TData Data { get; set; }

        /// <summary>
        /// Gets or sets the update time of the cached data.
        /// </summary>
        public DateTime UpdateTime { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CacheItem{TData}"/> class.
        /// </summary>
        /// <param name="data">The data which will be cached.</param>
        /// <param name="updateTime">The time at the moment when the data has been cached.</param>
        public CacheItem(TData data, DateTime updateTime)
        {
            Data = data;
            UpdateTime = updateTime;
        }
    }
}
